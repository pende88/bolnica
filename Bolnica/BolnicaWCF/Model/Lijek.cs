using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BolnicaWCF.Model
{
    [DataContract]
    public class Lijek
    {


        [DataMember]
        public int IDLijek { get; set; }
        [DataMember]
        public string NazivLijeka { get; set; }
        [DataMember]
        public string BrojOdobrenja { get; set; }
        [DataMember]
        public int ProizvodjacID { get; set; }
        [DataMember]
        public string ProizvodjacNaziv { get; set; }
    }
}