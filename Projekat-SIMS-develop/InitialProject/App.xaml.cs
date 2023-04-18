using InitialProject.Controller;
using InitialProject.Repository;
using InitialProject.Repository.Interface;
using InitialProject.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace InitialProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private string USER_FILE = _projectPath + "\\Resources\\Data\\Users.txt";










        private const string TXT_DELIMITER = "|";



        internal UsersController UsersController { get; set; }


        public App()
        {
            var usersRepository = new UsersRepository(USER_FILE, TXT_DELIMITER);














            var usersService = new UsersService(usersRepository);
            UsersController = new UsersController(usersService);

        }
    }
}
