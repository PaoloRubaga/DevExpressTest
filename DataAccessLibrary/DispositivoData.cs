using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public class DispositivoData : IDispositivoData
    {
        private readonly ISqlDataAccess _db;

        public DispositivoData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<DispositivoModel>> GetDispositivo()
        {
            string sql = "SELECT * FROM dbo.Dispositivi";

            return _db.LoadData<DispositivoModel, dynamic>(sql, new { });
        }

        public Task InsertDispositivo(DispositivoModel dispositivo)
        {
            string sql = @"INSERT INTO dbo.Dispositivi (Matricola, Descrizione, Modello)
                           VALUES (@Matricola, @Descrizione, @Modello);";

            return _db.SaveData(sql, dispositivo);
        }

        public Task UpdateDispositivo(string matricolaPk, DispositivoModel dispositivoNuovo)
        {
            string sql = $@"UPDATE dbo.Dispositivi 
                            SET Matricola = @Matricola, Descrizione = @Descrizione, Modello = @Modello
                            WHERE Matricola = '{matricolaPk}'
                           ;";

            return _db.SaveData(sql, dispositivoNuovo);
        }

        public Task DeleteDispositivo(DispositivoModel dispositivo)
        {
            string sql = @"DELETE FROM dbo.Dispositivi WHERE Matricola = @Matricola;";

            return _db.SaveData(sql, dispositivo);
        }

        public Task<List<DispositivoModel>> RicercaDispositivi(DispositivoModel dispositivo)
        {
            string sql = @"SELECT * 
                        FROM dbo.Dispositivi 
                        WHERE 1=1";

            if (!string.IsNullOrEmpty(dispositivo.Matricola))
            {
                sql += " AND Matricola = @Matricola";
            }

            if (!string.IsNullOrEmpty(dispositivo.Descrizione))
            {
                sql += " AND Descrizione = @Descrizione";
            }

            if (!string.IsNullOrEmpty(dispositivo.Modello))
            {
                sql += " AND Modello = @Modello";
            }

            return _db.LoadData<DispositivoModel, dynamic>(sql, dispositivo);
        }

        public Task AggiungiPdf(byte[] bytes)
        {
            string sql = @"INSERT INTO dbo.ReportPdfTest (ReportPdf) VALUES (@Data);";

            var parameters = new { Data = bytes };

            return _db.SaveDataFile(sql, parameters);
        }

        public Task<byte[]> GetFile()
        {
            string sql = "SELECT * FROM dbo.ReportPdfTest WHERE Id=1";

            return _db.LoadDataFile<dynamic>(sql);
        }



    }
}
