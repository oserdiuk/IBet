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
    public class FriendsRepository : IRepository<Friend>
    {
        private ApplicationDbContext context;

        public FriendsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Friend item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Friend Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Friend> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Friend item)
        {
            throw new NotImplementedException();
        }
    }
}
