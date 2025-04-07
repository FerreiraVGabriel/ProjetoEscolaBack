using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Entities
{
    public class Aluno
    {
        public int ICodAluno { get; set; }
        public string SNome { get; set; } = string.Empty;
        public DateTime DNascimento { get; set; }
        public string SCPF { get; set; } = string.Empty;
        public string SEndereco { get; set; } = string.Empty;
        public string SCelular { get; set; } = string.Empty;

        public int ICodEscola { get; set; }
        public Escola? Escola { get; set; }  
    }

}
