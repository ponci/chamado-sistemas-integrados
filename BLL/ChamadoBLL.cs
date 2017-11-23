using DAL;
using DTO;
using DTO.Enums;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
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

            if (chamado.status == StatusChamado.Aberto_PIK)
                new ApiPickingDAL().EncaminharChamadoPicking(chamado);

            if (chamado.status == StatusChamado.Aberto_RH)
                new ApiRhDAL().EncaminharChamadoRh(chamado);

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

        public byte[] GerarPdf()
        {
          List<ChamadoDTO> lista = chamadoDAL.BuscarTodos().ToList();
            Document doc = new Document(PageSize.LETTER, 50, 50, 50, 50);

            using (MemoryStream output = new MemoryStream())
            {
                PdfWriter wri = PdfWriter.GetInstance(doc, output);
                doc.Open();

                Paragraph header = new Paragraph("Relatório Chamados") { Alignment = Element.ALIGN_CENTER };
                Paragraph paragraph = new Paragraph("Chamados em aberto para RH: " + lista.Count(x=> x.status == StatusChamado.Aberto_RH));
                Paragraph paragraph1 = new Paragraph("Chamados em aberto para Picking: " + lista.Count(x => x.status == StatusChamado.Aberto_PIK));
                Paragraph paragraph2 = new Paragraph("Chamados em cancelados RH: " + lista.Count(x => x.status == StatusChamado.Cancelado_RH));
                Paragraph paragraph3 = new Paragraph("Chamados em cancelados Picking: " + lista.Count(x => x.status == StatusChamado.Cancelado_PIK));
                Paragraph paragraph4 = new Paragraph("Chamados em fechados RH: " + lista.Count(x => x.status == StatusChamado.Fechado_RH));
                Paragraph paragraph5 = new Paragraph("Chamados em fechados Picking: " + lista.Count(x => x.status == StatusChamado.Fechado_PIK));
                Paragraph paragraph6 = new Paragraph("Total chamados em aberto: " + (lista.Count(x => x.status == StatusChamado.Aberto_RH) + lista.Count(x => x.status == StatusChamado.Aberto_PIK)));
                Paragraph paragraph7 = new Paragraph("Total chamados fechados: " + (lista.Count(x => x.status == StatusChamado.Fechado_PIK) + lista.Count(x => x.status == StatusChamado.Fechado_RH)));
                Paragraph paragraph8 = new Paragraph("Total chamados: " + lista.Count());
                Paragraph espaco = new Paragraph("");
                // Phrase phrase = new Phrase("This is a phrase but testing some formatting also. \nNew line here.");
                //   Chunk chunk = new Chunk("This is a chunk.");

                doc.Add(header);
                doc.Add(espaco);
                doc.Add(paragraph);
                doc.Add(espaco);
                doc.Add(paragraph1);
                doc.Add(espaco);
                doc.Add(paragraph2);
                doc.Add(espaco);
                doc.Add(paragraph3);
                doc.Add(espaco);
                doc.Add(paragraph4);
                doc.Add(espaco);
                doc.Add(paragraph5);
                doc.Add(espaco);
                doc.Add(paragraph6);
                doc.Add(espaco);
                doc.Add(paragraph7);
                doc.Add(espaco);
                doc.Add(paragraph8);
                ////doc.Add(phrase7);
                // doc.Add(chunk);

                doc.Close();
                return output.ToArray();
            }
        }
    }
}
