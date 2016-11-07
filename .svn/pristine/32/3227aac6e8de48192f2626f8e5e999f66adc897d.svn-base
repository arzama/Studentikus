using NasSeminarski.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace NasSeminarski.DAL
{
    public class MojContext:DbContext
    {
        public DbSet<Desavanja> Desavanja { get; set; }
      
        public DbSet<EvidencijaObroka> EvidencijaObroka { get; set; }
        public DbSet<Inventar> Inventari { get; set; }
        public DbSet<Kljuc> Kljucevi { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<MjesecObracun> MjeseciObracuna { get; set; }
        public DbSet<OdrzavanjeSobe> OdrzavanjeSoba { get; set; }
        public DbSet<Racun> Racuni { get; set; }
        public DbSet<RezervacijaRestorana> RezervacijaRestorana { get; set; }
        public DbSet<RezervacijaSale> RezervacijeSala { get; set; }
        public DbSet<RezervacijaSobe> RezervacijeSoba { get; set; }
        public DbSet<SkolskaGodina> SkolskeGodine { get; set; }
        public DbSet<Soba> Sobe { get; set; }
        public DbSet<UgovorOStanovanju> UgovoriOStanovanju { get; set; }
        public DbSet<ZaduzenjeKljuca> ZaduzenjaKljuceva { get; set; }
        public DbSet<Zaposlenik> Zaposlenici { get; set; }
        public DbSet<Student> Studenti { get; set; }
        public DbSet<StatusSobe> StatusiSobe { get; set; }
        public DbSet<Uloge> Uloge { get; set; }
        public DbSet<Kanton> Kantoni { get; set; }
        public DbSet<Plata> Plate { get; set; }
        public DbSet<Recenzije> Recenzije { get; set; }
        public DbSet<Zaduzenja> Zaduzenje { get; set; }
        public DbSet<Uplata> Uplate { get; set; }
        public DbSet<Troskovi> Troskovi { get; set; }

        public MojContext()
            : base("Name=MojConnectionString")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);

            


            //modelBuilder.Entity<Korisnik>().HasOptional(x => x.Domar).WithRequired(x => x.Korisnik);
            //modelBuilder.Entity<Korisnik>().HasOptional(x => x.Gost).WithRequired(x => x.Korisnik);
            //modelBuilder.Entity<Korisnik>().HasOptional(x => x.Racunovodja).WithRequired(x => x.Korisnik);
            //modelBuilder.Entity<Korisnik>().HasOptional(x => x.Recepcioner).WithRequired(x => x.Korisnik);
            //modelBuilder.Entity<Korisnik>().HasOptional(x => x.Sobarica).WithRequired(x => x.Korisnik);
            modelBuilder.Entity<Korisnik>().HasOptional(x => x.Student).WithRequired(x => x.Korisnik);
            modelBuilder.Entity<Korisnik>().HasOptional(x => x.Zaposlenik).WithRequired(x => x.Korisnik);
        }

        
      
    }
}