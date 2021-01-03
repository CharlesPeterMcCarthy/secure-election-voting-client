using System;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Enums;
using ElectionVote.Services.Models;

namespace ElectionVote.Services.Interactions.Tasks.Authtentication {
    public class SignUpFlow {

        public static async Task<User> Interact() {
            Console.Clear();
            Console.WriteLine("------ Sign Up ------");

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
