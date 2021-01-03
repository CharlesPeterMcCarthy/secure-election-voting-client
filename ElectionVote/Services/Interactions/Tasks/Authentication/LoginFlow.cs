using System;
using System.Text;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Cryptography;
using ElectionVote.Services.Models;

namespace ElectionVote.Services.Interactions.Tasks.Authtentication {
    public class LoginFlow {

        public static async Task<User> Interact() {
            Console.Clear();
            Console.WriteLine("------ Login ------");

            User user;

            do {
                Console.Write("Enter your Email Address: ");
                String email = Console.ReadLine();
                Console.Write("Enter your Password: ");
                String password = Console.ReadLine().Trim();

                user = await Auth.GetUser(email);
                if (user == null) Console.WriteLine("Failed to login - Email does not exist");

                byte[] saltBytes = Convert.FromBase64String(user.Salt);
                byte[] hashedPasswordBytes = PBKDF2.HashPassword(Encoding.UTF8.GetBytes(password), saltBytes, 50000);
                string hashedPassword = Convert.ToBase64String(hashedPasswordBytes);

                if (hashedPassword == user.HashedPassword) break;
                else Console.WriteLine("Login Failed - You have entered an incorrect password.");
            } while (true);

            return user;
        }

    }
}
