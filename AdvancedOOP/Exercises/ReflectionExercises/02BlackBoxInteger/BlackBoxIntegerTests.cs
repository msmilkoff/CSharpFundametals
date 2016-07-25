namespace _02BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main(string[] args)
        {
            var blackBox = typeof(BlackBoxInt);
            var boxInstance = (BlackBoxInt)Activator.CreateInstance(
                typeof(BlackBoxInt), true);

            string input = Console.ReadLine();
            while (input != "END")
            {
                var tokens = input.Split('_');
                string methodName = tokens[0];
                int methodParam = int.Parse(tokens[1]);

                var method = blackBox.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
                method.Invoke(boxInstance, new object[] { methodParam });

                int result = (int)typeof(BlackBoxInt)
                    .GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(boxInstance);

                Console.WriteLine(result);

                input = Console.ReadLine();
            }
        }
    }
}
