using System;

namespace IBetApp.Models
{
    public class NewsInfoViewModel
    {
        private string photoName;

        public int Id { get; set; }

        public string UserId { get; set; }

        public DateTime PublishDate { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PhotoName { get
            {
                return "../../Content/Images/News/" + photoName;
            }
            set
            {
                photoName = value;
            }
        }

        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }

        //public bool IsDeleted { get; set; }
    }
}