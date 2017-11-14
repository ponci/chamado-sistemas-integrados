using DAL.Base;
using Dapper;
using Dapper.Contrib.Extensions;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChamadoDAL
    {
        private IDbConnection conexao;

        public ChamadoDAL()
        {
            conexao = Conexao.Connection;
        }

        public void Inserir(ChamadoDTO chamado)
        {
            using (IDbConnection dbConnection = conexao)
            {
                dbConnection.Open();
                using (var dbContextTransaction = dbConnection.BeginTransaction())
                {
                    dbConnection.Insert(chamado, dbContextTransaction);
                    dbContextTransaction.Commit();
                }
                dbConnection.Close();
            }
        }

        public void Deletar(Guid idChamado)
        {
            using (IDbConnection dbConnection = conexao)
            {
                dbConnection.Open();
                using (var dbContextTransaction = dbConnection.BeginTransaction())
                {
                    dbConnection.Delete(new ChamadoDTO() { idChamado = idChamado }, dbContextTransaction);
                    dbContextTransaction.Commit();
                }
                dbConnection.Close();
            }
        }

        public void Alterar(ChamadoDTO chamado)
        {
            using (IDbConnection dbConnection = Conexao.Connection)
            {
                dbConnection.Open();
                using (var dbContextTransaction = dbConnection.BeginTransaction())
                {
                    dbConnection.Update(chamado, dbContextTransaction);
                    dbContextTransaction.Commit();
                }
                dbConnection.Close();
            }
        }

        public IEnumerable<ChamadoDTO> BuscarTodos()
        {
            using (IDbConnection dbConnection = conexao)
            {
                return dbConnection.Query<ChamadoDTO>("SELECT * FROM chamado");
            }
        }

        public ChamadoDTO BuscarPorId(Guid idChamado)
        {
            using (IDbConnection dbConnection = conexao)
            {
                string sQuery = "SELECT * FROM chamado"
                               + " WHERE idChamado = @idChamado";
                return dbConnection.Query<ChamadoDTO>(sQuery, new { idChamado = idChamado }).FirstOrDefault();
            }
        }
    }
}
