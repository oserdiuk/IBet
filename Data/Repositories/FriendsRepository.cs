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

        public void Delete(string userName, string friendId)
        {
            var item = Get(userName, friendId);
            context.Friends.Remove(item);
        }

        public Friend Get(string userName, string friendId)
        {
            return context.Friends.Where(f => (f.User.UserName == userName && f.UserFriendId == friendId)).FirstOrDefault();
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
