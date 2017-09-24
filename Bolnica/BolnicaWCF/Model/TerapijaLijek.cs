using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BolnicaWCF.Model
{
    [DataContract]
    public class TerapijaLijek
    {
        [DataMember]
        public int IDTerapijaLijek { get; set; }

        [DataMember]
        public int TerapijaID { get; set; }

        [DataMember]
        public int LijekID { get; set; }

        [DataMember]
        public string NazivLijeka { get; set; }
    }
}