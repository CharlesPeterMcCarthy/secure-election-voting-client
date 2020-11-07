using System;
using ElectionVote.Services;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Enums;
using ElectionVote.Services.Interactions;
using ElectionVote.Services.Interactions.Options;
using ElectionVote.Services.Models;

namespace ElectionVote {
    class MainClass {
        public static async System.Threading.Tasks.Task Main(string[] args) {
            Console.WriteLine("Welcome to the Election Voting App!\n");

            //User user = await AuthFlow.Interact();
            //User user = await Auth.Login("test@test.com");
            User user = new User() {
                FirstName = "Charles",
                LastName = "McC",
                Email = "test@test.com",
                UserType = UserType.VOTER,
                UserId = "9ad56532-3fb1-4948-87b0-2d9c3539cb37"
            };
            CurrentUser.SetCurrentUser(user);

            //Console.Clear();
            //Console.WriteLine($"Hi {user.FirstName}!");
            await OptionsFlow.InteractAsync();

            Console.Read();
        }
    }
}
