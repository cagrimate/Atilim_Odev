using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atilim_Odev.Models.Siniflar
{
    public class Ders_Kayit
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("OgrenciId")]
        public int OgrenciId { get; set; }
        [ForeignKey("DersId")]
        public int DersId { get; set; }
        public DateTime CreatedDate { get; set; }
        //nav
        public Ogrenci Ogrenci { get; set; }
        public Dersler Ders { get; set; }
    }
}
