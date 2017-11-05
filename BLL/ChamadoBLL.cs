using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChamadoBLL
    {
        public ChamadoDAL chamadoDAL;
        public ChamadoBLL()
        {
            chamadoDAL = new ChamadoDAL();
        }
        public Guid Inserir(ChamadoDTO chamado)
        {
            chamado.idChamado = Guid.NewGuid();
            chamadoDAL.Inserir(chamado);
            return chamado.idChamado;
        }

        public void Deletar(Guid idChamado)
        {
            chamadoDAL.Deletar(idChamado);
        }

        public void Alterar(ChamadoDTO chamado)
        {
            chamadoDAL.Alterar(chamado);
        }

        public IEnumerable<ChamadoDTO> BuscarTodos()
        {
            return chamadoDAL.BuscarTodos();
        }

        public ChamadoDTO BuscarPorId(Guid idChamado)
        {
            return chamadoDAL.BuscarPorId(idChamado);
        }
    }
}
