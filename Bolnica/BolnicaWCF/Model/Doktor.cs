using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BolnicaWCF.Model
{
    [DataContract]
    public class Doktor
    {
        [DataMember]
        public int IDKOrisnickiRacun { get; set; }
        [DataMember]
        public string NazivDoktora { get; set; }
    }
}