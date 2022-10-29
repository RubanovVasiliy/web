using System.Runtime.Serialization;

namespace Lab2.Configurator
{
    [DataContract]
    public class DrinkWineAndWatchTVConfig
    {
        [DataMember]
        public int Joy { get; set; }
        [DataMember]
        public int Alcohol { get; set; }
        [DataMember]
        public int Fatigue { get; set; }
        [DataMember]
        public int Health { get; set; }
        [DataMember]
        public int Cash { get; set; }
    }
}