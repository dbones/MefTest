using System.ComponentModel.Composition;
using MefTest.Core;

namespace MefTest.CalculatorCommands
{
    /// <summary>
    /// quits the app
    /// </summary>
    [Export(typeof(ICalculatorCommand))]
    public class QuitCommand : ICalculatorCommand
    {
        public string Execute(string input, decimal currentValue)
        {
            var lowercaseInput = input.ToLower();

            return lowercaseInput.Equals("q") ? "" : input;
        }
    }
}