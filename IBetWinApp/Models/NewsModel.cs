using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBetWinApp.Models
{
    public class NewsModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public DateTime PublishDate { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PhotoName { get; set; }

        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }

        public bool IsDeleted { get; set; }
    }
}
