using InitialProject.Repository;
using InitialProject.Service;
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

namespace InitialProject.View.Commands.Owner
{
    /// <summary>
    /// Interaction logic for ShowReviewsView.xaml
    /// </summary>
    public partial class ShowReviewsView : Window
    {

        OwnerGradeRepository ownerGradeRepository = new OwnerGradeRepository("../../../Resources/Data/OwnerGrade.txt", "|");
        OwnerGradeService ownerGradeService = new OwnerGradeService();


        private void PrintTextToView()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            ownerGradeService.ShowReviews();

            string consoleOutput = sw.ToString();
            ShowReviews.Text = consoleOutput;
        }


        public ShowReviewsView()
        {
            InitializeComponent();
            PrintTextToView();
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
