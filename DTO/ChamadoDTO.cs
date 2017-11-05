using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;
using System.Threading.Tasks;

namespace DTO
{
    [Table("chamado")]
    public class ChamadoDTO
    {
        [Key]
        public Guid idChamado { get; set; }

        /// <summary>
        /// Codigo do produto obrigatorio em todas as requests
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required]
        public Guid idProduto { get; set; }

        public string descricao { get; set; }

        /// <summary>
        /// Status disponíveis
        /// Aberto_RH = 0,
        ///Fechado_RH = 1,
        /// Aberto_PIK = 2,
        ///Fechado_PIK = 3
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required]
        public StatusChamado status { get; set; }
    }
}
