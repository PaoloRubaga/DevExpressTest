using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DataAccessLibrary
{
    public class OrdiniDataNoDapper : IOrdiniDataNoDapper
    {

        string ConnectionString = string.Empty;
        private readonly IConfiguration configuration;

        public OrdiniDataNoDapper(IConfiguration _configuration)
        {
            ConnectionString = _configuration.GetConnectionString("Default");
        }

        public Task DeleteOrdine(OrdineModel Ordine)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<OrdineModel>> GetOrdini()
        //{
        //    OrdineModel ordine = null;
        //    List<OrdineModel> listaOrdini = new List<OrdineModel>();
        //    string sql = "SELECT * FROM dbo.OrdiniTest";


        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {


        //        SqlCommand cmd = new SqlCommand("GetListaOrdini", connection);
        //        cmd.Parameters.Clear();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            ordine = new OrdineModel();
        //            ordine.Id = Convert.ToInt32(reader["Id"]);
        //            ordine.DataOrdine = Convert.ToDateTime(reader["DataOrdine"]);
        //            ordine.NomeProdotto = reader["NomeProdotto"].ToString();
        //            ordine.Stato = reader["Stato"].ToString();
        //            ordine.Citta = reader["Citta"].ToString();
        //            ordine.PrezzoUnitario = Convert.ToInt32(reader["PrezzoUnitario"]);
        //            ordine.Quantita = Convert.ToInt32(reader["Quantita"]);
        //            listaOrdini.Add(ordine);
        //        }

        //        reader.Close();
        //    }

        //    return listaOrdini;
        //}

        public async Task<List<OrdineModel>> GetOrdini()
        {
            List<OrdineModel> listaOrdini = new List<OrdineModel>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sql = "SELECT * FROM dbo.OrdiniTest";

                await connection.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        OrdineModel ordine = new OrdineModel();
                        ordine.Id = Convert.ToInt32(reader["Id"]);
                        ordine.DataOrdine = Convert.ToDateTime(reader["DataOrdine"]);
                        ordine.NomeProdotto = reader["NomeProdotto"].ToString();
                        ordine.Stato = reader["Stato"].ToString();
                        ordine.Citta = reader["Citta"].ToString();
                        ordine.PrezzoUnitario = Convert.ToInt32(reader["PrezzoUnitario"]);
                        ordine.Quantita = Convert.ToInt32(reader["Quantita"]);
                        listaOrdini.Add(ordine);
                    }
                    reader.Close();
                }
            }

            return listaOrdini;
        }

        public Task InsertOrdine(OrdineModel Ordine)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrdineModel>> RicercaOrdine(OrdineModel Ordine)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrdine(string id, OrdineModel Ordine)
        {
            throw new NotImplementedException();
        }
    }
}
