using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Atilim_Odev.Models.Siniflar
{
    public class Dersler
    {
        public Dersler()
        {
            Mufredat = new HashSet<Mufredat>();
        }
        [Key]
        public int Id { get; set; }
        public string DersKodu { get; set; }
        public string DersAdi { get; set; }
        public bool Durum { get; set; }
        public int Kredi { get; set; }

        public ICollection<Mufredat> Mufredat { get; set; }

    }
}
