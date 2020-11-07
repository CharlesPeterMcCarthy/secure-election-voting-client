using System;
using ElectionVote.Services;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Interactions;
using ElectionVote.Services.Interactions.Options;
using ElectionVote.Services.Models;

namespace ElectionVote {
    class MainClass {
        public static async System.Threading.Tasks.Task Main(string[] args) {
            Console.WriteLine("Welcome to the Election Voting App!\n");

            //User user = await AuthFlow.Interact();
            User user = await Auth.Login("test@test.com");
            CurrentUser.SetCurrentUser(user);

            //Console.Clear();
            //Console.WriteLine($"Hi {user.FirstName}!");
            await OptionsFlow.InteractAsync();

            Console.Read();
        }
    }
}
