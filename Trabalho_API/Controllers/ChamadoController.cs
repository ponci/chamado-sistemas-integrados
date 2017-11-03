using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace Trabalho_API.Controllers
{
    public class ChamadoController : ApiController
    {
        // GET api/values
        public IEnumerable<ChamadoDTO> GetAll()
        {
            return null;
        }

        // GET api/values/5
        public ChamadoDTO Get(Guid idChamado)
        {
            return new ChamadoDTO();
        }

        // POST api/values
        public void Post([FromBody]ChamadoDTO chamado)
        {
        }

        // PUT api/values/5
        public void Put(Guid idChamado, [FromBody]ChamadoDTO chamado)
        {
        }

        // DELETE api/values/5
        public void Delete(Guid idChamado)
        {
        }
    }
}
