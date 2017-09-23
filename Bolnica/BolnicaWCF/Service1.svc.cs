using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BolnicaWCF.Model;

namespace BolnicaWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<Korisnik> LoginKorisnikProvjera(string Username, string Password)
        {
            return (new Repository()).LoginKorisnikProvjera(Username, Password);
        }

        public List<Korisnik> GetKorisnik()
        {
            return (new Repository()).GetKorisnik();
        }

        public void AddKorisnik(Korisnik k)
        {
            new Repository().AddKorisnik(k);
        }

        public void UpdateKorisnik(Korisnik k)
        {
            new Repository().UpdateKorisnik(k);
        }

        public void DeleteKorisnik(int id)
        {
            new Repository().DeleteKorisnik(id);
        }

        public List<Grupa> GetGrupa()
        {
            return (new Repository()).GetGrupa();
        }

        public List<Proizvodjac> GetProizvodjac()
        {
            return (new Repository()).GetProizvodjac();
        }

        public List<PacijentDoktor> GetPacijentByDoktorID(int IDDoktor)
        {
            return (new Repository()).GetPacijentByDoktorID(IDDoktor);
        }

        public void AddPacijentDoktorVeza(PacijentDoktor pd)
        {
            new Repository().AddPacijentDoktorVeza(pd);
        }

        public void UpdatePacijentDoktorVeza(PacijentDoktor pd)
        {
            new Repository().UpdatePacijentKorisnikVeza(pd);
        }

        public void DeletePacijentDoktorVeza(int id)
        {
            new Repository().DeletePacijentDoktorVeza(id);
        }

        public List<Doktor> GetDoktor()
        {
            return (new Repository()).GetDoktor();
        }

        public List<Pacijent> GetPacijent()
        {
            return (new Repository()).GetPacijent();
        }

        public List<Korisnik> GetPacijentByVeza(int id)
        {
            return (new Repository()).GetPacijentByVeza(id);
        }

        public void AddProizvodjac(Proizvodjac d)
        {
             new  Repository().AddProizvodjac(d);
        }

        public void UpdateProizvodjac(Proizvodjac d)
        {
             new  Repository().UpdateProizvodjac(d);
        }

        public void DeleteProizvodjac(int id)
        {
             new  Repository().DeleteProizvodjac(id);
        }

        public List<Lijek> GetLijek()
        {
            return (new Repository()).GetLijek();
        }

        public void AddLijek(Lijek l)
        {
            new Repository().AddLijek(l);
        }

        public void UpdateLijek(Lijek l)
        {
            new Repository().UpdateLijek(l);
        }

        public void DeleteLijek(int id)
        {
            new Repository().DeleteLijek(id);
        }

        public List<Bolest> GetBolest()
        {
            return (new Repository()).GetBolest();
        }

        public void AddBolest(Bolest b)
        {
            new Repository().AddBolest(b);
        }

        public void UpdateBolest(Bolest b)
        {
            new Repository().UpdateBolest(b);
        }

        public void DeleteBolest(int id)
        {
            new Repository().DeleteBolest(id);
        }

        public List<Drzava> GetDrzava()
        {
            return (new Repository()).GetDrzava();
        }

        public void AddDrzava(Drzava d)
        {
            new Repository().AddDrzava(d);
        }

        public void UpdateDrzava(Drzava d)
        {
            new Repository().UpdateDrzava(d);
        }

        public void DeleteDrzava(int id)
        {
            new Repository().DeleteBolest(id);
        }

        public List<OpasnostBolesti> GetOpasnostBolesti()
        {
            return (new Repository()).GetOpasnostBolesti();
        }
    }
}
