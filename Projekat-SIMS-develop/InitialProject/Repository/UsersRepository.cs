using InitialProject.Model;
using InitialProject.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    public class UsersRepository : IUsersRepository
    {

        // private string _path = "../../../Resources/Data/Users.txt";
        private string _path = "../../../Resources/Data/Users.txt";
        private string _delimiter = "|";

        public UsersRepository(string path, string delimiter)
        {
            _path = path;
            _delimiter = delimiter;
        }

        public IEnumerable<Users> GetAll()
        {

            List<string> lines = File.ReadAllLines(_path).ToList();
            List<Users> users = new List<Users>();
            foreach (string line in lines)
            {
                if (line == "") continue;
                users.Add(ConvertCSVFormatToUser(line));
            }
            return users;
        }

        public Users Create(Users user)
        {
            AppendLineToFile(_path, ConvertUserToCSVFormat(user));
            return user;
        }

        public Users GetById(int userId)
        {
            List<Users> users = GetAll().ToList();
            foreach (Users u in users)
            {
                if (u.Id == userId)
                {
                    return u;
                }

            }
            return null;
        }

        public Users GetByName(string name)
        {
            List<Users> users = GetAll().ToList();
            foreach (Users u in users)
            {
                if (u.Name == name)
                {
                    return u;
                }

            }
            return null;
        }

        public IEnumerable<Users> GetAllGuests()
        {
            List<Users> users = GetAll().ToList();
            List<Users> guests1 = new List<Users>();
            foreach (Users user in users)
            {
                if (user.Type == RoleType.Guest)
                {
                    guests1.Add(user);
                }
            }
            return guests1;
        }

        public IEnumerable<Users> GetAllTourists()
        {
            List<Users> users = GetAll().ToList();
            List<Users> guests2 = new List<Users>();
            foreach (Users user in users)
            {
                if (user.Type == RoleType.Tourist)
                {
                    guests2.Add(user);
                }
            }
            return guests2;
        }

        public IEnumerable<Users> GetAllGuides()
        {
            List<Users> users = GetAll().ToList();
            List<Users> guides = new List<Users>();
            foreach (Users user in users)
            {
                if (user.Type == RoleType.Guide)
                {
                    guides.Add(user);
                }
            }
            return guides;
        }

        public IEnumerable<Users> GetAllOwners()
        {
            List<Users> users = GetAll().ToList();
            List<Users> owners = new List<Users>();
            foreach (Users user in users)
            {
                if (user.Type == RoleType.Owner)
                {
                    owners.Add(user);
                }
            }
            return owners;
        }

        private Users ConvertCSVFormatToUser(string userCSVFormat)
        {
            var tokens = userCSVFormat.Split(_delimiter.ToCharArray());
            Enum.TryParse(tokens[3], true, out RoleType role);
            return new Users(
                tokens[0],
                tokens[1],
                int.Parse(tokens[2]),
                role);
        }

        private string ConvertUserToCSVFormat(Users users)
        {
            return string.Join(_delimiter,

               users.Name.ToString(),
               users.Password.ToString(),
               users.Id,
               users.Type.ToString());

        }
        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }


    }
}
