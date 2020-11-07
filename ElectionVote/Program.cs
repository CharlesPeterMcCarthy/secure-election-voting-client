using System;
using System.Collections.Generic;
using ElectionVote.Services;
using ElectionVote.Services.Enums;
using ElectionVote.Services.Interactions;
using ElectionVote.Services.Models;

namespace ElectionVote {
    class MainClass {
        public static async System.Threading.Tasks.Task Main(string[] args) {
            Console.WriteLine("Welcome to the Election Voting App!\n");

            User user = await AuthFlow.Interact();

            if (user != null) {
                Console.WriteLine(user);
                Console.WriteLine(user.FirstName);
                Console.WriteLine(user.LastName);
                Console.WriteLine(user.Email);
                Console.WriteLine(user.UserType);
                Console.WriteLine(user.Times);
            }

        }
    }
}
