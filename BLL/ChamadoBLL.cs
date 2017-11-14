using DAL;
using DTO;
using DTO.Enums;
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
        public Guid Inserir(Guid idProduto, string descricao, StatusChamado status,int quantidade)
        {
            ChamadoDTO chamado = new ChamadoDTO();
            chamado.idChamado = Guid.NewGuid();
            chamado.dataCriacao = DateTime.Now;
            chamado.descricao = descricao;
            chamado.idProduto = idProduto;
            chamado.status = status;
            chamado.quantidade = quantidade;
            chamadoDAL.Inserir(chamado);
            return chamado.idChamado;
        }

        public void Deletar(Guid idChamado)
        {
            chamadoDAL.Deletar(idChamado);
        }

        public void Alterar(Guid idChamado, StatusChamado status, string motivo)
        {
            ChamadoDTO chamado = chamadoDAL.BuscarPorId(idChamado);
            chamado.status = status;
            chamado.motivo = motivo;
            chamado.dataEdicao = DateTime.Now;
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
