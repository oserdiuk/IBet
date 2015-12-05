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
    public class UsersRepository : IRepository<ApplicationUser>
    {
        private ApplicationDbContext context; 

        public UsersRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(ApplicationUser item)
        {
            context.Users.Add(item);
        }

        public void Delete(int id)
        {
            Get(id).IsDeleted = true;
        }

        public ApplicationUser Get(int id)
        {
            return context.Users.Find(id);
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return context.Users;
        }

        public void Update(ApplicationUser item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<ApplicationUser> GetTopBestByBets(int countOfUsers)
        {
            return this.GetAll().OrderBy(u => u.UserInBets.Where(x => x.IsWinner).Sum(x => x.Bet.MoneySum)).Take(countOfUsers);
        }
    }
}
