using System;
using ElectionVote.Services;
using ElectionVote.Services.Enums;
using ElectionVote.Services.Exceptions;
using ElectionVote.Services.Interactions;
using ElectionVote.Services.Interactions.Options;
using ElectionVote.Services.Models;

namespace ElectionVote {
    class MainClass {
        public static async System.Threading.Tasks.Task Main(string[] args) {
            Console.WriteLine("Welcome to the Election Voting App!\n");

            User user = await AuthOptionsFlow.Interact();

            //User user = new User() {
            //    FirstName = "Charles",
            //    LastName = "McCarthy",
            //    Email = "charles@test.com",
            //    UserType = UserType.VOTER,
            //    UserId = "3836cd98-fb85-4140-8493-e1e997d58309"
            //};
            CurrentUser.SetCurrentUser(user);
            StateListener.PerformAction();

            Console.Clear();
            Console.WriteLine($"Hi {user.FirstName}!");

            try {
                await OptionsFlow.InteractAsync();
            } catch (LogoutException e) {
                if (e.IsUserInvoked) Console.WriteLine("You have successfully logged out!");
                else Console.WriteLine("You have been forcefully logged out: {0}", e.Message);
                CurrentUser.UnsetCurrentUser(); // Clear user data
            } catch (ConsecutiveActionsException) {
                Console.WriteLine("Quick Consecutive Actions!");
                Console.WriteLine("You are limited to one action every 5 seconds. Please wait and try again!");
            } catch (Exception e) {
                Console.WriteLine("An nunknown exception occurred: {0}", e);
            }

            Console.Read();
        }

    }
}
