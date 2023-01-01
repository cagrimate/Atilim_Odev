using Microsoft.EntityFrameworkCore;

namespace Atilim_Odev.Models.Siniflar
{
    public class AtilimContext : DbContext
    {
        public AtilimContext(DbContextOptions<AtilimContext> options) : base(options)
        {

        }
        public DbSet<Ders_Kayit> Ders_Kayit { get; set; }
        public DbSet<Dersler> Dersler { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
        public DbSet<Kimlik> Kimlik { get; set; }
        public DbSet<Kullanicilar> Kullanicilar { get; set; }
        public DbSet<Mufredat> Mufredatlar { get; set; }
        public DbSet<Ogrenci> Ogrenci { get; set; }
        public DbSet<Rol> Roller { get; set; }
    }
}
