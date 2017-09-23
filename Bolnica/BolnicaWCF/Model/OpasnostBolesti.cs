using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BolnicaWCF.Model
{
    [DataContract]
    public class OpasnostBolesti
    {
        [DataMember]
        public int IDOPasnost { get; set; }

        [DataMember]
        public string Opasnost { get; set; }
    }
}