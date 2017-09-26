using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BolnicaWCF.Model
{
    [DataContract]
    public class PacijentDoktor
    {

        [DataMember]
        public int IDPacijentDoktorVeza { get; set; }
        [DataMember]
        public int DoktorKorisnickiRacunID { get; set; }
        [DataMember]
        public int PacijentKorisnickiRacunID { get; set; }
        [DataMember]
        public string NazivPacijenta { get; set; }

        [DataMember]
        public string NazivDoktora { get; set; }
    }
}