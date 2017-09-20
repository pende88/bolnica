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
        public int IDKorisnickaGrupa { get; set; }
        [DataMember]
        public string Grupa { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }

        
        
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
        public string Grad { get; set; }

        [DataMember]
        public int IDDrzava { get; set; }
        [DataMember]
        public string Drzava { get; set; }




    }
}