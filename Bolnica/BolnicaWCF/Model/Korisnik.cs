using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BolnicaWCF.Model
{
    [DataContract]
    public class Korisnik
    {
        [DataMember]
        public int IDKorisnickiRacun { get; set; }
        [DataMember]
        public int KorisnickaGrupaID { get; set; }
        [DataMember]
        public string KorisnickaGrupaNaziv { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public int IDKorisnikDetalji { get; set; }
        [DataMember]
        public int KorisnickiRacunID { get; set; }
        [DataMember]
        public string Ime { get; set; }
        [DataMember]
        public string Prezime { get; set; }
        [DataMember]
        public string OIB { get; set; }
        [DataMember]
        public string Telefon { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Adresa { get; set; }
        [DataMember]
        public string PTTBroj { get; set; }

        [DataMember]
        public int DrzavaID { get; set; }
        [DataMember]
        public string DrzavaNaziv { get; set; }


        [DataMember]
        public int LoginStatus { get; set; }



    }
}