using System;
using ElectionVote.Services;

namespace ElectionVote
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Making a request!");

            HttpRequest.Request();

            String input = Console.ReadLine();

            Console.WriteLine(input);
        }
    }
}
