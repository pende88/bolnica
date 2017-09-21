using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BolnicaWCF.Model
{
    [DataContract]
    public class Pacijent
    {
        [DataMember]
        public int IDKOrisnickiRacun { get; set; }
        [DataMember]
        public string NazivPacijenta { get; set; }
    }
}
