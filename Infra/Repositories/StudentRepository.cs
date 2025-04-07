using Infra.Context;
using Infra.Entities.Params;
using Infra.Entities;
using Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Repositories
{
    public class StudentRepository : BaseRepository<Aluno>, IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Aluno>> GetPaginationAsync(SearchParams searchParams)
        {
            var query = _context.Aluno.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchParams.SearchTerm))
            {
                var normalizedSearch = UtilInfra.Util.ToLowerAndRemoveSpecialChars(searchParams.SearchTerm);

                query = query .Where(a =>
                        UtilInfra.Util.ToLowerAndRemoveSpecialChars(a.SNome).Contains(normalizedSearch) ||
                        UtilInfra.Util.ToLowerAndRemoveSpecialChars(a.SCPF).Contains(normalizedSearch));
            }

            var student = await query
                .OrderByDescending(c => c.SNome)
                    .ThenBy(c => c.DNascimento)
                .Skip((searchParams.PageNumber - 1) * searchParams.PageSize)
                .Include(c => c.Escola)
            .Take(searchParams.PageSize)
            .ToListAsync();

            int totalItems = await query.CountAsync();

            var paginatedList = new PaginatedList<Aluno>();
            paginatedList.Items = student;
            paginatedList.TotalCount = totalItems;


            return paginatedList;
        }

        public async Task<Aluno> GetByIdAsync(int id)
        {
            return await _context.Aluno.FirstOrDefaultAsync(s => s.ICodAluno == id);
        }
    }
}
