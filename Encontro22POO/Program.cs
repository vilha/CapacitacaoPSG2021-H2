using System;

namespace Encontro22POO
{
    class Program
    {
        static void Main(string[] args)
        {
            PessoaFisica teste1 = new PessoaFisica();
            teste1.CodCliente = 1;
            teste1.Nome = "Luiz";
            teste1.CPF = "123456";
            teste1.DataInclusao = DateTime.Now;
            teste1.Endereco = "Rua X, 123";
            teste1.RG = "123456";
            teste1.TituloEleitor = "123456";

            PessoaFisica teste2 = new PessoaFisica()
            {
                CodCliente = 2,
                Nome = "João",
                CPF = "456789",
                DataInclusao = DateTime.Now,
                Endereco = "Rua Y, 456",
                RG = "456789",
                TituloEleitor = "456789"
            };

            PessoaFisica teste3 = new PessoaFisica(
                3,
                "Paulo",
                "Rua Z, 789",
                "987654",
                "987654",
                "987654",
                DateTime.Now
                );

            PessoaJuridica teste4 = new PessoaJuridica();
            teste4.CodCliente = 4;
            teste4.RazaoSocial = "Mercado com capa";
            teste4.NomeFantazia = "Super Mercado";
            teste4.CNPJ = "13579";
            teste4.DataInclusao = DateTime.Now;
            teste4.Endereco = "Rua A, 123";
            teste4.InscEstadual = "13579";
            teste4.InscMunicipal = "13579";

            PessoaJuridica teste5 = new PessoaJuridica()
            {
                CodCliente = 5,
                RazaoSocial = "Test5",
                NomeFantazia = "Test5",
                CNPJ = "02468",
                DataInclusao = DateTime.Now,
                Endereco = "Rua B, 456",
                InscEstadual = "02468",
                InscMunicipal = "02468"
            };

            PessoaJuridica teste6 = new PessoaJuridica(
                6,
                "Test6",
                "Test6",
                "Rua C, 789",
                "11235",
                "11235",
                "11235",
                DateTime.Now
                );
        }
    }
}