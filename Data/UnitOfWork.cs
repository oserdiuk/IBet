using IBet.Data.Repositories;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBet.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private UsersRepository usersRepository;
        private BetsRepository betsRepository;
        private UserInterestsRepository userInterestsRepository;
        private UsersInBetRepository usersInBetRepository;
        private NewsRepository newsRepository;
        private FriendsRepository friendsRepository;
        private InterestsRepository interestsRepository;

        public UsersRepository UsersRepository
        {
            get
            {
                if (usersRepository == null)
                {
                    usersRepository = new UsersRepository(db);
                }
                return usersRepository;
            }
        }
        public BetsRepository BetsRepository
        {
            get
            {
                if (betsRepository == null)
                {
                    betsRepository = new BetsRepository(db);
                }
                return betsRepository;
            }
        }
        public UserInterestsRepository UserInterestsRepository
        {
            get
            {
                if (userInterestsRepository == null)
                {
                    userInterestsRepository = new UserInterestsRepository(db);
                }
                return userInterestsRepository;
            }
        }
        public UsersInBetRepository UsersInBetRepository
        {
            get
            {
                if (usersInBetRepository == null)
                {
                    usersInBetRepository = new UsersInBetRepository(db);
                }
                return usersInBetRepository;
            }
        }
        public NewsRepository NewsRepository
        {
            get
            {
                if (newsRepository == null)
                {
                    newsRepository = new NewsRepository(db);
                }
                return newsRepository;
            }
        }
        public FriendsRepository FriendsRepository
        {
            get
            {
                if (friendsRepository == null)
                {
                    friendsRepository = new FriendsRepository(db);
                }
                return friendsRepository;
            }
        }
        public InterestsRepository InterestsRepository
        {
            get
            {
                if (interestsRepository == null)
                {
                    interestsRepository = new InterestsRepository(db);
                }
                return interestsRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}

