using Infra.Entities.Params;
using Infra.Erros;
using OneOf;
using Services.Dtos.Input;
using Services.Dtos.Output;

namespace Services.Interfaces
{
    public interface ISchoolService
    {
        Task<OneOf<PaginatedList<SchoolOutputDTO>, BaseError>> GetPaginationAsync(SearchParams searchParams);
        Task<OneOf<List<SchoolOutputDTO>, BaseError>> GetAllAsync();
        Task<OneOf<SchoolOutputDTO, BaseError>> Add(SchoolInputDTO schoolInputDTO);
        Task<OneOf<SchoolOutputDTO, BaseError>> Update(SchoolInputDTO schoolInputDTO);
        Task<OneOf<bool, BaseError>> Delete(int id);
    }
}
