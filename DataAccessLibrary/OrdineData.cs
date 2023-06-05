using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public class OrdineData : IOrdineData
    {
        private readonly ISqlDataAccess _db;

        public OrdineData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<OrdineModel>> GetOrdini()
        {
            string sql = "SELECT * FROM dbo.OrdiniTest";

            return _db.LoadData<OrdineModel, dynamic>(sql, new { });
        }

        public Task InsertOrdine(OrdineModel Ordine)
        {
            string sql = @"INSERT INTO dbo.OrdiniTest (DataOrdine, NomeProdotto, Stato, Citta, PrezzoUnitario, Quantita)
                           VALUES (@DataOrdine, @NomeProdotto, @Stato, @Citta, @PrezzoUnitario, @Quantita);";

            return _db.SaveData(sql, Ordine);
        }

        public Task UpdateOrdine(string id, OrdineModel Ordine)
        {
            string sql = $@"UPDATE dbo.OrdiniTest 
                            SET DataOrdine = @DataOrdine, NomeProdotto= @NomeProdotto, Stato= @Stato, Citta= @Citta, PrezzoUnitario= @PrezzoUnitario, Quantita= @Quantita
                            WHERE Id = {id}
                           ;";

            return _db.SaveData(sql, Ordine);
        }

        public Task DeleteOrdine(OrdineModel Ordine)
        {
            string sql = @"DELETE FROM dbo.OrdiniTest WHERE ID = @Id;";

            return _db.SaveData(sql, Ordine);
        }

        public Task<List<OrdineModel>> RicercaOrdine(OrdineModel Ordine)
        {
            string sql = @"SELECT * 
                        FROM dbo.Dispositivi 
                        WHERE 1=1";

            //if (!string.IsNullOrEmpty(dispositivo.Matricola))
            //{
            //    sql += " AND Matricola = @Matricola";
            //}

            //if (!string.IsNullOrEmpty(dispositivo.Descrizione))
            //{
            //    sql += " AND Descrizione = @Descrizione";
            //}

            //if (!string.IsNullOrEmpty(dispositivo.Modello))
            //{
            //    sql += " AND Modello = @Modello";
            //}

            return _db.LoadData<OrdineModel, dynamic>(sql, Ordine);
        }




    }
}

