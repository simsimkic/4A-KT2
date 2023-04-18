using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{

    public enum RoleType
    {
        Owner = 1,
        Guide = 2,
        Guest = 3,
        Tourist = 4
    }

    public class Users : INotifyPropertyChanged
    {



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        public int Id;
        public string Name;
        public string Password;
        public RoleType Type;

        public Users(string name, string password, int id, RoleType type)
        {
            Id = id;
            Name = name;
            Password = password;
            Type = type;
        }



        public int _Id
        {
            get { return Id; }
            set
            {
                if (value != Id)
                {
                    Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }


        public string _Name
        {
            get { return Name; }
            set
            {
                if (value != Name)
                {
                    Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }


        public string _Password
        {
            get { return Password; }
            set
            {
                if (value != Password)
                {
                    Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        public RoleType _Type
        {
            get { return Type; }
            set
            {
                if (value != Type)
                {
                    Type = value;
                    OnPropertyChanged("Role");
                }
            }
        }




        public Users() { }

        public override string? ToString()
        {
            return "|" + Id + "|" + Name + "|" + Password + "|" + Type;
        }








    }
}
