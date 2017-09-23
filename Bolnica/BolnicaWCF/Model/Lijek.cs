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
        public int IDLIjek { get; set; }
        [DataMember]
        public string NazivLijeka { get; set; }
        [DataMember]
        public string BrojOdobrenja { get; set; }
        [DataMember]
        public int ProizvodjacID { get; set; }
    }
}