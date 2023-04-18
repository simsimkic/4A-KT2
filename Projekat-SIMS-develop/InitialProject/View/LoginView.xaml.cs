using InitialProject.Controller;
using InitialProject.Model;
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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {

        private UsersController _usersController;
        public string BadLoginText { get; set; }
        public LoginView()
        {
            InitializeComponent();
            var app = Application.Current as App;
            _usersController = app.UsersController;
            BadLoginText = "*Incorrect password or name";
            this.DataContext = this;
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




        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            string user = txtUser.Text;
            string pw = txtPass.Password.ToString();

            Users logged = this._usersController.CheckLogIn(user, pw);
            if (logged == null)
            {
                txtPass.Password = "";
                ErrorText.Text = BadLoginText;
                return;
            }
            var app = Application.Current as App;
            app.Properties["userId"] = logged.Id;
            app.Properties["userRole"] = logged.Type.ToString();
            if (logged.Type.ToString().Equals("Owner"))
            {
                var s = new OwnerHomePageView();
                s.Show();
                Close();
            }
            else if (logged.Type.ToString().Equals("Guide"))
            {
                var s = new OwnerView();
                s.Show();
                Close();
            }
            else if (logged.Type.ToString().Equals("Guest"))
            {
                var s = new OwnerHomePageView();
                s.Show();
                Close();
            }
            else if (logged.Type.ToString().Equals("Tourist"))
            {
                var s = new OwnerView();
                s.Show();
                Close();
            }
            Console.WriteLine("Logged in user with ID: {0} and ROLE: {1}", app.Properties["userId"], app.Properties["userRole"]);
        }


    }
}
