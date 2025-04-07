using Infra.Entities;
using Services.Dtos.Input;
using Services.Dtos.Output;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos.Mapper
{
    public static class StudentMapper
    {
        // DTO -> Entidade
        public static Aluno ToEntity(this StudentInputDTO dto)
        {
            return new Aluno
            {
                SNome = dto.SNome,
                DNascimento = DateTime.ParseExact(dto.DNascimento, "ddMMyyyy", CultureInfo.InvariantCulture),
                SCPF = dto.SCPF,
                SEndereco = dto.SEndereco,
                SCelular = dto.SCelular,
                ICodEscola = dto.ICodEscola
            };
        }

        // Entidade -> DTO
        public static StudentOutputDTO ToOutputDTO(this Aluno aluno)
        {
            return new StudentOutputDTO
            {
                ICodAluno = aluno.ICodAluno,
                SNome = aluno.SNome,
                DNascimento = aluno.DNascimento.ToString(),
                SCPF = aluno.SCPF,
                SEndereco = aluno.SEndereco,
                SCelular = aluno.SCelular,
                ICodEscola = aluno.ICodEscola,
                EscolaDescricao = aluno.Escola?.SDescricao ?? string.Empty
            };
        }

        // Lista DTO -> Lista Entidade
        public static List<Aluno> ToEntityList(this IEnumerable<StudentInputDTO> dtos)
        {
            return dtos.Select(dto => dto.ToEntity()).ToList();
        }

        // Lista Entidade -> Lista DTO
        public static List<StudentOutputDTO> ToOutputDTOList(this IEnumerable<Aluno> alunos, Aluno[] student)
        {
            return alunos.Select(a => a.ToOutputDTO()).ToList();
        }
    }
}
