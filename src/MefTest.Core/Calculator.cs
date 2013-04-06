using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace MefTest.Core
{
    [Export]
    public class Calculator
    {
        [ImportingConstructor]
        public Calculator(
            IFormulaParser formulaParser,
            [ImportMany] IEnumerable<ICalculatorCommand> calculatorCommands)
        {
            FormulaParser = formulaParser;
            CalculatorCommands = calculatorCommands ?? new List<ICalculatorCommand>();
        }

        public IFormulaParser FormulaParser { get; private set; }
        public IEnumerable<ICalculatorCommand> CalculatorCommands { get; private set; }
        public Decimal CurrentValue { get; private set; }

        public void Execute(string input)
        {
            foreach (var calculatorCommand in CalculatorCommands)
            {
                input = calculatorCommand.Execute(input, CurrentValue);
            }
            if (input.Equals("")) return;
            CurrentValue = FormulaParser.Evaluate(input);
        }
    }
}
