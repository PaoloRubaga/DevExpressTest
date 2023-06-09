﻿using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IOrdiniDataNoDapper
    {
        Task<List<OrdineModel>> GetOrdini();
        Task<OrdineModel> GetOrdineById(int id);
        Task InsertOrdine(OrdineModel Ordine);
        Task UpdateOrdine(string id, OrdineModel Ordine);
        Task DeleteOrdine(OrdineModel Ordine);
        Task<List<OrdineModel>> RicercaOrdine(OrdineModel Ordine);
        Task<List<StatoOrdineModel>> GetStatoOrdineById();
    }
}
