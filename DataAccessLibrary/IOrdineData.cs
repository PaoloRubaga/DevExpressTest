using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IOrdineData
    {
        Task<List<OrdineModel>> GetOrdini();
        Task InsertOrdine(OrdineModel Ordine);
        Task UpdateOrdine(string id, OrdineModel Ordine);
        Task DeleteOrdine(OrdineModel Ordine);
        Task<List<OrdineModel>> RicercaOrdine(OrdineModel Ordine);
    }
}
