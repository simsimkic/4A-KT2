using InitialProject.Model;
using InitialProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Controller
{
    internal class UsersController
    {

        private readonly UsersService _usersService;

        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }



        public IEnumerable<Users> GetAll()
        {
            return _usersService.GetAll();
        }

        public Users GetById(int userId)
        {
            return _usersService.GetById(userId);
        }

        public Users GetByName(string name)
        {
            return _usersService.GetByName(name);
        }

        public IEnumerable<Users> GetAllGuests()
        {
            return _usersService.GetAllGuests();
        }


        public IEnumerable<Users> GetAllTourists()
        {
            return _usersService.GetAllTourists();
        }


        public IEnumerable<Users> GetAllGuides()
        {
            return _usersService.GetAllGuides();
        }

        public IEnumerable<Users> GetAllOwners()
        {
            return _usersService.GetAllOwners();
        }

        public Users CheckLogIn(string name, string pw)
        {
            return this._usersService.CheckLogIn(name, pw);
        }

        public Users Create(Users user)
        {
            return _usersService.Create(user);
        }


    }
}
