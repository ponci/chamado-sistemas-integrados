using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabalho_API.Model
{
    public class InserirChamadoModel
    {
        /// <summary>
        /// Status disponíveis
        /// Aberto_RH = 0,
        ///Fechado_RH = 1,
        /// Aberto_PIK = 2,
        ///Fechado_PIK = 3,
        ///Cancelado_RH = 4,
        ///Caneclado_PIK = 5
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required]
        public StatusChamado status { get; set; }
        /// <summary>
        /// Codigo do produto
        /// </summary>
         [System.ComponentModel.DataAnnotations.Required]
        public Guid idProduto { get; set; }
        public string descricao { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public int quantidade { get; set; }
    }
}