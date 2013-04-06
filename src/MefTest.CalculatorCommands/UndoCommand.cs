using System.Collections.Generic;
using System.ComponentModel.Composition;
using MefTest.Core;

namespace MefTest.CalculatorCommands
{
    /// <summary>
    /// allows the user to undo the last command, which affected the current value
    /// </summary>
    /// <remarks>
    /// this it not pretty code, please apply thought before copying it
    /// </remarks>
    [Export(typeof(ICalculatorCommand))]
    public class UndoCommand : ICalculatorCommand
    {
        private readonly Stack<decimal> _values = new Stack<decimal>();
        private decimal _undoValue = 0;


        public string Execute(string input, decimal currentValue)
        {
            if (input.ToLower().Equals("undo"))
            {
                var temp = _undoValue;
                if (_values.Count > 0)
                {
                    _undoValue = _values.Pop();
                }
                return temp.ToString();
            }

            if (currentValue != _undoValue)
            {
                _values.Push(_undoValue);
                _undoValue = currentValue;
            }
            return input;

        }
    }

    
}