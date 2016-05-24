namespace _10.SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            var operationResults = new Stack<string>();

            int operationsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < operationsCount; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string commandType = commandArgs[0];
                switch (commandType)
                {
                    case "1":
                        var editedText = operationResults.Count > 0 
                            ? new StringBuilder(operationResults.Peek()) 
                            : new StringBuilder();
                        editedText.Append(commandArgs[1]);
                        operationResults.Push(editedText.ToString());
                        break;
                    case "2":
                        var curretTextState = operationResults.Peek();
                        var newTextState = new StringBuilder(curretTextState);
                        int startIndex = curretTextState.Length - int.Parse(commandArgs[1]);
                        newTextState.Remove(startIndex, curretTextState.Length - startIndex);
                        operationResults.Push(newTextState.ToString());
                        break;
                    case "3":
                        var currentTextState = operationResults.Peek();
                        // wantedIndex is the N-th character of the text, so it's 1-based;
                        int wantedIndex = int.Parse(commandArgs[1]) - 1;
                        Console.WriteLine(currentTextState[wantedIndex]);
                        break;
                    case "4":
                        operationResults.Pop();
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }
    }
}
