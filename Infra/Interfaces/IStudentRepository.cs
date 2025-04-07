using Infra.Entities.Params;
using Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IStudentRepository : IBaseBaseRepository<Aluno>
    {
        Task<PaginatedList<Aluno>> GetPaginationAsync(SearchParams searchParams);
        Task<Aluno> GetByIdAsync(int id);
    }
}
