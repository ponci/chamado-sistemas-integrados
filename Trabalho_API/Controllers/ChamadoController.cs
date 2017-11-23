using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using Trabalho_API.Model;

namespace Trabalho_API.Controllers
{
    [Route("chamado")]
    public class ChamadoController : ApiController
    {
        /// <summary>
        /// Lista todos os chamados
        /// </summary>
        /// <returns>Lista de chamados</returns>
        public IEnumerable<ChamadoDTO> Get()
        {
            return new ChamadoBLL().BuscarTodos();
        }
       /// <summary>
       /// Método para obter um chamado
       /// </summary>
       /// <param name="idChamado">Codigo do chamado</param>
       /// <returns>Objeto chamado</returns>
        [Route("{idchamado}")]
        public ChamadoDTO Get(Guid idChamado)
        {
            return new ChamadoBLL().BuscarPorId(idChamado);
        }

  /// <summary>
  /// Método para criar o chamado
  /// </summary>
  /// <param name="chamado">Necessario informar obrigatoriamente o codigo do produto e status inicial</param>
  /// <returns>Guid do chamado criado</returns>
        public Guid Post([FromBody]InserirChamadoModel chamado)
        {
            return new ChamadoBLL().Inserir(chamado.idProduto, chamado.descricao, chamado.status, chamado.quantidade);
        }

        /// <summary>
        /// Método para alterar o chamado
        /// </summary>
        /// <param name="idChamado"></param>
        /// <param name="chamado">Objeto com as modificações realizadas</param>
        public void Put(Guid idChamado, [FromBody]AlterarChamadoModel chamado)
        {
            new ChamadoBLL().Alterar(idChamado, chamado.status, chamado.motivo);
        }


        public void Delete(Guid idChamado)
        {
            new ChamadoBLL().Deletar(idChamado);
        }
        /// <summary>
        /// Metodo para gerar o Relatorio
        /// </summary>
        /// <returns></returns>
          [Route("relatorio")]
        public HttpResponseMessage GerarPdf()
        {         
            byte[] buffer = new ChamadoBLL().GerarPdf();
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
             response.Content = new ByteArrayContent(buffer);
             response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
             response.Content.Headers.ContentDisposition.FileName = "RelatorioChamado.pdf";
             response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
             response.Content.Headers.ContentLength = buffer.Length;
            response.Headers.AcceptRanges.Add("bytes");
            return response;

        }
    }
}
