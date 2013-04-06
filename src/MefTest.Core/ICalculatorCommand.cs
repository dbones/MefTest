namespace MefTest.Core
{
    /// <summary>
    /// commands which are applied before the formula is evaluated
    /// </summary>
    public interface ICalculatorCommand
    {
        /// <summary>
        /// execute the extension command
        /// </summary>
        /// <param name="input">the current input from the user</param>
        /// <param name="currentValue">the current value of the calculator</param>
        /// <returns>
        /// return an empty string to stop processing the input. 
        /// else modify it before its passed to the Evaluator
        /// </returns>
        string Execute(string input, decimal currentValue);
    }
}