using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BolnicaWCF.Model
{
    [DataContract]
    public class Drzava
    {
        [DataMember]
        public int IDDrzava { get; set; }
        [DataMember]
        public string Naziv { get; set; }
    }
}