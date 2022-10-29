using System.Runtime.Serialization;

namespace Lab2.Configurator
{
    [DataContract]
    public class WalkConfig
    {
        [DataMember]
        public int Joy { get; set; }
        [DataMember]
        public int Alcohol { get; set; }
        [DataMember]
        public int Fatigue { get; set; }
    }
}