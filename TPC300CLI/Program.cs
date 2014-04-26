using System;
using System.Linq;

namespace TPC300CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            // TPC300CLI 1 ON
            // TPC300CLI 1 OFF
            // TPC300CLI 1 LEVEL 1..16

            if (args.Count() < 2)
            {
                Console.WriteLine("Invalid parameters");
            }

            string arg0 = args[0];
            string arg1 = args[1];

            byte code;
            if (byte.TryParse(arg0, out code))
            {
                if (arg1.ToLower() == "on")
                {
                    TPC300.Device.On(code);
                }
                else if (arg1.ToLower() == "off")
                {
                    TPC300.Device.Off(code);
                }
                else if (arg1.ToLower() == "level")
                {
                    if (args.Count() > 2)
                    {
                        string arg2 = args[2];
                        byte level;
                        if (byte.TryParse(arg2, out level))
                        {
                            TPC300.Device.Level(code, level);
                        }
                        else
                        {
                            Console.WriteLine("Invalid level value");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Missing level value");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command (On, Off, Level)");
                }
            }
            else
            {
                Console.WriteLine("Invalid code value");
            }
        }
    }
}
