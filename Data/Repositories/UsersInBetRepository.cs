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
    public class UsersInBetRepository : IRepository<UserInBet>
    {
        private ApplicationDbContext context;

        public UsersInBetRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(UserInBet item)
        {
            context.UsersInBet.Add(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserInBet Get(int id)
        {
            return context.UsersInBet.Find(id);
        }

        public IEnumerable<UserInBet> GetAll()
        {
            return this.context.UsersInBet;
        }

        public void Update(UserInBet item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void CreateForUser(string userId, Bet bet)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            unitOfWork.NewsRepository.Create(new News(userId, "New bet!", String.Format("{0}/n{1}", bet.Interest.InterestTitle, bet.Description)));
            int curNewsId = unitOfWork.NewsRepository.GetAll().LastOrDefault().Id;
            unitOfWork.UsersInBetRepository.Create(new UserInBet(userId, bet.Id, curNewsId));
            unitOfWork.Save();
        }
    }
}
