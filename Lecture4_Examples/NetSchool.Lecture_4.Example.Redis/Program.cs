using System;

namespace NetSchool.Lecture_4.Example.Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("REDIS");

            var s = "";
            do
            {
                Console.WriteLine();
                Console.WriteLine("Select command (or type \"exit\" for stop):");
                Console.WriteLine("0. Get data");
                Console.Write("> ");
                s = Console.ReadLine();

                switch (s.ToLower())
                {
                    case "0":
                        var service = new DataService();
                        Console.WriteLine(service.Get());
                        break;

                    case "exit":
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("------------");
                        Console.WriteLine("Illegal input");
                        Console.WriteLine("------------");
                        continue;
                }
            }
            while (s.ToLower() != "exit");
        }
    }
}
