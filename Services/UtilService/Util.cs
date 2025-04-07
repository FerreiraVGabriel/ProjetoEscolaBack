using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UtilService
{
    public static class Util
    {
        //VALIDA TELEFONE
        public static bool TelefoneValido(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
                return false;

            var numeros = new string(telefone.Where(char.IsDigit).ToArray());

            return numeros.Length == 9 || numeros.Length == 10 || numeros.Length == 11;
        }


        //VALIDA DATA DE NASCIMENTO
        public static bool DataNascimentoValida(DateTime dataNascimento)
        {
            var hoje = DateTime.Today;

            var idade = hoje.Year - dataNascimento.Year;
            if (dataNascimento > hoje.AddYears(-idade)) idade--;

            return dataNascimento <= hoje && idade is >= 0 and <= 120;
        }

        //VALIDA CPF
        public static bool CPFValido(string cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11 || cpf.Distinct().Count() == 1)
                return false;

            var tempCpf = cpf[..9];
            var digito1 = CalculaDigito(tempCpf);
            var digito2 = CalculaDigito(tempCpf + digito1);

            return cpf.EndsWith(digito1 + digito2);
        }

        private static string CalculaDigito(string cpf)
        {
            int soma = 0;
            for (int i = 0; i < cpf.Length; i++)
                soma += int.Parse(cpf[i].ToString()) * ((cpf.Length + 1) - i);

            int resto = soma % 11;
            return (resto < 2 ? 0 : 11 - resto).ToString();
        }

    }
}
