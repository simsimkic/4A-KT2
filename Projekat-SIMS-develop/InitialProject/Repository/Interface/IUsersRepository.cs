using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository.Interface
{
    public interface IUsersRepository
    {
        IEnumerable<Users> GetAll();
        Users GetById(int userId);

        Users GetByName(string name);

        Users Create(Users user);

        IEnumerable<Users> GetAllOwners();

        IEnumerable<Users> GetAllGuests();

        IEnumerable<Users> GetAllGuides();

        IEnumerable<Users> GetAllTourists();






    }
}
