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
    public class InterestsRepository : IRepository<Interest>
    {
        private ApplicationDbContext context;

        public InterestsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Interest item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Interest Get(int id)
        {
            return this.context.Interests.Find(id);
        }

        public IEnumerable<Interest> GetAll()
        {
            return this.context.Interests;
        }

        public void Update(Interest item)
        {
            throw new NotImplementedException();
        }
    }
}
