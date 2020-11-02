using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front_End_Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var programUI = new ProgramUI();
            programUI.Run();
            HttpClient httpClient = new HttpClient();
        }
    }
}
