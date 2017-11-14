using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabalho_API.Model
{
    public class AlterarChamadoModel
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
        public StatusChamado status { get; set; }
        public string motivo { get; set; }
    }
}