using DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApiPickingDAL
    {
        public void EncaminharChamadoPicking(ChamadoDTO chamado)
        {
            var client = new RestClient("http://pickingapi.azurewebsites.net/api");

            var request = new RestRequest("chamado", Method.POST);
            request.AddParameter("idChamado", chamado.idChamado);
            request.AddParameter("idProduto", chamado.idProduto);
            request.AddParameter("quantidade", chamado.quantidade);
           
       
            client.ExecuteAsync(request, response => {
            });
        }
    }
}
