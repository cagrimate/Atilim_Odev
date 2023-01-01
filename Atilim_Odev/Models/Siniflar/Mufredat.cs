using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Atilim_Odev.Models.Siniflar
{
    public class Mufredat
    {
        public Mufredat()
        {

        }
        [Key]
        public int Id { get; set; }
        public string MufredatAdi { get; set; }
        public virtual ICollection<Dersler> Dersler { get; set; }

    }
}
