using Infra.Entities;
using Infra.Entities.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface ISchoolRepository : IBaseBaseRepository<Escola>
    {
        Task<PaginatedList<Escola>> GetPaginationAsync(SearchParams searchParams);
        Task<Escola> GetByIdAsync(int id);
        Task<Escola[]> GetAllAsync();
    }
}
