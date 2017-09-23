using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BolnicaWCF.Model
{

    [DataContract]
    public class Bolest
    {
        [DataMember]
        public int IDBolest { get; set; }
        [DataMember]
        public string NazivBolesti { get; set; }
        [DataMember]
        public int GodinaOtkrica { get; set; }
        [DataMember]
        public int OpasnostID { get; set; }
        [DataMember]
        public string Opasnost { get; set; }
    }
}