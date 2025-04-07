using Infra.Entities;
using Services.Dtos.Input;
using Services.Dtos.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos.Mapper
{
    public static class SchoolMapper
    {
        public static Escola ToEntity(this SchoolInputDTO dto)
        {
            return new Escola
            {
                SDescricao = dto.SDescricao
            };
        }

        public static SchoolOutputDTO ToOutputDTO(this Escola escola)
        {
            return new SchoolOutputDTO
            {
                ICodEscola = escola.ICodEscola,
                SDescricao = escola.SDescricao,
                StudentOutputDTO = escola.Alunos?
                    .Where(a => a.ICodEscola == escola.ICodEscola)
                    .Select(a => a.ToOutputDTO())
                    .ToList()
            };
        }

        public static List<Escola> ToEntityList(this IEnumerable<SchoolInputDTO> dtos)
        {
            return dtos.Select(dto => dto.ToEntity()).ToList();
        }

        public static List<SchoolOutputDTO> ToOutputDTOList(this IEnumerable<Escola> escolas)
        {
            return escolas.Select(e => e.ToOutputDTO()).ToList();
        }
    }
}
