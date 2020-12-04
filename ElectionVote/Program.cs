using System;
using ElectionVote.Services;
using ElectionVote.Services.Enums;
using ElectionVote.Services.Interactions;
using ElectionVote.Services.Interactions.Options;
using ElectionVote.Services.Models;

namespace ElectionVote {
    class MainClass {
        public static async System.Threading.Tasks.Task Main(string[] args) {
            Console.WriteLine("Welcome to the Election Voting App!\n");

            //User user = await AuthFlow.Interact();

            User user = new User() {
                FirstName = "CHarles",
                LastName = "McCarthy III",
                Email = "chaz@test.com",
                UserType = UserType.ADMIN,
                UserId = "fb926a58-d1ca-4746-aae3-abe8d8dad6ed"
            };
            CurrentUser.SetCurrentUser(user);

            Console.Clear();
            Console.WriteLine($"Hi {user.FirstName}!");
            await OptionsFlow.InteractAsync();

            Console.Read();
        }
    }
}
