using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace InitialProject.Service
{
    internal class UsersService
    {


        private readonly UsersRepository _usersRepository;

        public UsersService(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public IEnumerable<Users> GetAll()
        {
            return _usersRepository.GetAll();
        }

        public Users GetById(int userId)
        {
            return _usersRepository.GetById(userId);
        }

        public Users GetByName(string name)
        {
            return _usersRepository.GetByName(name);
        }

        public IEnumerable<Users> GetAllGuests()
        {
            return _usersRepository.GetAllGuests();
        }

        public IEnumerable<Users> GetAllTourists()
        {
            return _usersRepository.GetAllTourists();
        }

        public IEnumerable<Users> GetAllOwners()
        {
            return _usersRepository.GetAllOwners();
        }

        public IEnumerable<Users> GetAllGuides()
        {
            return _usersRepository.GetAllGuides();
        }

        public Users Create(Users user)
        {
            return _usersRepository.Create(user);
        }

        public Users CheckLogIn(string name, string pw)
        {
            List<Users> users = _usersRepository.GetAll().ToList();
            foreach (Users user in users)
            {
                if (!user.Name.Equals(name)) continue;
                return user.Password.Equals(pw) ? user : null;
            }
            return null;
        }
    }
}
