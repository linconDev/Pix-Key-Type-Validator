using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace pixkeytypevalidator.Utils
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoChave
    {
        CPF = 1,
        CNPJ,
        PHONE,
        EMAIL,
        EVP,
    }

    public static class ChaveValidator
    {
        public static TipoChave? ValidarChave(string chave)
        {
            if (IsCpf(chave)) return TipoChave.CPF;
            if (IsCnpj(chave)) return TipoChave.CNPJ;
            if (IsPhone(chave)) return TipoChave.PHONE;
            if (IsEmail(chave)) return TipoChave.EMAIL;
            if (IsGuid(chave)) return TipoChave.EVP;

            return null;
        }

        private static bool IsCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            // Regex para validar CPF
            var regex = new Regex(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$");
            return regex.IsMatch(cpf);
        }

        private static bool IsCnpj(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return false;

            // Regex para validar CNPJ
            var regex = new Regex(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$");
            return regex.IsMatch(cnpj);
        }

        private static bool IsPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return false;

            // Regex para validar telefone
            var regex = new Regex(@"^\(\d{2}\) \d{4,5}\-\d{4}$");
            return regex.IsMatch(phone);
        }

        private static bool IsEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            // Regex para validar email
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email);
        }

        private static bool IsGuid(string guid)
        {
            if (string.IsNullOrEmpty(guid))
                return false;

            // Verifica se é um GUID
            return Guid.TryParse(guid, out _);
        }
    }
}
