using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using MefTest.Core;
using NCalc;

namespace MefTest.NCalcEngine
{
    [Export(typeof(IFormulaParser))] //small issue. this is not compile time safe
    public class NCalcFormulaParser : IFormulaParser
    {
        public decimal Evaluate(string input)
        {
            var exp = new Expression(input);
            var temp = exp.Evaluate();
            return decimal.Parse(temp.ToString());
        }
    } 
}
