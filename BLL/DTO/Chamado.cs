using BLL.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ChamadoDTO
    {
        public Guid idChamado { get; set; }
        public Guid idProduto { get; set; }
        public string descricao { get; set; }
        public StatusChamado status { get; set; }
    }
}
