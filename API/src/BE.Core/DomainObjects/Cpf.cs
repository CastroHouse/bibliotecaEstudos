using System;

namespace BE.Core.DomainObjects
{
    public struct Cpf
    {
        private readonly string _value;
        private Cpf(string value) => _value = value;

        public static Cpf Parse(string value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }

            throw new Exception("O Valor recebido não pode ser convertido em \"Cpf\"");
        }

        public static bool TryParse(string value, out Cpf cpf)
        {
            value = value.Replace(".", "").Replace("-", "");
            cpf = new Cpf(value);

            if (value.Length != 11)
                return false;

            if (!ValidaDigitoVerificador(value, 8, 10, value[9].ToString())) return false;

            if (!ValidaDigitoVerificador(value, 9, 11, value[10].ToString())) return false;

            return true;
        }

        public static bool ValidaDigitoVerificador(string value, int loop, int posicaoDigito, string digitoVerificador)
        {

            int totalMultiplicacao = 0;

            for (int i = 0; i <= loop; i++)
            {
                totalMultiplicacao += Int32.Parse(value[i].ToString()) * posicaoDigito;
                posicaoDigito--;
            }

            int restoVldDigito = totalMultiplicacao % 11;

            if (restoVldDigito < 2 && Int32.Parse(digitoVerificador) != 0)
                return false;

            int somaDigitoVerificador = 11 - restoVldDigito;

            if (restoVldDigito >= 2 && somaDigitoVerificador != Int32.Parse(digitoVerificador))
                return false;

            return true;
        }

        public static implicit operator Cpf(string value) => Parse(value);

        public override string ToString() => _value;
    }
}