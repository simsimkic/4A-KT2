using InitialProject.View.Commands.Owner;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for OwnerHomePageView.xaml
    /// </summary>
    public partial class OwnerHomePageView : Window
    {
        public OwnerHomePageView()
        {
            InitializeComponent();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    
        private void ChangeViews_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.F1)
            {
                var createAccommodationForm = new CreateAccommodationForm();
                createAccommodationForm.Show();
                Close();
            }

            if (e.Key == Key.F2)
            {
                var createGuestGradeForm = new GuestGradeForm();
                createGuestGradeForm.Show();
                Close();
            }
            if(e.Key == Key.F3)
            {
                var showReviews = new ShowReviewsView();
                showReviews.Show();
                Close();
            }
        }

        private void CreateAccommodationPage_Click(object sender, RoutedEventArgs e)
        {
            var createAccommodationForm = new CreateAccommodationForm();
            createAccommodationForm.Show();
            Close();
        }

        private void Button_Logout(object sender, RoutedEventArgs e)
        {
            var s = new LoginView();
            s.Show();
            Close();
        }

        private void GradeGuestPage_Click(object sender, RoutedEventArgs e)
        {
            var createGuestGradeForm = new GuestGradeForm();
            createGuestGradeForm.Show();
            Close();
        }

        private void ShowReviewsPage_Click(object sender, RoutedEventArgs e)
        {
            var showReviews = new ShowReviewsView();
            showReviews.Show();
            Close();
        }
    }
}
