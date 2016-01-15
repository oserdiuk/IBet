using IBet.Domain.Interfaces;
using IBet.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
