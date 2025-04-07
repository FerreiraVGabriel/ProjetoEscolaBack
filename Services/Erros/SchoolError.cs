using Infra.Erros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Erros
{
    public record SchoolSearchFailedError()
        : BaseError("Não foi possível realizar a busca de escolas.", ErrorType.BusinessRule);

    public record SchoolSaveFailedError()
        : BaseError("Não foi possível salvar os dados da escola.", ErrorType.BusinessRule);

    public record SchoolUpdateFailedError()
        : BaseError("Não foi possível atualizar os dados da escola.", ErrorType.BusinessRule);

    public record SchoolDeleteFailedError()
        : BaseError("Não foi possível excluir a escola.", ErrorType.BusinessRule);
}
