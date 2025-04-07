using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos.Input
{
    public record UserInputDTO
    {
        public string? SNome { get; set; }
        public string? SSenha { get; set; }
    }
}
