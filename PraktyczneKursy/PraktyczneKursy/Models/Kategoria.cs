using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PraktyczneKursy.Models
{
    public class Kategoria
    {
        public int KategoriaId { get; set; }
        [Required(ErrorMessage = "Wprowadz nazwe kategorii")]
        [StringLength(100)]
        public string NazwaKategorii { get; set; }
        [Required(ErrorMessage = "Wprowadz opis kategorii")]
        public string OpisKategorii { get; set; }
        public string NazwaPlikuKategorii { get; set; }

        public ICollection<Kurs> Kursy { get; set; }
             
    }
}