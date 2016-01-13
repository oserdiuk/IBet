using IBet.Domain.Core;
using IBet.Domain.Interfaces;
using IBet.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBet.Data.Repositories
{
    public class FriendsRepository 
    {
        private ApplicationDbContext context;

        public FriendsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Friend item)
        {
            this.context.Friends.Add(item);
        }

        public void Delete(string userId, string friendId)
        {
            context.Friends.Where(f => (f.UserId == userId && f.UserFriend.UserName == friendId) ||
                (f.UserFriendId == friendId && f.UserId == userId)).ForEachAsync(f => { f.IsDeleted = true; });
        }

        public Friend Get(int id)
        {
            return context.Friends.Find(id);
        }

        public IEnumerable<Friend> GetAll()
        {
            return context.Friends;
        }

        public void Update(Friend item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
