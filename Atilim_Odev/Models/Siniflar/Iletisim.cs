using System.ComponentModel.DataAnnotations;

namespace Atilim_Odev.Models.Siniflar
{
    public class Iletisim
    {
        [Key]
        public int Id { get; set; }
        public string Adres { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Email { get; set; }
        public string GSM { get; set; }
    }
}
