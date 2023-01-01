using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atilim_Odev.Models.Siniflar
{
    public class Kimlik
    {
        [Key]
        public int Id { get; set; }
        public string TC_No { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string DogumYeri { get; set; }
        public DateTime DogumTarihi { get; set; }
        [ForeignKey("IletisimId")]
        public int IletisimId { get; set; }
        //nav
        public Iletisim Iletisim { get; set; }
    }
}
