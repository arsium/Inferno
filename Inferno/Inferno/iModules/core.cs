/*
 * 
 * Error exit codes:
 * 0 All is okay.
 * 1 File not found.
 * 2 Admin rights need.
 * 3 Other error.
 * 
*/

using System;
using Newtonsoft.Json;

namespace Inferno
{
    internal class core
    {
        // Exit
        public static void Exit(string message, dynamic output, int exitcode = 0)
        {
            try
            {
                _ = output.error;
                Console.ForegroundColor = ConsoleColor.Red;
            } catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                output.error = false;
            }

            output.message = message;
            string json = JsonConvert.SerializeObject(output);
            Console.Write(json);
            Console.ForegroundColor = ConsoleColor.White;
            Environment.Exit(exitcode);
        }
    }
}