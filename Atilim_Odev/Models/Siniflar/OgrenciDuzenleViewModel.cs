using System;
using System.Collections.Generic;

namespace Atilim_Odev.Models.Siniflar
{
    public class OgrenciDuzenleViewModel
    {
        public int? Id { get; set; }
        public string? TC_No { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? DogumYeri { get; set; }
        public DateTime? DogumTarihi { get; set; }

        public string? Adres { get; set; }
        public string? Il { get; set; }
        public string? Ilce { get; set; }
        public string? Email { get; set; }
        public string? GSM { get; set; }
        public int? Ogr_No { get; set; }
        public int? MufredatId { get; set; }
        public List<Mufredat>? Mufredatlar { get; set; }
    }
}

