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
using Services.UtilService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<PaginatedList<StudentOutputDTO>, BaseError>> GetPaginationAsync(SearchParams searchParams)
        {
            try
            {
                var student = await _studentRepository.GetPaginationAsync(searchParams);

                var studentOutputDTO = new PaginatedList<StudentOutputDTO>
                {
                    Items = student.Items.Select(e => e.ToOutputDTO()).ToList(),
                    TotalCount = student.TotalCount
                };

                return studentOutputDTO;
            }
            catch (Exception)
            {
                return new StudentSearchFailedError();
            }
        }

        public async Task<OneOf<StudentOutputDTO, BaseError>> Add(StudentInputDTO studentInputDTO)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(studentInputDTO.SCPF))
                    return new StudentEmptyCPFError();

                if (!Util.CPFValido(studentInputDTO.SCPF))
                    return new StudentInvalidCPFError();

                if (string.IsNullOrWhiteSpace(studentInputDTO.SCelular))
                    return new StudentEmptyPhoneError();

                if (!Util.TelefoneValido(studentInputDTO.SCelular))
                    return new StudentInvalidPhoneError();

                if (string.IsNullOrWhiteSpace(studentInputDTO.DNascimento.ToString()))
                    return new StudentEmptyBirthDateError();

                if (!Util.DataNascimentoValida(DateTime.ParseExact(studentInputDTO.DNascimento, "ddMMyyyy", CultureInfo.InvariantCulture)))
                    return new StudentInvalidPhoneError();

                var student = studentInputDTO.ToEntity();
                await _studentRepository.CreateAsync(student);
                await _unitOfWork.Commit();

                return student.ToOutputDTO();
            }
            catch (Exception)
            {
                return new StudentSaveFailedError();
            }
        }

        public async Task<OneOf<StudentOutputDTO, BaseError>> Update(StudentInputDTO studentInputDTO)
        {
            try
            {
                var student = await _studentRepository.GetByIdAsync(studentInputDTO.ICodAluno);

                student.SNome = studentInputDTO.SNome;
                student.DNascimento = DateTime.ParseExact(studentInputDTO.DNascimento, "ddMMyyyy", CultureInfo.InvariantCulture);
                student.SCPF = studentInputDTO.SCPF;
                student.SEndereco = studentInputDTO.SEndereco;
                student.SCelular = studentInputDTO.SCelular;
                student.ICodEscola = studentInputDTO.ICodEscola;


                await _studentRepository.UpdateAsync(student);
                await _unitOfWork.Commit();

                return student.ToOutputDTO();
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
                var escola = await _studentRepository.GetByIdAsync(id);
                if (escola is null)
                    return new StudentDeleteFailedError();

                await _studentRepository.DeleteAsync(escola);
                await _unitOfWork.Commit();
                return true;
            }
            catch (Exception)
            {
                return new StudentDeleteFailedError();
            }
        }
    }
}
