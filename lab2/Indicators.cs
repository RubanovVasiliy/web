namespace Lab2
{
    [Serializable]
    public class Indicators
    {
        private int _health;
        private int _alcohol;
        private int _joy;
        private int _fatigue;
        private int _cash;

        public int Health
        {
            get => _health;
            set
            {
                switch (value)
                {
                    case >= 0 and <= 100:
                        _health = value;
                        break;
                    case < 0:
                        _health = 0;
                        break;
                    case > 100:
                        _health = 100;
                        break;
                }
            }
        }

        public int Alcohol
        {
            get => _alcohol;
            set
            {
                switch (value)
                {
                    case >= 0 and <= 100:
                        _alcohol = value;
                        break;
                    case < 0:
                        _alcohol = 0;
                        break;
                    case > 100:
                        _alcohol = 100;
                        break;
                }
            }
        }

        public int Joy
        {
            get => _joy;
            set
            {
                switch (value)
                {
                    case >= -10 and <= 10:
                        _joy = value;
                        break;
                    case < -10:
                        _joy = -10;
                        break;
                    case > 10:
                        _joy = 10;
                        break;
                }
            }
        }

        public int Fatigue
        {
            get => _fatigue;
            set
            {
                switch (value)
                {
                    case >= 0 and <= 100:
                        _fatigue = value;
                        break;
                    case < 0:
                        _fatigue = 0;
                        break;
                    case > 100:
                        _fatigue = 100;
                        break;
                }
            }
        }

        public int Cash
        {
            get => _cash;
            set
            {
                _cash = value >= 0 ? value : 0;
            }
        }
    }
}