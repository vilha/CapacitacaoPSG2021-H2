using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encontro22POO
{
    public class PessoaJuridica : Cliente
    {
        private string razaoSocial;

        private string nomeFantazia;

        private string endereco;

        private string cnpj;

        private string inscEstadual;

        private string inscMunicipal;

        public string RazaoSocial { get => this.razaoSocial; set => this.razaoSocial = value; }

        public string NomeFantazia { get => this.nomeFantazia; set => this.nomeFantazia = value; }
        public string Endereco { get => this.endereco; set => this.endereco = value; }
        public string CNPJ { get => this.cnpj; set => this.cnpj = value; }
        public string InscEstadual { get => this.inscEstadual; set => this.inscEstadual = value; }
        public string InscMunicipal { get => this.inscMunicipal; set => this.inscMunicipal = value; }

        public PessoaJuridica() : base()
        { }

        public PessoaJuridica(
            int codigoCliente,
            string razaoSocial,
            string nomeFantazia,
            string endereco,
            string cnpj,
            string inscEstadual,
            string inscMunicipal,
            DateTime dataInclusao)
            : base(codigoCliente, dataInclusao)
        {
            this.razaoSocial = razaoSocial;
            this.nomeFantazia = nomeFantazia;
            this.endereco = endereco;
            this.cnpj = cnpj;
            this.inscEstadual = inscEstadual;
            this.inscMunicipal = inscMunicipal;
        }
    }
}