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


    }
}
