namespace MefTest.Core
{
    /// <summary>
    /// will be responcible for actually calcualting the formula
    /// </summary>
    public interface IFormulaParser
    {
        /// <summary>
        /// calcululate the formula
        /// </summary>
        /// <param name="input">a string representation of an equation to evaluate</param>
        /// <returns>the output as a decimal</returns>
        decimal Evaluate(string input);
    }
}