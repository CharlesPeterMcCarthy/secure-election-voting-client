using System;
using ElectionVote.Services.Interactions;
using ElectionVote.Services.Models;

namespace ElectionVote {
    class MainClass {
        public static async System.Threading.Tasks.Task Main(string[] args) {
            Console.WriteLine("Welcome to the Election Voting App!\n");

            User user = await AuthFlow.Interact();

            Console.Clear();
            Console.WriteLine($"Hi {user.FirstName}!");

            Console.WriteLine("What would you like to do next?");
            Console.WriteLine("Options:");
            Console.WriteLine("1) View all Elections");
        }
    }
}
