using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Erros
{
    public record TokenExpiredError()
       : BaseError("O token expirou", ErrorType.Validation);

    public record InvalidTokenError()
        : BaseError("O token é inválido", ErrorType.Validation);

    public record TokenNotFoundError()
        : BaseError("Token não encontrado", ErrorType.Validation);

    public record TokenUserMismatchError()
        : BaseError("O token não corresponde ao usuário atual", ErrorType.Validation);

    public record CreateUserError()
    : BaseError("Erro ao criar o usuário", ErrorType.Validation);
}
