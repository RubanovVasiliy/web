namespace lab2;

public class Person
{
    public int Health { get; set; }
    public int Mana { get; set; }
    public int Cheerfulness { get; set; }
    public int Fatigue { get; set; }
    public int Money { get; set; }

    class WorkSettings
    {
        public int Cheerfulness { get; }
        public int Mana { get; set; }
        public int Money { get; set; }
        public int Fatigue { get; set; }
    }

    public bool GoWork()
    {
        Cheerfulness -= 5;
        return true;
    }
}