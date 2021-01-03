using System;
using System.Text;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Cryptography;
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
                Console.Write("Enter password: ");
                String password = Console.ReadLine();

                UserType userType = UserType.VOTER;

                Console.WriteLine(0);
                byte[] saltBytes = PBKDF2.GenerateSalt();
                Console.WriteLine(1);
                byte[] hashedPasswordBytes = PBKDF2.HashPassword(Encoding.UTF8.GetBytes(password), saltBytes, 50000);
                Console.WriteLine(2);
                string salt = Convert.ToBase64String(saltBytes);
                Console.WriteLine(3);
                string hashedPassword = Convert.ToBase64String(hashedPasswordBytes);
                Console.WriteLine(4);

                Console.WriteLine("Salt is {0}", salt);
                Console.WriteLine("Hashed Password is {0}", hashedPassword);


                user = await Auth.SignUp(firstName, lastName, email, salt, hashedPassword, userType);

                if (user == null) Console.WriteLine("Failed to sign up");
            } while (user == null);

            return user;
        }

    }
}
