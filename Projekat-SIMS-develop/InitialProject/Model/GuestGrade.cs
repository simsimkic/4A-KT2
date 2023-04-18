using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class GuestGrade : INotifyPropertyChanged
    {

        public int guestId { get; set; }

        public int ownerId { get; set; }

        public int accommodationId { get; set; }

        public int deadlineForReviewing { get; set; }

        public int purity { get; set; }

        public int followingRules { get; set; }

        public string comment { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public int _Purity
        {
            get
            {
                return purity;
            }
            set
            {
                if (value != purity)
                {
                    purity = value;
                    OnPropertyChanged("purity");
                }
            }
        }


        public int _FollowingRules
        {
            get
            {
                return followingRules;
            }
            set
            {
                if (value != followingRules)
                {
                    followingRules = value;
                    OnPropertyChanged("followingRules");
                }
            }
        }

        public int _AccommodationId
        {
            get
            {
                return accommodationId;
            }
            set
            {
                if (value != accommodationId)
                {
                    accommodationId = value;
                    OnPropertyChanged("accommodationId");
                }
            }
        }


        public string _Comment
        {
            get
            {
                return comment;
            }
            set
            {
                if (value != comment)
                {
                    comment = value;
                    OnPropertyChanged("comment");
                }
            }
        }

        public GuestGrade(int guestId, int ownerId, int purity, int followingRules, int accommodationId, string comment)
        {
            this.guestId = 2;
            this.ownerId = 1;
            this.accommodationId = accommodationId;
            this.purity = purity;
            this.followingRules = followingRules;
            this.comment = comment;
        }

        public GuestGrade()
        {
            this.ownerId = 1;
            this.guestId = 2;
        }
        public override string? ToString()
        {
            return "|" + guestId +"gid" + "|" + ownerId +"oid"+ "|" + purity +"purity" + "|" + followingRules + "follrules" + "|" + accommodationId + "aid" + "|" + comment;
        }


    }
}
