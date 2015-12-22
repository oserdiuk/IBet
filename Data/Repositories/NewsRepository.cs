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
    public class NewsRepository : IRepository<Domain.Core.News>
    {
        private ApplicationDbContext context;

        public NewsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Domain.Core.News item)
        {
            this.context.News.Add(item);
        }

        public void Delete(int id)
        {
            this.Get(id).IsDeleted = true;
        }

        public Domain.Core.News Get(int id)
        {
            return this.context.News.Find(id);
        }

        public IEnumerable<Domain.Core.News> GetAll()
        {
            return this.context.News;
        }

        public void Update(Domain.Core.News item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
