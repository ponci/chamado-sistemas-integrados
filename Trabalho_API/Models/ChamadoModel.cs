using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trabalho_API.Models.Enums;

namespace Trabalho_API.Models
{
    public class ChamadoModel
    {
        public Guid idChamado { get; set; }
        public Guid idProduto { get; set; }
        public string descricao { get; set; }
        public StatusChamado status { get; set; }
    }
}