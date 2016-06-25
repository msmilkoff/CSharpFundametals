namespace _03.LastDigitName
{
    using System;

    public class LastDigitName
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            var number = new Number(num);
            Console.WriteLine(number.getLastDigitName());
        }
    }

    public class Number
    {
        public Number(int number)
        {
            this.Value = number;
        }

        public int Value { get; set; }

        public string getLastDigitName()
        {
            string numToString = this.Value.ToString();
            int index = numToString.Length - 1;

            int lastNum = (int)char.GetNumericValue(numToString[index]);
            switch (lastNum)
            {
                
                case 1:
                    return "one";
                case 2:
                    return "two"; 
                case 3:
                    return "three"; 
                case 4:
                    return "four"; 
                case 5:
                    return "five"; 
                case 6:
                    return "six"; 
                case 7:
                    return "seven"; 
                case 8:
                    return "eight"; 
                case 9:
                    return "nine";           
                case 0:
                    return "zero";
                default:
                    throw new ArgumentException();
            }
        }
    }
}
