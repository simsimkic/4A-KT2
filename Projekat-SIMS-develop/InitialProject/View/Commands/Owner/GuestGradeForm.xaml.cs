using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InitialProject.View.Commands.Owner
{
    /// <summary>
    /// Interaction logic for GuestGradeForm.xaml
    /// </summary>
    public partial class GuestGradeForm : Window
    {
        ObservableCollection<GuestGrade> guestGrades = new ObservableCollection<GuestGrade>();

        GuestGradeRepository guestGradeRepository = new GuestGradeRepository("../../../Resources/Data/GuestGrade.txt", "|");

        GuestGrade guestGrade = new GuestGrade();


        EndedAccommodationReservationRepository endedAccommodationReservationRepository = new EndedAccommodationReservationRepository("../../../Resources/Data/AccommodationReservation.txt", "|");


        private void PrintTextToView()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            endedAccommodationReservationRepository.AlertOwner();

            string consoleOutput = sw.ToString();
            AlertOwner.Text = consoleOutput;
        }

        public GuestGradeForm()
        {
            InitializeComponent();
            PrintTextToView();


        }


        private void CreateGuestGrade_Click(object sender, RoutedEventArgs e)
        {
            guestGrade._Purity = Convert.ToInt32(Purity.Text);
            guestGrade.followingRules = Convert.ToInt32(FollowingRules.Text);
            guestGrade.comment = Comment.Text;
            guestGrade.accommodationId = Convert.ToInt32(AccommodationId.Text);

            guestGradeRepository.Create(guestGrade);

            Purity.Text = "";
            FollowingRules.Text = "";
            Comment.Text = "";


            IEnumerable<EndedAccommodationReservation> reservations = endedAccommodationReservationRepository.GetAll().ToList();
            foreach (EndedAccommodationReservation reservation in reservations)
            {
                if (reservation.AccommodationId == Convert.ToInt32(AccommodationId.Text) && reservation.DaysAfterEndingReservation <= 5)
                {
                    reservation.IsGraded = true;
                    endedAccommodationReservationRepository.CreateGradedGuest(reservation);
                    endedAccommodationReservationRepository.Delete(Convert.ToInt32(AccommodationId.Text));

                }
            }
            AccommodationId.Text = "";
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            var s = new OwnerHomePageView();
            s.Show();
            Close();
        }
    }
}
