using System;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Enums;
using ElectionVote.Services.Models;

namespace ElectionVote.Services.Interactions {
    public static class AuthFlow {

        public static async Task<User> Interact() {
            User user = null;
            int entryVal = 0;
            int userTypeVal = 0;

            do {
                Console.WriteLine("Are you Logging in or Signing up?");
                Console.WriteLine("Enter 1 for Logging in or 2 for Signing up.\n");

                try {
                    entryVal = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    InvalidValueWarning();
                    continue;
                }

                if (entryVal != 1 && entryVal != 2) InvalidValueWarning();
            } while (entryVal != 1 && entryVal != 2);

            Console.Clear();

            do {
                Console.WriteLine("Are you a Voter or Admin?");
                Console.WriteLine("Enter 1 for Voter or 2 for Admin.\n");

                try {
                    userTypeVal = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    InvalidValueWarning();
                    continue;
                }

                Console.Clear();

                if (entryVal == 1) { // Logging in
                    user = await LoginFlow();
                } else if (entryVal == 2) { // Signing up
                    user = await SignUpFlow(userTypeVal);
                } else {
                    InvalidValueWarning();
                }

            } while (userTypeVal != 1 && userTypeVal != 2);

            return user;
        }

        private static async Task<User> LoginFlow() {
            User user = null;

            do {
                Console.Write("Enter your Email Address: ");
                String email = Console.ReadLine();

                user = await Auth.Login(email);

                if (user == null) Console.WriteLine("Failed to login");
            } while (user == null);

            return user;
        }

        private static async Task<User> SignUpFlow(int userTypeVal) {
            User user = null;

            do {
                Console.Write("Enter first name: ");
                String firstName = Console.ReadLine();
                Console.Write("Enter last name: ");
                String lastName = Console.ReadLine();
                Console.Write("Enter email address: ");
                String email = Console.ReadLine();

                UserType userType = UserType.VOTER;
                if (userTypeVal == 2) userType = UserType.ADMIN;

                user = await Auth.SignUp(firstName, lastName, email, userType);

                if (user == null) Console.WriteLine("Failed to sign up");
            } while (user == null);

            return user;
        }

        private static void InvalidValueWarning() {
            Console.WriteLine("You entered an invalid value!\n");
        }

    }
}
