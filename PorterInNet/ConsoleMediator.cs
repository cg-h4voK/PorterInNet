using PorterInNet.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PorterInNet
{
    [ExcludeFromCodeCoverage]
    public class ConsoleMediator
    {
        public ConsoleMediator(bool maximize = true)
        {
            if (maximize) ConsoleBehavior.Instance.Maximize();
        }

        public void DisplayWelcome()
        {
            ConsoleBehavior.Instance.WriteLineCentered("Welcome to PorterInNet");
            ConsoleBehavior.Instance.WriteLineCentered("A simple test of Porter2 algorythm in .NET");
            ConsoleBehavior.Instance.WriteDoubleLine();
            Console.WriteLine();
        }

        public string GetInput()
        {
            Console.WriteLine("This application will parse text and return an alphatized list of unique words (by stem) with the total of occurrences and the sentence indexes where they were found.");

            var userDecisions = new Dictionary<ConsoleKey, Func<string>>
            {
                { ConsoleKey.Y, UseInputFromFile },
                { ConsoleKey.N, RequestUserInput },
            };

            if (EnvironmentConfiguration.Instance.DefaultInputFileExists)
            {
                var userInput = default(ConsoleKey);



                while (!userDecisions.ContainsKey(userInput))
                {
                    Console.WriteLine();
                    Console.WriteLine("There is a default 'input.txt' defined in this application directory. Would you like to use that as your input? y/n: ");
                    userInput = Console.ReadKey().Key;
                }

                return userDecisions[userInput]();
            }

            return userDecisions[ConsoleKey.N]();
        }

        protected string UseInputFromFile()
        {
            return DefaultFileSystemService.Instance.ReadAllText(EnvironmentConfiguration.Instance.DefaultInputFile);
        }

        protected string RequestUserInput()
        {
            Console.WriteLine();

            var userInput = String.Empty;

            while(String.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Define your input string:");
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        public void WaitForExit()
        {
            ConsoleBehavior.Instance.WriteDoubleLine();
            ConsoleBehavior.Instance.PressAnyKeyToExit();
        }
    }
}
