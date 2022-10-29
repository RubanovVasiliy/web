using System.Runtime.Serialization;

namespace Lab2.Configurator
{
    [DataContract]
    public class GoWorkConfig
    {
        [DataMember]
        public int Joy { get; set; }
        [DataMember]
        public int Alcohol { get; set; }
        [DataMember]
        public int Cash { get; set; }
        [DataMember]
        public int Fatigue { get; set; }
    }
}