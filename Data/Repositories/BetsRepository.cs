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
    public class BetsRepository : IRepository<Bet>
    {
        ApplicationDbContext context;

        public BetsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(Bet item)
        {
            context.Bets.Add(item);
        }

        public void Delete(int id)
        {
            Get(id).IsDeleted = true;
        }

        public Bet Get(int id)
        {
            return context.Bets.Find(id);
        }

        public IEnumerable<Bet> GetAll()
        {
            return context.Bets;
        }

        public void Update(Bet item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Bet> GetTheNewestBets(int countOfBets)
        {
            return this.GetAll().OrderByDescending(b => b.StartDate).Take(countOfBets);
        }
    }
}
