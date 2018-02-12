using Newtonsoft.Json;
using PorterInNet.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorterInNet
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = new ConsoleMediator();

            mediator.DisplayWelcome();
            var input = mediator.GetInput();

            var analyzer = new PorterUniqueWordAnalyzer(new[] { "a", "the", "and", "of", "in", "be", "also", "as" });
            var result = analyzer.Analyze(input);

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(json);

            mediator.WaitForExit();
        }
    }
}
