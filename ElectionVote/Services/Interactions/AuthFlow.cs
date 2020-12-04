using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Enums;
using ElectionVote.Services.Models;

namespace ElectionVote.Services.Interactions {
    public static class AuthFlow {

        private static List<NavigationOption> NavigationOptions = new List<NavigationOption>() {
            new NavigationOption() {
                Name = "Login",
                Action = LoginFlow
            },
            new NavigationOption() {
                Name = "Sign Up",
                Action = SignUpFlow
            }
        };

        public static async Task<User> Interact() {
            User user = null;
            int selectedVal = 0;

            do {
                Console.Write("Are you Logging in or Signing up? ");
                CommonFlow.PrintNavigationOptions(NavigationOptions, "authentication");

                try {
                    selectedVal = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    CommonFlow.InvalidValueWarning();
                    continue;
                }

                if (selectedVal < 1 || selectedVal > NavigationOptions.Count) CommonFlow.InvalidValueWarning();
            } while (selectedVal < 1 || selectedVal > NavigationOptions.Count);

            Console.Clear();

            await NavigationOptions[selectedVal - 1].Action();

            return user;
        }

        private static async Task<User> LoginFlow() {
            User user;

            do {
                Console.Write("Enter your Email Address: ");
                String email = Console.ReadLine();

                user = await Auth.Login(email);

                if (user == null) Console.WriteLine("Failed to login");
            } while (user == null);

            return user;
        }

        private static async Task<User> SignUpFlow() {
            User user;

            do {
                Console.Write("Enter first name: ");
                String firstName = Console.ReadLine();
                Console.Write("Enter last name: ");
                String lastName = Console.ReadLine();
                Console.Write("Enter email address: ");
                String email = Console.ReadLine();

                UserType userType = UserType.VOTER;

                user = await Auth.SignUp(firstName, lastName, email, userType);

                if (user == null) Console.WriteLine("Failed to sign up");
            } while (user == null);

            return user;
        }

    }
}
