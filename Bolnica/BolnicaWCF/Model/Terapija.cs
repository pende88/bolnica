using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BolnicaWCF.Model
{

    [DataContract]
    public class Terapija
    {
        [DataMember]
        public int IDTerapija { get; set; }

        [DataMember]
        public string Naziv { get; set; }

        [DataMember]
        public int BolestID { get; set; }

        [DataMember]
        public string NazivBolesti { get; set; }

        [DataMember]
        public int DaniTrajanja { get; set; }

    }
}