using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BolnicaWCF.Model
{
    [DataContract]
    public class PlanTerapije
    {
        [DataMember]
        public int IDPlanTerapije { get; set; }

        [DataMember]
        public int DoktorID { get; set; }

        [DataMember]
        public int PacijentID { get; set; }

        [DataMember]
        public int TerapijaID { get; set; }

        [DataMember]
        public string NazivTerapije { get; set; }

        [DataMember]
        public DateTime DatumPocetka { get; set; }

        [DataMember]
        public DateTime DatumZavrsetka { get; set; }



    }
}