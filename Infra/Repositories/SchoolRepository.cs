using Infra.Context;
using Infra.Entities;
using Infra.Entities.Params;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class SchoolRepository : BaseRepository<Escola>, ISchoolRepository
    {
        private readonly AppDbContext _context;
        public SchoolRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Escola>> GetPaginationAsync(SearchParams searchParams)
        {
            var query = _context.Escola.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchParams.SearchTerm))
            {
                var normalizedSearch = UtilInfra.Util.ToLowerAndRemoveSpecialChars(searchParams.SearchTerm);

                query = query.Where(a =>
                        UtilInfra.Util.ToLowerAndRemoveSpecialChars(a.SDescricao).Contains(normalizedSearch));
            }

            var school = await query
                .OrderByDescending(c => c.ICodEscola)
                    .ThenBy(c => c.SDescricao)
                .Skip((searchParams.PageNumber - 1) * searchParams.PageSize)
                .Include(c => c.Alunos)
            .Take(searchParams.PageSize)
            .ToListAsync();

            int totalItems = await query.CountAsync();

            var paginatedList = new PaginatedList<Escola>();
            paginatedList.Items = school;
            paginatedList.TotalCount = totalItems;


            return paginatedList;
        }

        public async Task<Escola> GetByIdAsync(int id)
        {
            return await _context.Escola.FirstOrDefaultAsync(s => s.ICodEscola == id);
        }

        public async Task<Escola[]> GetAllAsync()
        {
            return await _context.Escola.ToArrayAsync();
        }
    }
}
