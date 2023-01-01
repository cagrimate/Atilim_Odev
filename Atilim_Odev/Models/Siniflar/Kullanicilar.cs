using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atilim_Odev.Models.Siniflar
{
    public class Kullanicilar
    {
        public Kullanicilar()
        {
            Roller = new HashSet<Rol>();

        }

        [Key]
        public int Id { get; set; }
        public string Kullanici_Adi { get; set; }
        public string Sifre { get; set; }
        public int Tur { get; set; }

        [ForeignKey("kimlikId")]
        public int kimlikId { get; set; }
        public Kimlik kimlik { get; set; }

        //nav
        public ICollection<Rol> Roller { get; set; }

    }
}
