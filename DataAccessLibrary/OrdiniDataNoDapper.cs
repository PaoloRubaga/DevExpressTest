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

        public async Task DeleteOrdine(OrdineModel Ordine)
        {
            string sql = @"DELETE FROM dbo.OrdiniTest WHERE ID = @Id;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("Id", Ordine.Id);
                    cmd.ExecuteNonQuery();

                }

            }
        }

        public async Task<OrdineModel> GetOrdineById(int id)
        {
            string sql = @"SELECT DataOrdine, NomeProdotto, Stato, Citta, PrezzoUnitario, Quantita 
                            FROM dbo.OrdiniTest 
                            WHERE ID = @Id;";
            OrdineModel ordine = new OrdineModel();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                await connection.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ordine.DataOrdine = Convert.ToDateTime(reader["DataOrdine"]);
                        ordine.NomeProdotto = reader["NomeProdotto"].ToString();
                        ordine.Stato = reader["Stato"].ToString();
                        ordine.Citta = reader["Citta"].ToString();
                        ordine.PrezzoUnitario = Convert.ToInt32(reader["PrezzoUnitario"]);
                        ordine.Quantita = Convert.ToInt32(reader["Quantita"]);
                    }
                }
            }

            return ordine;
        }


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

        public async Task InsertOrdine(OrdineModel Ordine)
        {
            string sql = @"INSERT INTO dbo.OrdiniTest (DataOrdine, NomeProdotto, Stato, Citta, PrezzoUnitario, Quantita)
                           VALUES (@DataOrdine, @NomeProdotto, @Stato, @Citta, @PrezzoUnitario, @Quantita);";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("DataOrdine", Ordine.DataOrdine);
                    cmd.Parameters.AddWithValue("NomeProdotto", Ordine.NomeProdotto);
                    cmd.Parameters.AddWithValue("Stato", Ordine.Stato);
                    cmd.Parameters.AddWithValue("Citta", Ordine.Citta);
                    cmd.Parameters.AddWithValue("PrezzoUnitario", Ordine.PrezzoUnitario);
                    cmd.Parameters.AddWithValue("Quantita", Ordine.Quantita);
                    cmd.ExecuteNonQuery();

                }

            }

        }

        public Task<List<OrdineModel>> RicercaOrdine(OrdineModel Ordine)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateOrdine(string id, OrdineModel Ordine)
        {
            string sql = $@"UPDATE dbo.OrdiniTest 
                            SET DataOrdine = @DataOrdine, NomeProdotto= @NomeProdotto, Stato= @Stato, Citta= @Citta, PrezzoUnitario= @PrezzoUnitario, Quantita= @Quantita
                            WHERE Id = {id}
                           ;";


            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("DataOrdine", Ordine.DataOrdine);
                    cmd.Parameters.AddWithValue("NomeProdotto", Ordine.NomeProdotto);
                    cmd.Parameters.AddWithValue("Stato", Ordine.Stato);
                    cmd.Parameters.AddWithValue("Citta", Ordine.Citta);
                    cmd.Parameters.AddWithValue("PrezzoUnitario", Ordine.PrezzoUnitario);
                    cmd.Parameters.AddWithValue("Quantita", Ordine.Quantita);
                    cmd.ExecuteNonQuery();

                }

            }
        }
    }
}
