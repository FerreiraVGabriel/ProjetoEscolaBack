using Infra.Entities;
using Infra.Entities.Params;
using Infra.Erros;
using Infra.Interfaces;
using Infra.Repositories;
using OneOf;
using Services.Dtos.Input;
using Services.Dtos.Mapper;
using Services.Dtos.Output;
using Services.Erros;
using Services.Interfaces;
using System.Threading;

namespace Services.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SchoolService(ISchoolRepository schoolRepository, IUnitOfWork unitOfWork)
        {
            _schoolRepository = schoolRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<PaginatedList<SchoolOutputDTO>, BaseError>> GetPaginationAsync( SearchParams searchParams)
        {
            try
            {
                var school = await _schoolRepository.GetPaginationAsync(searchParams);

                var schoolOutputDTO = new PaginatedList<SchoolOutputDTO>
                {
                    Items = school.Items.Select(e => e.ToOutputDTO()).ToList(),
                    TotalCount = school.TotalCount
                };

                return schoolOutputDTO;
            }
            catch (Exception)
            {
                return new SchoolSearchFailedError();
            }
        }

        public async Task<OneOf<List<SchoolOutputDTO>, BaseError>> GetAllAsync()
        {
            try
            {
                var school = await _schoolRepository.GetAllAsync();

                return school.ToOutputDTOList();
            }
            catch (Exception)
            {
                return new StudentSearchFailedError();
            }
        }

        public async Task<OneOf<SchoolOutputDTO, BaseError>> Add(SchoolInputDTO schoolInputDTO)
        {
            try
            {
                var school = schoolInputDTO.ToEntity();
                await _schoolRepository.CreateAsync(school);
                await _unitOfWork.Commit();

                return school.ToOutputDTO(); 
            }
            catch (Exception)
            {
                return new SchoolSaveFailedError();
            }
        }

        public async Task<OneOf<SchoolOutputDTO, BaseError>> Update(SchoolInputDTO schoolInputDTO)
        {
            try
            {
                var school = await _schoolRepository.GetByIdAsync(schoolInputDTO.ICodEscola);
                school.SDescricao = schoolInputDTO.SDescricao;


                await _schoolRepository.UpdateAsync(school);
                await _unitOfWork.Commit();

                return school.ToOutputDTO();
            }
            catch (Exception)
            {
                return new SchoolUpdateFailedError();
            }
        }

        public async Task<OneOf<bool, BaseError>> Delete(int id)
        {
            try
            {
                var escola = await _schoolRepository.GetByIdAsync(id);
                if (escola is null)
                    return new SchoolDeleteFailedError(); 

                await _schoolRepository.DeleteAsync(escola);
                await _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return new SchoolDeleteFailedError();
            }
        }

    }
}
