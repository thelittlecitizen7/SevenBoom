using System;
using System.Threading;

namespace SevenBoom
{
    class Program
    {
        static void Main(string[] args)
        {
            SevenBoomRunner sevenBoomRunner = new SevenBoomRunner();
            sevenBoomRunner.Run(obj => { Console.WriteLine(obj); });
        }
    }
}
