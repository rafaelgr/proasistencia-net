using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProNetLib;

namespace ProNetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduzca comando:");
            string cmd = Console.ReadLine();
            while (cmd != "exit")
            {
                SQLAny sqlAny = new SQLAny();
                Input input = new Input();
                input.comando = cmd;
                Console.WriteLine(cmd + " -->");
                Task<object> o = sqlAny.Invoke(cmd);
                Console.WriteLine(o.Result);
                Console.Write("Introduzca comando:");
                cmd = Console.ReadLine();
            }
        }
    }
}
