using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseBaseRepository<TEntity> 
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Remove(entity);
        }

    }
}
