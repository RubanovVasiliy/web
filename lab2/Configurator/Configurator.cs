using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Lab2.Configurator
{
    [DataContract]
    public class Configurator
    {
        [DataMember] public GoBarConfig GoBarConfig { get; set; }
        [DataMember] public WalkConfig WalkConfig { get; set; }
        [DataMember] public DrinkWineAndWatchTVConfig DrinkWineAndWatchTVConfig { get; set; }
        [DataMember] public DrinkVodkaTogetherConfig DrinkVodkaTogetherConfig { get; set; }
        [DataMember] public GoWorkConfig GoWorkConfig { get; set; }
        [DataMember] public SingSongConfig SingSongConfig { get; set; }
        [DataMember] public SleepConfig SleepConfig { get; set; }

        public Configurator()
        {
            try
            {
                var JsonSerializer = new DataContractJsonSerializer(typeof(Configurator));
                using (var file = new FileStream("../../../Config/Config.json", FileMode.Open))
                {
                    var result = JsonSerializer?.ReadObject(file) as Configurator;
                    GoBarConfig = result.GoBarConfig;
                    WalkConfig = result.WalkConfig;
                    DrinkWineAndWatchTVConfig = result.DrinkWineAndWatchTVConfig;
                    DrinkVodkaTogetherConfig = result.DrinkVodkaTogetherConfig;
                    GoWorkConfig = result.GoWorkConfig;
                    SingSongConfig = result.SingSongConfig;
                    SleepConfig = result.SleepConfig;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Environment.Exit(2);
            }
        }
    }
}