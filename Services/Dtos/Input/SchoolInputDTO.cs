using Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos.Input
{
    public record SchoolInputDTO
    {
        public int ICodEscola { get; set; }
        public string SDescricao { get; set; } = string.Empty;
    }

}
