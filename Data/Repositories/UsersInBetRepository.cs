using IBet.Domain.Core;
using IBet.Domain.Interfaces;
using IBet.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBet.Data.Repositories
{
    public class UsersInBetRepository : IRepository<UserInBet>
    {
        private ApplicationDbContext context;

        public UsersInBetRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(UserInBet item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserInBet Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserInBet> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(UserInBet item)
        {
            throw new NotImplementedException();
        }
    }
}
