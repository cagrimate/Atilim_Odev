using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Atilim_Odev.Models.Siniflar
{
    public class Rol
    {
        public Rol()
        {

        }

        [Key]
        public int Id { get; set; }
        public string Rol_Adi { get; set; }
        public virtual ICollection<Kullanicilar> Kullanicilar { get; set; }

    }
}
