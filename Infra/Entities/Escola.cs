using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Entities
{
    public class Escola
    {
        public int ICodEscola { get; set; }
        public string SDescricao { get; set; } = string.Empty;

        public ICollection<Aluno>? Alunos { get; set; }  
    }

}
