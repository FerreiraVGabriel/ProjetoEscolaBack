using Infra.Context;
using Infra.Entities;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class UserRepository : BaseRepository<Usuario>, IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Usuario?> GetByNomeAsync(string nome)
        {
            return await _context.Usuario
                         .Where(u => u.SNome == nome)
                         .FirstOrDefaultAsync();

        }
    }
}
