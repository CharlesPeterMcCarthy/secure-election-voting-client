using System;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Models;

namespace ElectionVote.Services.Interactions.Tasks.Authtentication {
    public class LoginFlow {

        public static async Task<User> Interact() {
            Console.Clear();
            Console.WriteLine("------ Sign Up ------");

            User user;

            do {
                Console.Write("Enter your Email Address: ");
                String email = Console.ReadLine();

                user = await Auth.Login(email);

                if (user == null) Console.WriteLine("Failed to login");
            } while (user == null);

            return user;
        }

    }
}
