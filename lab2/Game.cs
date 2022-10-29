using System.Runtime.Serialization.Formatters.Binary;

namespace Lab2
{
    class Game
    {
        private Marginal Hero { get; set; }
        private const string DirName = "..\\..\\..\\saves";
        public Game()
        {
            Hero = new Marginal();
        }
        public void ActLoop()
        {
            while (true)
            {
                if (!Hero.IsAlive)
                {
                    Console.WriteLine("You died!");
                    return;
                }
                Console.Write("Indicators:\n");
                Console.Write($"{Hero}\n\n");
                Console.WriteLine("Actions:");
                foreach (var action in Enum.GetValues(typeof(Actions)))
                {
                    Console.WriteLine($"{(int)action} - {Enum.GetName(typeof(Actions), action)}");
                }
                Console.Write("Enter number of the action: ");
                switch (GetAction())
                {
                    case Actions.GoWork:
                        try
                        {
                            Hero.GoWork();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                        }
                        break;
                    case Actions.Walk:
                        Hero.Walk();
                        break;
                    case Actions.DrinkWineAndWatchTV:
                        try
                        {
                            Hero.DrinkWineAndWatchTV();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                        }
                        break;
                    case Actions.GoBar:
                        try
                        {
                            Hero.GoBar();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                        }
                        break;
                    case Actions.DrinkVodkaTogether:
                        try
                        {
                            Hero.DrinkVodkaTogether();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                        }
                        break;
                    case Actions.SingSong:
                        Hero.SingSong();
                        break;
                    case Actions.Sleep:
                        Hero.Sleep();
                        break;
                    case Actions.Save:
                        Save();
                        break;
                    case Actions.Load:
                        try
                        {
                            var progress = Load();
                            if (progress != null)
                            {
                                Hero.Ind = progress;
                            }
                            else
                            {
                                Console.WriteLine("Невозможно загрузить сохраненную игру");
                                Console.ReadKey();
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Невозможно загрузить сохраненную игру");
                            Console.ReadKey();
                        }
                        break;
                    case Actions.NewGame:
                        Hero = new Marginal();
                        break;
                    case Actions.Exit:
                        Console.WriteLine("Do you want to save game before exit? y/n");
                        var str = Console.ReadLine();
                        if ("y" == str || "yes" == str)
                        {
                            Save();
                        }
                        return;
                }
                Console.Clear();
            }
        }
        public void Save()
        {
            bool exists = System.IO.Directory.Exists(DirName);
            if (!exists)
                System.IO.Directory.CreateDirectory(DirName);

            var binFormatter = new BinaryFormatter();
            using (var file = new FileStream($"{DirName}\\Save.bin", FileMode.OpenOrCreate))
            {
                if (Hero.Ind != null) binFormatter?.Serialize(file, Hero.Ind);
            }
        }
        public Indicators? Load()
        {
            try
            {
                var binFormatter = new BinaryFormatter();
                using (var file = new FileStream($"{DirName}\\Save.bin", FileMode.Open))
                {
                    if (binFormatter?.Deserialize(file) is Indicators hero)
                    {
                        return hero;
                    }
                }
            }
            catch
            {
                throw;
            }
            return null;
        }
        private Actions GetAction()
        {
            Actions result;
            Actions.TryParse(Console.ReadLine(), out result);
            return result;
        }

    }
}