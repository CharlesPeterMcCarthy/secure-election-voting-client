using System;
using System.Threading.Tasks;
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


                entryVal = int.Parse(Console.ReadLine());
            } while (entryVal != 1 && entryVal != 2);

            do {
                Console.WriteLine("Are you a Voter or Admin?");
                Console.WriteLine("Enter 1 for Voter or 2 for Admin.\n");

                userTypeVal = int.Parse(Console.ReadLine());

                Console.WriteLine(entryVal);
                Console.WriteLine(userTypeVal);

                if (entryVal == 1) { // Logging in
                    Console.WriteLine("Enter your Email Address: ");
                    String email = Console.ReadLine();

                    user = await Auth.Login(email);
                } else if (entryVal == 2) { // Signing up
                    Console.Write("Enter first name: ");
                    String firstName = Console.ReadLine();
                    Console.Write("Enter last name: ");
                    String lastName = Console.ReadLine();
                    Console.Write("Enter email address: ");
                    String email = Console.ReadLine();

                    UserType userType = UserType.VOTER;
                    if (userTypeVal == 2) userType = UserType.ADMIN;

                    user = await Auth.SignUp(firstName, lastName, email, userType);
                } else {
                    Console.WriteLine("You entered an invalid value");
                }

            } while (userTypeVal != 1 && userTypeVal != 2);

            return user;
        }

    }
}
