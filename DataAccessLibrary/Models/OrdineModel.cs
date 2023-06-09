﻿namespace DataAccessLibrary.Models
{
    public class OrdineModel
    {
        public int Id { get; set; }
        public DateTime DataOrdine { get; set; } = DateTime.Now;
        public string NomeProdotto { get; set; }
        public string Stato { get; set; }
        public string Citta { get; set; }
        public int PrezzoUnitario { get; set; }
        public int Quantita { get; set; }
        public int IdStatoOrdine { get; set; }
    }
}
