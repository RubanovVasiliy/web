namespace web
{
    public class TemperatureConverter
    {
        private double _temperature;
        private string _unitOfMeasureIn;
        private string _unitOfMeasureOut;

        public void ConvertValue()
        {
            InputDegrees();

            InputUnitOfMeasure("in");
            
            InputUnitOfMeasure("out");
            
            Execute();
            
            Console.WriteLine(_temperature);
        }

        private void Execute()
        {
            if (_unitOfMeasureIn.Equals(_unitOfMeasureOut))
                return;

            if (_unitOfMeasureIn.Equals(UnitOfMeasure.Celsius) &&
                _unitOfMeasureOut.Equals(UnitOfMeasure.Fahrenheit))
            {
                _temperature = _temperature * 9 / 5 + 32;
            }
            
            if (_unitOfMeasureIn.Equals(UnitOfMeasure.Celsius) &&
                _unitOfMeasureOut.Equals(UnitOfMeasure.Kelvin))
            {
                _temperature += 273.15;
            }
            
            if (_unitOfMeasureIn.Equals(UnitOfMeasure.Fahrenheit) &&
                _unitOfMeasureOut.Equals(UnitOfMeasure.Celsius))
            {
                _temperature = _temperature * 5 / 9 - 32;

            }
            
            if (_unitOfMeasureIn.Equals(UnitOfMeasure.Fahrenheit) &&
                _unitOfMeasureOut.Equals(UnitOfMeasure.Kelvin))
            {
                _temperature = (_temperature - 32) * 5 / 9 + 273.15;
            }
            
            if (_unitOfMeasureIn.Equals(UnitOfMeasure.Kelvin) &&
                _unitOfMeasureOut.Equals(UnitOfMeasure.Fahrenheit))
            {
                _temperature = (_temperature - 273.15) * 9 / 5 + 32;
            }
            
            if (_unitOfMeasureIn.Equals(UnitOfMeasure.Kelvin) &&
                _unitOfMeasureOut.Equals(UnitOfMeasure.Celsius))
            {
                _temperature -= 273.15;
            }
        }

        private void InputUnitOfMeasure(string inputType)
        {
            try
            {
                Console.WriteLine("Input unit of measure C/F/K:");
                var input = Console.ReadLine();
                if (input == null || (!input.Equals(UnitOfMeasure.Celsius) &&
                                      !input.Equals(UnitOfMeasure.Fahrenheit) &&
                                      !input.Equals(UnitOfMeasure.Kelvin)))
                {
                    throw new Exception("Error! Wrong unit of measure value.");
                }

                if (inputType.Equals("in"))
                {
                    _unitOfMeasureIn = input;
                }
                else if(inputType.Equals("out"))
                {
                    _unitOfMeasureOut = input;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Environment.Exit(1);
            }
        }

        private void InputDegrees()
        {
            try
            {
                Console.WriteLine("Input degrees value:");
                var inputDegrees = Console.ReadLine();
                _temperature = Convert.ToDouble(inputDegrees);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! Value cannot be string.");
                Environment.Exit(1);
            }
        }
    }
}