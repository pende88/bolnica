using BolnicaWCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BolnicaWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<Korisnik> LoginKorisnikProvjera(string Username, string Password);

        [OperationContract]
        List<Korisnik> GetKorisnik();

        [OperationContract]
        void AddKorisnik(Korisnik k);

        [OperationContract]
        void UpdateKorisnik(Korisnik k);

        [OperationContract]
        void DeleteKorisnik(int id);

        [OperationContract]
        List<Grupa> GetGrupa();

        [OperationContract]
        List<Drzava> GetDrzava();
    }
}
