using System.ComponentModel.Composition;
using System.Text.RegularExpressions;
using MefTest.Core;

namespace MefTest.CalculatorCommands
{
    /// <summary>
    /// inputs the current value into the formula
    /// </summary>
    [Export(typeof(ICalculatorCommand))]
    public class CurrentValueCommand : ICalculatorCommand
    {
        public string Execute(string input, decimal currentValue)
        {
            var lowercaseInput = input.ToLower();

            const string expression = "cur";
            var exp = new Regex(expression);

            return exp.Replace(lowercaseInput, match => currentValue.ToString());

        }
    }
}