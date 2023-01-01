using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atilim_Odev.Models.Siniflar
{
    public class Ogrenci
    {
        [Key]
        public int Id { get; set; }
        public int Ogr_No { get; set; }
        [ForeignKey("KimlikId")]
        public int KimlikId { get; set; }
        [ForeignKey("MufredatId")]
        public int MufredatId { get; set; }
        //nav
        public Mufredat Mufredat { get; set; }
        public Kimlik Kimlik { get; set; }


    }
}
