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


        [OperationContract]
        List<PacijentDoktor> GetPacijentByDoktorID(int IDDoktor);

        [OperationContract]
        void AddPacijentDoktorVeza(PacijentDoktor pd);

        [OperationContract]
        void UpdatePacijentDoktorVeza(PacijentDoktor pd);

        [OperationContract]
        void DeletePacijentDoktorVeza(int id);


        [OperationContract]
        List<Doktor> GetDoktor();

        [OperationContract]
        List<Pacijent> GetPacijent();

        [OperationContract]
        List<Korisnik> GetPacijentByVeza(int id);


        [OperationContract]
        void AddDrzava(Drzava d);

        [OperationContract]
        void UpdateDrzava(Drzava d);

        [OperationContract]
        void DeleteDrzava(int id);






        [OperationContract]
        List<Proizvodjac> GetProizvodjac();
       

        [OperationContract]
        void AddProizvodjac(Proizvodjac p);

        [OperationContract]
        void UpdateProizvodjac(Proizvodjac p);

        [OperationContract]
        void DeleteProizvodjac (int id);



        [OperationContract]
        List<Lijek> GetLijek();

        [OperationContract]
        void AddLijek(Lijek l);

        [OperationContract]
        void UpdateLijek(Lijek l);

        [OperationContract]
        void DeleteLijek(int id);



        [OperationContract]
        List<Bolest> GetBolest();

        [OperationContract]
        void AddBolest(Bolest b);

        [OperationContract]
        void UpdateBolest(Bolest b);

        [OperationContract]
        void DeleteBolest(int id);

        [OperationContract]
        List<OpasnostBolesti> GetOpasnostBolesti();


        [OperationContract]
        List<Terapija> GetTerapija();

        [OperationContract]
        void AddTerapija(Terapija t);

        [OperationContract]
        void UpdateTerapija(Terapija t);

        [OperationContract]
        void DeleteTerapija(int id);

        [OperationContract]
        List<Bolest> GetBolestiDDL();

        [OperationContract]
        List<Lijek> GetLijekDDL();



        [OperationContract]
        List<TerapijaLijek> GetLijekByTerapija(int id);

        [OperationContract]
        void AddTerapijaLijek(TerapijaLijek tl);

        [OperationContract]
        void UpdateTerapijaLijek(TerapijaLijek tl);

        [OperationContract]
        void DeleteTerapijaLijek(int id);



        [OperationContract]
        List<PlanTerapije> GetPlanTerapije(int id);

        [OperationContract]
        void AddPlanTerapije(PlanTerapije pt);

        [OperationContract]
        void UpdatePlanTerapije(PlanTerapije pt);

        [OperationContract]
        void DeletePlanTerapije(int id);
    }


}
