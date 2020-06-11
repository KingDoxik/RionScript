using System;
using RionScript;

namespace RionScript.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            RionScript rionScript = new RionScript();
            while (true)
            {
                Console.Write("RionScript > ");
                var code = Console.ReadLine();
                if (code == "exit") return;
                rionScript.Exec(code);
            }
        }
    }
}
