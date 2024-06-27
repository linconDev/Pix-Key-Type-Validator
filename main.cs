using System;
using pixkeytypevalidator.Utils;

class Program
{
    public static void Main(string[] args)
    {
        string[] keys = {
            "123.456.789-00", // CPF
            "12.345.678/0001-00", // CNPJ
            "(12) 34567-8901", // PHONE
            "example@example.com", // EMAIL
            "d8d9f781-3c79-4d9c-9f96-3d84310b30e2" // GUID
        };

        foreach (var key in keys)
        {
            var tipoChave = ChaveValidator.ValidarChave(key);
            if (tipoChave.HasValue)
            {
                Console.WriteLine($"Chave: {key}, Tipo: {tipoChave.Value}");
            }
            else
            {
                Console.WriteLine($"Chave: {key}, Tipo: Inválido");
            }
        }
    }
}
