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
            } catch (Exception)
            {
                output.error = false;
            }

            output.message = message;
            string json = JsonConvert.SerializeObject(output);
            Console.Write(json);
            Environment.Exit(exitcode);
        }


    }

}
