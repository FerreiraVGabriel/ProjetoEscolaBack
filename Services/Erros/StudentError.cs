using Infra.Erros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Erros
{
    public record StudentSearchFailedError()
        : BaseError("Não foi possível realizar a busca de alunos.", ErrorType.BusinessRule);

    public record StudentInvalidCPFError()
        : BaseError("O campo CPF informado é inválido.", ErrorType.Validation);

    public record StudentEmptyCPFError()
        : BaseError("O campo CPF é obrigatório.", ErrorType.Validation);

    public record StudentInvalidPhoneError()
        : BaseError("O campo telefone informado é inválido.", ErrorType.Validation);

    public record StudentEmptyPhoneError()
        : BaseError("O campo telefone é obrigatório.", ErrorType.Validation);

    public record StudentInvalidBirthDateError()
        : BaseError("A data de nascimento informada é inválida.", ErrorType.Validation);

    public record StudentEmptyBirthDateError()
        : BaseError("O campo data de nascimento é obrigatório.", ErrorType.Validation);

    public record StudentSaveFailedError()
        : BaseError("Não foi possível salvar os dados do aluno.", ErrorType.BusinessRule);

    public record StudentDeleteFailedError()
        : BaseError("Não foi possível excluir o aluno.", ErrorType.BusinessRule);
}

