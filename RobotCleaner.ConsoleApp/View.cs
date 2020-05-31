using System;
using RobotCleaner.ConsoleApp.Interfaces;

namespace RobotCleaner.ConsoleApp
{
    public class View : IView

    {
        public string ReadLine()
        {
            return Console.ReadLine().ToUpper().Trim();
        }

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}
