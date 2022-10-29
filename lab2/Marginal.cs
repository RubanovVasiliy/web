
namespace Lab2
{
    public class Marginal
    {
        public Indicators Ind { get; set; }
        private Configurator.Configurator Configurator { get; }
        public bool IsAlive => Ind.Health != 0;
        public Marginal()
        {
            Ind = new Indicators();
            Ind.Health = 100;
            Configurator = new Configurator.Configurator();
        }
        public void GoWork()
        {
            if (!(Ind.Alcohol < 50 && Ind.Fatigue < 10))
            {
                string msg = new string("Can't go to work, ");
                if (Ind.Alcohol >= 50)
                    msg += $"Alcohol is {Ind.Alcohol}, but should be < 50";
                else
                    msg += $"Fatigue is {Ind.Fatigue}, but should be < 10";
                throw new Exception(msg);
            }
            Ind.Joy -= Configurator.GoWorkConfig.Joy;
            Ind.Alcohol -= Configurator.GoWorkConfig.Alcohol;
            Ind.Cash += Configurator.GoWorkConfig.Cash;
            Ind.Fatigue += Configurator.GoWorkConfig.Fatigue;
        }

        public void Walk()
        {
            Ind.Joy += Configurator.WalkConfig.Joy;
            Ind.Alcohol -= Configurator.WalkConfig.Alcohol;
            Ind.Fatigue += Configurator.WalkConfig.Fatigue;
        }

        public void DrinkWineAndWatchTV()
        {
            if (Ind.Cash < Configurator.DrinkWineAndWatchTVConfig.Cash)
            {
                throw new Exception($"Can't drink wine, not enough money, cash should be more {Configurator.DrinkWineAndWatchTVConfig.Cash}");
            }
            Ind.Joy -= Configurator.DrinkWineAndWatchTVConfig.Joy;
            Ind.Alcohol += Configurator.DrinkWineAndWatchTVConfig.Alcohol;
            Ind.Fatigue += Configurator.DrinkWineAndWatchTVConfig.Fatigue;
            Ind.Health -= Configurator.DrinkWineAndWatchTVConfig.Health;
            Ind.Cash -= Configurator.DrinkWineAndWatchTVConfig.Cash;
        }

        public void GoBar()
        {
            if (Ind.Cash < Configurator.GoBarConfig.Cash)
            {
                throw new Exception($"Can't drink wine, not enough money, cash should be more {Configurator.GoBarConfig.Cash}");
            }
            Ind.Joy += Configurator.GoBarConfig.Joy;
            Ind.Alcohol += Configurator.GoBarConfig.Alcohol;
            Ind.Fatigue += Configurator.GoBarConfig.Fatigue;
            Ind.Health -= Configurator.GoBarConfig.Health;
            Ind.Cash -= Configurator.GoBarConfig.Cash;
        }

        public void DrinkVodkaTogether()
        {
            if (Ind.Cash < Configurator.DrinkVodkaTogetherConfig.Cash)
            {
                throw new Exception($"Can't drink wine, not enough money, cash should be more {Configurator.DrinkVodkaTogetherConfig.Cash}");
            }
            Ind.Joy += Configurator.DrinkVodkaTogetherConfig.Joy;
            Ind.Health -= Configurator.DrinkVodkaTogetherConfig.Health;
            Ind.Alcohol += Configurator.DrinkVodkaTogetherConfig.Alcohol;
            Ind.Fatigue += Configurator.DrinkVodkaTogetherConfig.Fatigue;
            Ind.Cash -= Configurator.DrinkVodkaTogetherConfig.Cash;
        }

        public void SingSong()
        {
            Ind.Joy += Configurator.SingSongConfig.Joy;
            Ind.Cash += (Ind.Alcohol > 40 && Ind.Alcohol < 70) ? (Configurator.SingSongConfig.Cash + 50) : Configurator.SingSongConfig.Cash;
            Ind.Alcohol += Configurator.SingSongConfig.Alcohol;
            Ind.Fatigue += Configurator.SingSongConfig.Fatigue;
        }

        public void Sleep()
        {
            Ind.Health += Ind.Alcohol < 30 ? Configurator.SleepConfig.Health : 0;
            Ind.Joy -= Ind.Alcohol > 70 ? Configurator.SleepConfig.Joy : 0;
            Ind.Alcohol -= Configurator.SleepConfig.Alcohol;
            Ind.Fatigue -= Configurator.SleepConfig.Fatigue;
        }

        public override string ToString()
        {
            return $"Health = {Ind.Health}\nAlcohol = {Ind.Alcohol}\nJoy = {Ind.Joy}\nFatigue = {Ind.Fatigue}\nCash = {Ind.Cash}";
        }
    }
}