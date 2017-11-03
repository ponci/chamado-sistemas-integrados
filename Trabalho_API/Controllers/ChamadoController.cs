using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace Trabalho_API.Controllers
{
    [Route("chamado")]
    public class ChamadoController : ApiController
    {

        public IEnumerable<ChamadoDTO> Get()
        {
            return new ChamadoBLL().BuscarTodos();
        }

        [Route("{idchamado}")]
        public ChamadoDTO Get(Guid idChamado)
        {
            return new ChamadoBLL().BuscarPorId(idChamado);
        }

  
        public void Post([FromBody]ChamadoDTO chamado)
        {
            new ChamadoBLL().Inserir(chamado);
        }


        public void Put(Guid idChamado, [FromBody]ChamadoDTO chamado)
        {
            chamado.idChamado = idChamado;
            new ChamadoBLL().Alterar(chamado);
        }


        public void Delete(Guid idChamado)
        {
            new ChamadoBLL().Deletar(idChamado);
        }
    }
}
