using DAL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public abstract class BaseRepository
    {
        protected BaseRepository()
        {
        }
        public virtual async Task<List<Employee>> GetAll() {
            throw new NotImplementedException();
        }
    }
}