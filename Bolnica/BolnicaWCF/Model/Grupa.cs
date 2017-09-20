using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BolnicaWCF.Model
{
    [DataContract]
    public class Grupa
    {
        [DataMember]
        public int IDKorisnickaGrupa { get; set; }
        [DataMember]
        public string KorisnickaGrupaNaziv { get; set; }
    }
}