using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IDispositivoData
    {
        Task<List<DispositivoModel>> GetDispositivo();
        Task InsertDispositivo(DispositivoModel dispositivo);
        Task UpdateDispositivo(string matricolaPk, DispositivoModel dispositivoNuovo);
        Task DeleteDispositivo(DispositivoModel dispositivo);
        Task<List<DispositivoModel>> RicercaDispositivi(DispositivoModel dispositivo);
        Task AggiungiPdf(byte[] bytes);
        Task<byte[]> GetFile();


    }
}