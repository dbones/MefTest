using System;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using MefTest.CalculatorCommands;
using MefTest.Core;
using MefTest.NCalcEngine;

namespace MefTest.CommandLine
{
    class Program
    {
        static void Main()
        {
            //to debug the container setup, you have to look at the Trace.
            using (CompositionContainer container = CreateMefContainer())
            {
                var calculator = container.GetExport<Calculator>().Value;
                
                //the main part of the application
                string input;
                do
                {
                    Console.Write("Command: ");
                    input = Console.ReadLine();

                    calculator.Execute(input);

                    Console.WriteLine("Value: " + calculator.CurrentValue);
                    Console.WriteLine();
                } while (input.ToLower() != "q");

                //always ensure the dispose is called at the end of your app
            }
            Console.Write("thank you - press enter");
            Console.ReadLine();
        }

        private static CompositionContainer CreateMefContainer()
        {

           //return IOC - done.... interfaces.

            //we could easily have put the dlls in a directory
            var coreAssembly = typeof(Calculator).Assembly;
            var commandsAssembly = typeof(CurrentValueCommand).Assembly;
            var nCalcAssembly = typeof(NCalcFormulaParser).Assembly;

            ComposablePartCatalog coreCatalog = new AssemblyCatalog(coreAssembly);
            ComposablePartCatalog commandsCatalog = new AssemblyCatalog(commandsAssembly);
            ComposablePartCatalog nCalcCatalog = new AssemblyCatalog(nCalcAssembly);

            var aggregateCatalog = new AggregateCatalog(coreCatalog, nCalcCatalog, commandsCatalog);

            return new CompositionContainer(aggregateCatalog);
        }
    }
}
