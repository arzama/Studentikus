namespace NasSeminarski.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nesto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Desavanjas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        Datum = c.DateTime(),
                        Opis = c.String(),
                        Ime = c.String(),
                        Prezime = c.String(),
                        BrojTelefona = c.String(),
                        ZaposlenikId = c.Int(),
                        RacunId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Racuns", t => t.RacunId)
                .ForeignKey("dbo.Zaposleniks", t => t.ZaposlenikId)
                .Index(t => t.ZaposlenikId)
                .Index(t => t.RacunId);
            
            CreateTable(
                "dbo.Racuns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Kolicina = c.Int(nullable: false),
                        Cijena = c.Single(nullable: false),
                        Iznos = c.Single(nullable: false),
                        MjesecObracunId = c.Int(),
                        UgovorOStanovanjuId = c.Int(),
                        ZaposlenikId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MjesecObracuns", t => t.MjesecObracunId)
                .ForeignKey("dbo.UgovorOStanovanjus", t => t.UgovorOStanovanjuId)
                .ForeignKey("dbo.Zaposleniks", t => t.ZaposlenikId)
                .Index(t => t.MjesecObracunId)
                .Index(t => t.UgovorOStanovanjuId)
                .Index(t => t.ZaposlenikId);
            
            CreateTable(
                "dbo.MjesecObracuns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Godina = c.Int(nullable: false),
                        Mjesec = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UgovorOStanovanjus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Datum = c.DateTime(),
                        BrojKartice = c.Int(nullable: false),
                        SkolskaGodinaId = c.Int(),
                        SobaId = c.Int(),
                        StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SkolskaGodinas", t => t.SkolskaGodinaId)
                .ForeignKey("dbo.Sobas", t => t.SobaId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.SkolskaGodinaId)
                .Index(t => t.SobaId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.SkolskaGodinas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        BrojSkolskeGodine = c.Int(nullable: false),
                        AkademskaGodina = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sobas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        BrojSobe = c.Int(nullable: false),
                        Sprat = c.Int(nullable: false),
                        StatusSobeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StatusSobes", t => t.StatusSobeId)
                .Index(t => t.StatusSobeId);
            
            CreateTable(
                "dbo.StatusSobes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Rezervisana = c.Boolean(nullable: false),
                        Slobodna = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DatumUseljenja = c.DateTime(),
                        Fakultet = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisniks", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Korisniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Ime = c.String(),
                        Prezime = c.String(),
                        DatumRodjenja = c.DateTime(),
                        Adresa = c.String(),
                        Email = c.String(),
                        Kontakt = c.String(),
                        KorisnickoIme = c.String(maxLength: 450),
                        Lozinka = c.String(),
                        UlogeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Uloges", t => t.UlogeId)
                .Index(t => t.KorisnickoIme, unique: true)
                .Index(t => t.UlogeId);
            
            CreateTable(
                "dbo.Uloges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Zaposleniks",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DatumZaposlenja = c.DateTime(),
                        OpisPosla = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisniks", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.EvidencijaObrokas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Datum = c.DateTime(),
                        Vrijeme = c.DateTime(),
                        UgovorOStanovanjuId = c.Int(nullable: false),
                        MjesecObracunId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MjesecObracuns", t => t.MjesecObracunId)
                .ForeignKey("dbo.UgovorOStanovanjus", t => t.UgovorOStanovanjuId)
                .Index(t => t.UgovorOStanovanjuId)
                .Index(t => t.MjesecObracunId);
            
            CreateTable(
                "dbo.Inventars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        Opis = c.String(),
                        Cijena = c.Single(nullable: false),
                        Upotrebljivo = c.Boolean(),
                        ZaposlenikId = c.Int(nullable: false),
                        SobaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sobas", t => t.SobaId)
                .ForeignKey("dbo.Zaposleniks", t => t.ZaposlenikId)
                .Index(t => t.ZaposlenikId)
                .Index(t => t.SobaId);
            
            CreateTable(
                "dbo.Kljucs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        BrojKljuca = c.Int(nullable: false),
                        Kolicina = c.Int(nullable: false),
                        SobaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sobas", t => t.SobaId)
                .Index(t => t.SobaId);
            
            CreateTable(
                "dbo.OdrzavanjeSobes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Datum = c.DateTime(),
                        Komentar = c.String(),
                        ZaposlenikId = c.Int(nullable: false),
                        SobaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sobas", t => t.SobaId)
                .ForeignKey("dbo.Zaposleniks", t => t.ZaposlenikId)
                .Index(t => t.ZaposlenikId)
                .Index(t => t.SobaId);
            
            CreateTable(
                "dbo.RezervacijaRestoranas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        DesavanjaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Desavanjas", t => t.DesavanjaId)
                .Index(t => t.DesavanjaId);
            
            CreateTable(
                "dbo.RezervacijaSales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        DesavanjaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Desavanjas", t => t.DesavanjaId)
                .Index(t => t.DesavanjaId);
            
            CreateTable(
                "dbo.RezervacijaSobes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        DatumPrijave = c.DateTime(),
                        DatumOdjave = c.DateTime(),
                        Otkazana = c.Boolean(),
                        Realizovana = c.Boolean(),
                        SobaId = c.Int(),
                        KorisnikId = c.Int(),
                        RacunId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisniks", t => t.KorisnikId)
                .ForeignKey("dbo.Racuns", t => t.RacunId)
                .ForeignKey("dbo.Sobas", t => t.SobaId)
                .Index(t => t.SobaId)
                .Index(t => t.KorisnikId)
                .Index(t => t.RacunId);
            
            CreateTable(
                "dbo.ZaduzenjeKljucas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        DatumPreuzimanja = c.DateTime(),
                        DatumVracanja = c.DateTime(),
                        Aktivan = c.Boolean(nullable: false),
                        KorisnikId = c.Int(nullable: false),
                        KljucId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kljucs", t => t.KljucId)
                .ForeignKey("dbo.Korisniks", t => t.KorisnikId)
                .Index(t => t.KorisnikId)
                .Index(t => t.KljucId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZaduzenjeKljucas", "KorisnikId", "dbo.Korisniks");
            DropForeignKey("dbo.ZaduzenjeKljucas", "KljucId", "dbo.Kljucs");
            DropForeignKey("dbo.RezervacijaSobes", "SobaId", "dbo.Sobas");
            DropForeignKey("dbo.RezervacijaSobes", "RacunId", "dbo.Racuns");
            DropForeignKey("dbo.RezervacijaSobes", "KorisnikId", "dbo.Korisniks");
            DropForeignKey("dbo.RezervacijaSales", "DesavanjaId", "dbo.Desavanjas");
            DropForeignKey("dbo.RezervacijaRestoranas", "DesavanjaId", "dbo.Desavanjas");
            DropForeignKey("dbo.OdrzavanjeSobes", "ZaposlenikId", "dbo.Zaposleniks");
            DropForeignKey("dbo.OdrzavanjeSobes", "SobaId", "dbo.Sobas");
            DropForeignKey("dbo.Kljucs", "SobaId", "dbo.Sobas");
            DropForeignKey("dbo.Inventars", "ZaposlenikId", "dbo.Zaposleniks");
            DropForeignKey("dbo.Inventars", "SobaId", "dbo.Sobas");
            DropForeignKey("dbo.EvidencijaObrokas", "UgovorOStanovanjuId", "dbo.UgovorOStanovanjus");
            DropForeignKey("dbo.EvidencijaObrokas", "MjesecObracunId", "dbo.MjesecObracuns");
            DropForeignKey("dbo.Desavanjas", "ZaposlenikId", "dbo.Zaposleniks");
            DropForeignKey("dbo.Desavanjas", "RacunId", "dbo.Racuns");
            DropForeignKey("dbo.Racuns", "ZaposlenikId", "dbo.Zaposleniks");
            DropForeignKey("dbo.Racuns", "UgovorOStanovanjuId", "dbo.UgovorOStanovanjus");
            DropForeignKey("dbo.UgovorOStanovanjus", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Zaposleniks", "Id", "dbo.Korisniks");
            DropForeignKey("dbo.Korisniks", "UlogeId", "dbo.Uloges");
            DropForeignKey("dbo.Students", "Id", "dbo.Korisniks");
            DropForeignKey("dbo.UgovorOStanovanjus", "SobaId", "dbo.Sobas");
            DropForeignKey("dbo.Sobas", "StatusSobeId", "dbo.StatusSobes");
            DropForeignKey("dbo.UgovorOStanovanjus", "SkolskaGodinaId", "dbo.SkolskaGodinas");
            DropForeignKey("dbo.Racuns", "MjesecObracunId", "dbo.MjesecObracuns");
            DropIndex("dbo.ZaduzenjeKljucas", new[] { "KljucId" });
            DropIndex("dbo.ZaduzenjeKljucas", new[] { "KorisnikId" });
            DropIndex("dbo.RezervacijaSobes", new[] { "RacunId" });
            DropIndex("dbo.RezervacijaSobes", new[] { "KorisnikId" });
            DropIndex("dbo.RezervacijaSobes", new[] { "SobaId" });
            DropIndex("dbo.RezervacijaSales", new[] { "DesavanjaId" });
            DropIndex("dbo.RezervacijaRestoranas", new[] { "DesavanjaId" });
            DropIndex("dbo.OdrzavanjeSobes", new[] { "SobaId" });
            DropIndex("dbo.OdrzavanjeSobes", new[] { "ZaposlenikId" });
            DropIndex("dbo.Kljucs", new[] { "SobaId" });
            DropIndex("dbo.Inventars", new[] { "SobaId" });
            DropIndex("dbo.Inventars", new[] { "ZaposlenikId" });
            DropIndex("dbo.EvidencijaObrokas", new[] { "MjesecObracunId" });
            DropIndex("dbo.EvidencijaObrokas", new[] { "UgovorOStanovanjuId" });
            DropIndex("dbo.Zaposleniks", new[] { "Id" });
            DropIndex("dbo.Korisniks", new[] { "UlogeId" });
            DropIndex("dbo.Korisniks", new[] { "KorisnickoIme" });
            DropIndex("dbo.Students", new[] { "Id" });
            DropIndex("dbo.Sobas", new[] { "StatusSobeId" });
            DropIndex("dbo.UgovorOStanovanjus", new[] { "StudentId" });
            DropIndex("dbo.UgovorOStanovanjus", new[] { "SobaId" });
            DropIndex("dbo.UgovorOStanovanjus", new[] { "SkolskaGodinaId" });
            DropIndex("dbo.Racuns", new[] { "ZaposlenikId" });
            DropIndex("dbo.Racuns", new[] { "UgovorOStanovanjuId" });
            DropIndex("dbo.Racuns", new[] { "MjesecObracunId" });
            DropIndex("dbo.Desavanjas", new[] { "RacunId" });
            DropIndex("dbo.Desavanjas", new[] { "ZaposlenikId" });
            DropTable("dbo.ZaduzenjeKljucas");
            DropTable("dbo.RezervacijaSobes");
            DropTable("dbo.RezervacijaSales");
            DropTable("dbo.RezervacijaRestoranas");
            DropTable("dbo.OdrzavanjeSobes");
            DropTable("dbo.Kljucs");
            DropTable("dbo.Inventars");
            DropTable("dbo.EvidencijaObrokas");
            DropTable("dbo.Zaposleniks");
            DropTable("dbo.Uloges");
            DropTable("dbo.Korisniks");
            DropTable("dbo.Students");
            DropTable("dbo.StatusSobes");
            DropTable("dbo.Sobas");
            DropTable("dbo.SkolskaGodinas");
            DropTable("dbo.UgovorOStanovanjus");
            DropTable("dbo.MjesecObracuns");
            DropTable("dbo.Racuns");
            DropTable("dbo.Desavanjas");
        }
    }
}
