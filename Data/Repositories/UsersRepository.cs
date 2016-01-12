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
    public class UsersRepository 
    {
        private ApplicationDbContext context; 
        //TO-DO implement interface IRepository
        public UsersRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(ApplicationUser item)
        {
            context.Users.Add(item);
        }

        public void Delete(string id)
        {
            Get(id).IsDeleted = true;
        }

        public ApplicationUser Get(string id)
        {
            return context.Users.Find(id);
        }

        public bool CheckForExisting(string login, string password)
        {
            //if (this.context.Users.SingleOrDefault(u => u.Email == login && u.PasswordHash == Convert.ToString(password.GetHashCode()) && !u.IsDeleted) != null)
            //{
            //           FormsAuthentication.SetAuthCookie(_logModel.LoginUsername, false);
            //          return new LoginResult(ReturnUrlIsValid() ? Redirect(_returnUrl) : RedirectToAction("Index", "Home"),
            //                        LoginStatus.LoginOK);
            //}
            //TODO check password for mobile sign in
            if (this.context.Users.SingleOrDefault(u => u.Email == login && !u.IsDeleted) != null)
            {
                if (password == "Qwerty_123")
                {
                    return true;
                }
            }
            return false;
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
