using InitialProject.Repository;
using InitialProject.Service;
using InitialProject.View.Commands.Owner;
using System;
using System.Collections.Generic;
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

namespace InitialProject.View
{
    /// <summary>
    /// Interaction logic for OwnerView.xaml
    /// </summary>
    /// 
    public partial class OwnerView : Window
    {

        EndedAccommodationReservationRepository endedAccommodationReservationRepository = new EndedAccommodationReservationRepository("../../../Resources/Data/AccommodationReservation.txt", "|");


        private void PrintTextToView()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            endedAccommodationReservationRepository.AlertOwner();

            string consoleOutput = sw.ToString();
            AlertOwner.Text = consoleOutput;
        }
        public OwnerView()
        {
            InitializeComponent();
            PrintTextToView();

        }

        private void CreateAccommodationForm_Click(object sender, RoutedEventArgs e)
        {
            var s = new CreateAccommodationForm();
            s.Show();
            Close();
        }
        private void GuestGradeForm_Click(object sender, RoutedEventArgs e)
        {
            var s = new GuestGradeForm();
            s.Show();
            Close();
        }


        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var s = new LoginView();
            s.Show();
            Close();
        }

    }
}
