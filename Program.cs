using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommandLine;

namespace NaaSGithubAction
{
    class Program
    {
        static  async Task Main(string[] args)
        {
            var result = Parser.Default.ParseArguments<Options>(args);
            await result.MapResult(
                async options => await RunWithOptionsAsync(options),
                errors => HandleParseError(errors)
            );
        }

        static async Task RunWithOptionsAsync(Options options)
        {
            if (string.IsNullOrEmpty(options.FirstName) && string.IsNullOrEmpty(options.LastName))
            {
                Console.WriteLine("Hello World.");
            }
            else
            {
                Console.WriteLine($"Hello {options.FirstName} {options.LastName}.");
            }    
                            
            Console.WriteLine($"::set-output name=date::{DateTime.Now}");
        }

        static Task HandleParseError(IEnumerable<Error> errors)
        {
            Environment.Exit(1);
            return Task.CompletedTask;
        }
    }
}
