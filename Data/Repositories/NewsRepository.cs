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
    public class NewsRepository : IRepository<Domain.Core.News>
    {
        private ApplicationDbContext context;

        public NewsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Domain.Core.News item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Domain.Core.News Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Core.News> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Core.News item)
        {
            throw new NotImplementedException();
        }
    }
}
