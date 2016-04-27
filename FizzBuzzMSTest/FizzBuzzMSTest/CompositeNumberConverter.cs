namespace FizzBuzzMSTest
{
    public class CompositeNumberConverter : INumberConverter
    {
        private readonly INumberConverter[] numberConverters;

        private readonly INumberConverter defaultConverter;

        public CompositeNumberConverter(INumberConverter defaultConverter, params INumberConverter[] valueConverters)
        {
            this.defaultConverter = defaultConverter;
            this.numberConverters = valueConverters;
        }

        public string Convert(int number)
        {
            string result = "";
            foreach (var numberConverter in this.numberConverters)
            {
                result += numberConverter.Convert(number);
            }

            if (!string.IsNullOrEmpty(result))
            {
                return result;
            }

            return this.defaultConverter.Convert(number);
        }
    }


    public interface INumberConverter
    {
        string Convert(int number);
    }

    public class BuzzConverter : INumberConverter
    {
        public string Convert(int number)
        {
            if (number % 5 == 0)
            {
                return "Buzz";
            }

            return "";
        }
    }

    public class FizzConverter : INumberConverter
    {
        public string Convert(int number)
        {
            if (number % 3 == 0)
            {
                return "Fizz";
            }

            return "";
        }
    }

    public class NumberConverter : INumberConverter
    {
        public string Convert(int number)
        {
            return number.ToString();
        }
    }
}