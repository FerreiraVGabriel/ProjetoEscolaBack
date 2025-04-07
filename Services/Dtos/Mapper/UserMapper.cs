using Infra.Entities;
using Services.Dtos.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos.Mapper
{
    public static class UserMapper
    {
        public static Usuario ToEntity(this UserInputDTO dto)
        {
            return new Usuario
            {
                SNome = dto.SNome,
                SSenha = dto.SSenha
            };
        }
    }
}
