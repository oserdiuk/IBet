using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IBet.Domain.Core
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public DateTime PublishDate { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PhotoName { get; set; }

        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ApplicationUser User { get; set; }

        public News()
        {

        }

        public News(string userId, string name, string description, string photoName = "")
        {
            this.UserId = userId;
            this.Name = name;
            this.Description = description;
            this.PhotoName = photoName;
            this.PublishDate = DateTime.Today;
        }
    }
}