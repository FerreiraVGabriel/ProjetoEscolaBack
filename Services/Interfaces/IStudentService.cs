using Infra.Entities.Params;
using Infra.Erros;
using OneOf;
using Services.Dtos.Input;
using Services.Dtos.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStudentService
    {
        Task<OneOf<PaginatedList<StudentOutputDTO>, BaseError>> GetPaginationAsync(SearchParams searchParams);
        Task<OneOf<StudentOutputDTO, BaseError>> Add(StudentInputDTO studentInputDTO);
        Task<OneOf<StudentOutputDTO, BaseError>> Update(StudentInputDTO studentInputDTO);
        Task<OneOf<bool, BaseError>> Delete(int id);
    }
}
