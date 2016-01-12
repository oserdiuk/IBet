using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBet.Domain.Interfaces.Entities
{
    public interface INews
    {
        int Id { get; set; }

        string UserId { get; set; }

        DateTime PublishDate { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        string PhotoName { get; set; }

        int LikesCount { get; set; }

        int DislikesCount { get; set; }

        bool IsDeleted { get; set; }

        IUser User { get; set; }
    }
}
