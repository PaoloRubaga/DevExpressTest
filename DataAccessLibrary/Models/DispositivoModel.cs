using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models
{
    public class DispositivoModel
    {
        //public string Matricola { get; set; }
        //public string Descrizione { get; set; }
        //public string Modello { get; set; }

        [Required(ErrorMessage = "Campo Matricola richiesto")]
        [StringLength(15, ErrorMessage = "Matricola troppo lunga")]
        [MinLength(5, ErrorMessage = "Matricola troppo corta")]
        public string Matricola { get; set; }
        [Required(ErrorMessage = "Campo Descrizione richiesto")]
        [StringLength(15, ErrorMessage = "Descrizione troppo lunga")]
        [MinLength(5, ErrorMessage = "Descrizione troppo corta")]
        public string Descrizione { get; set; }
        [Required(ErrorMessage = "Modello richiesto")]
        [StringLength(10, ErrorMessage = "Modello troppo lunga")]
        [MinLength(3, ErrorMessage = "Modello troppo corta")]
        public string Modello { get; set; }

        public string Text => $"{Matricola} {Descrizione} {Modello}";
    }
}
