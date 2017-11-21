using DTO;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApiRhDAL
    {
        private struct employeeTypes
        {
            public string uid { get; set; }
        }
        private struct retorno
        {
            public int success { get; set; }
            public string description { get; set; }
        }
        public void EncaminharChamadoRh(ChamadoDTO chamado)
        {
            var client = new RestClient("http://sige-rh.herokuapp.com");

            var request = new RestRequest("request", Method.POST);
            List<employeeTypes> lista = new List<employeeTypes>();

            for (int i = 0; i < chamado.quantidade; i++)
            {
                employeeTypes employee = new employeeTypes();
                employee.uid = chamado.idProduto.ToString();
                lista.Add(employee);
            }

            var valor = JsonConvert.SerializeObject(new { employeeTypes = lista.ToArray() });
            request.AddParameter("application/json; charset=utf-8", valor, ParameterType.RequestBody);

            client.ExecuteAsync(request, response =>
            {
                var ret = JsonConvert.DeserializeObject<retorno>(response.Content);

                if (ret.success == 1)
                    chamado.status = DTO.Enums.StatusChamado.Fechado_RH;
                else
                    chamado.status = DTO.Enums.StatusChamado.Cancelado_RH;

                chamado.motivo = ret.description;
                new ChamadoDAL().Alterar(chamado);
            });
        }
    }
}
