using Atacado.POCO.Model;
using Atacado.Service.Estoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AtacadoRestApi.Controllers
{
    /// <summary>
    /// Serviços de Regiao utilizando disegn patterns.
    /// </summary>
    [RoutePrefix("Regiao")]
    public class RegiaoController : BaseController
    {
        private RegiaoService servico;

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public RegiaoController() : base()
        {
            this.servico = new RegiaoService(this.contexto);
        }

        /// <summary>
        /// Obter registro por chave primaria.
        /// </summary>
        /// <param name="id">Chave primaria</param>
        /// <returns></returns>
        [ResponseType(typeof(RegiaoPoco))]
        [HttpGet]
        public RegiaoPoco Get([FromUri] int id)
        {
            return this.servico.Obter(id);
        }

        /// <summary>
        /// Obter todos os registros.
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(List<RegiaoPoco>))]
        [HttpGet]
        public List<RegiaoPoco> Get()
        {
            return this.servico.ObterTodos().ToList();
        }

        /// <summary>
        /// Incluir novo registro.
        /// </summary>
        /// <param name="poco">Objeto a ser incluso.</param>
        /// <returns></returns>
        public RegiaoPoco Post([FromBody] RegiaoPoco poco)
        {
            return this.servico.Incluir(poco);
        }

        /// <summary>
        /// Atualizar um registro.
        /// </summary>
        /// <param name="poco">Objeto a ser atualizado.</param>
        /// <returns></returns>
        public RegiaoPoco Put([FromBody] RegiaoPoco poco)
        {
            return this.servico.Atualizar(poco);
        }

        /// <summary>
        /// Excluir um registro.
        /// </summary>
        /// <param name="id">Chave primaria</param>
        /// <returns></returns>
        public RegiaoPoco Delete([FromUri] int id)
        {
            return this.servico.Excluir(id);
        }

        /// <summary>
        /// Dispose do serviço.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            this.servico = null;
            base.Dispose(disposing);
        }

        /*
        /// <summary>
        /// Serviços para a tabela região
        /// </summary>
        [RoutePrefix("AtacadoRestApi")]
        public class RegiaoController : BaseController
        {
            /// <summary>
            /// Chamado do controlador base
            /// </summary>
            public RegiaoController() : base() { }

            /// <summary>
            /// Obter todos os registros da tabela.
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            [ResponseType(typeof(List<RegiaoPoco>))]
            public List<RegiaoPoco> Get()
            {
                //List<RegiaoPoco> regioesPoco = (
                //    from novo in contexto.Regioes
                //    select new RegiaoPoco() {
                //        RegiaoID = novo.RegiaoID,
                //        Descricao = novo.Descricao,
                //        SiglaRegiao = novo.SiglaRegiao,
                //        DataInclusao = novo.datainsert
                //    }).ToList();

                //Versão LINQ to Entities
                List<RegiaoPoco> regioesPoco =
                    this.contexto.Regioes
                    .Select(novo => new RegiaoPoco()
                    {
                        RegiaoID = novo.RegiaoID,
                        Descricao = novo.Descricao,
                        SiglaRegiao = novo.SiglaRegiao,
                        DataInclusao = novo.datainsert
                    }).ToList();

                //MODO ESPARTANO
                //List<Regiao> regioes = contexto.Regioes.ToList();
                //List<RegiaoPoco> regioesPoco = new List<RegiaoPoco>();
                //foreach (var item in regioes)
                //{
                //    RegiaoPoco novo = new RegiaoPoco();
                //    novo.RegiaoID = item.RegiaoID;
                //    novo.Descricao = item.Descricao;
                //    novo.SiglaRegiao = item.SiglaRegiao;
                //    novo.DataInclusao = item.datainsert;
                //    regioesPoco.Add(novo);
                //}

                return regioesPoco;
            }

            /// <summary>
            /// Obter um registro, baseado na chave primaria.
            /// </summary>
            /// <param name="id">Chave primaria do registro</param>
            /// <returns></returns>
            [HttpGet]
            [ResponseType(typeof(RegiaoPoco))]
            public RegiaoPoco Get([FromUri] int id)
            {
                RegiaoPoco regiaoPoco = (
                    from novo in this.contexto.Regioes
                    where novo.RegiaoID == id
                    select new RegiaoPoco()
                    {
                        RegiaoID = novo.RegiaoID,
                        Descricao = novo.Descricao,
                        SiglaRegiao = novo.SiglaRegiao,
                        DataInclusao = novo.datainsert
                    }).FirstOrDefault();

                //Modo LINQ to Entity
                //RegiaoPoco regiaoPoco = contexto.Regioes
                //    .Where(reg => reg.RegiaoID == id)
                //    .Select(novo => new RegiaoPoco() {
                //        RegiaoID = novo.RegiaoID,
                //        Descricao = novo.Descricao,
                //        SiglaRegiao = novo.SiglaRegiao,
                //        DataInclusao = novo.datainsert
                //    }).FirstOrDefault();

                //Modo espartano - pratico
                //Regiao regiao = contexto.Regioes.SingleOrDefault(reg => reg.RegiaoID == id);
                //RegiaoPoco regiaoPoco = new RegiaoPoco()
                //{
                //    RegiaoID = regiao.RegiaoID,
                //    Descricao = regiao.Descricao,
                //    SiglaRegiao = regiao.SiglaRegiao,
                //    DataInclusao = regiao.datainsert
                //};

                return regiaoPoco;
            }

            /// <summary>
            /// Criar registro na tabela
            /// </summary>
            /// <param name="poco">Objeto que sera incluido na tabela</param>
            /// <returns></returns>
            [HttpPost]
            [ResponseType(typeof(RegiaoPoco))]
            public RegiaoPoco Post([FromBody] RegiaoPoco poco)
            {
                Regiao regiao = new Regiao();

                regiao.Descricao = poco.Descricao;
                regiao.SiglaRegiao = poco.SiglaRegiao;
                regiao.datainsert = DateTime.Now;

                this.contexto.Regioes.Add(regiao);
                this.contexto.SaveChanges();

                int id = regiao.RegiaoID;
                return this.Get(id);
            }

            /// <summary>
            /// Atualizar registro na tabela
            /// </summary>
            /// <param name="id">Chave primaria do registro</param>
            /// <param name="poco">Objeto que sera atualizado</param>
            /// <returns></returns>
            [HttpPut]
            [ResponseType(typeof(RegiaoPoco))]
            public RegiaoPoco Put([FromUri] int id, [FromBody] RegiaoPoco poco)
            {
                Regiao regiao = this.contexto.Regioes.SingleOrDefault(reg => reg.RegiaoID == id);

                regiao.Descricao = poco.Descricao;
                regiao.SiglaRegiao = poco.SiglaRegiao;
                this.contexto.Entry<Regiao>(regiao).State = System.Data.Entity.EntityState.Modified;
                this.contexto.SaveChanges();

                return this.Get(id);

            }

            /// <summary>
            /// Excluir registro da tabela
            /// </summary>
            /// <param name="id">Chave primaria do registro</param>
            /// <returns></returns>
            [HttpDelete]
            [ResponseType(typeof(RegiaoPoco))]
            public RegiaoPoco Delete([FromUri] int id)
            {
                Regiao regiao = this.contexto.Regioes.SingleOrDefault(reg => reg.RegiaoID == id);
                this.contexto.Entry<Regiao>(regiao).State = System.Data.Entity.EntityState.Deleted;
                this.contexto.SaveChanges();
                return this.Get(id);
            }
        */
    }
}
