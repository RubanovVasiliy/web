namespace web
{
    public static class Utils
    {
        public static bool IsPalindrome(string str)
        {
            for (var i = 0; i < str.Length / 2; i++)
                if (str[i] != str[str.Length - i - 1])
                    return false;
            return true;
        }

        public static Int32 RabbitsCount(Int32 months)
        {
            return Convert.ToInt32(Math.Pow(2, months));
        }
        
        public static Int32 CsvParser(string filename)
        {
            try
            {
                var sum = 0;
                var numbers = new List<Int32>();
                string[] lines = File.ReadAllLines(filename);
                foreach (var line in lines)
                {
                    var nums = line.Split(',');
                    foreach (var num in nums)
                    {
                        var temp = Int32.Parse(num);
                        numbers.Add(temp);
                        sum += temp;
                    }
                }
                numbers.Sort();
                var maxElement = numbers[0];
                var minElement = numbers[numbers.Count - 1];
                double average = sum / numbers.Count;
                var variance = Math.Pow(average, 2);
                var fixedVariance = variance * numbers.Count / (numbers.Count - 1);
                Console.WriteLine("Maximum element: {0}\n" +
                                  "Minimum element: {1}\n" +
                                  "Average: {2}\n" +
                                  "Fixed variance: {3}"
                    ,maxElement, minElement, average, fixedVariance);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }
        
    }
}