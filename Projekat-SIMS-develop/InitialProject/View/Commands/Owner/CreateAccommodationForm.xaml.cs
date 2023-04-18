using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for CreateAccommodationForm.xaml
    /// </summary>
    public partial class CreateAccommodationForm : Window
    {
        ObservableCollection<Accommodation> accommodations = new ObservableCollection<Accommodation>();

        AccommodationRepository accommodationRepository = new AccommodationRepository("../../../Resources/Data/Accommodation.txt", "|");

        Accommodation accommodation = new Accommodation();
        public CreateAccommodationForm()
        {
            InitializeComponent();
        }

        private void CreateAcc_Click(object sender, RoutedEventArgs e)
        {
            accommodation._Name = Name.Text;

            Location location = new Location(LocationCity.Text, LocationCoutry.Text);
            accommodation._Location = location;
            accommodation._Type = (Model.Type)Convert.ToInt32(Type.Text);
            accommodation._MaxGuests = Convert.ToInt32(MaxGuests.Text);
            accommodation._MinDaysForReservation = Convert.ToInt32(MinDaysForReservation.Text);
            accommodation._DaysBeforeCancelingReservation = Convert.ToInt32(DaysBeforeCancelingReservation.Text);
            accommodation._Pictures = new List<string>() { Pictures.Text };

            accommodationRepository.Create(accommodation);
            accommodations.Add(accommodation);

            Name.Text = "";
            LocationCity.Text = "";
            LocationCoutry.Text = "";
            Type.Text = "";
            MaxGuests.Text = "";
            MinDaysForReservation.Text = "";
            DaysBeforeCancelingReservation.Text = "";
            Pictures.Text = "";
        }



        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
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
