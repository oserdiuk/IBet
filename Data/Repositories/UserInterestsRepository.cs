﻿using IBet.Domain.Core;
using IBet.Domain.Interfaces;
using IBet.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBet.Data.Repositories
{
    public class UserInterestsRepository : IRepository<UserInterest>
    {
        private ApplicationDbContext context;

        public UserInterestsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(UserInterest item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserInterest Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserInterest> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(UserInterest item)
        {
            throw new NotImplementedException();
        }
    }
}
