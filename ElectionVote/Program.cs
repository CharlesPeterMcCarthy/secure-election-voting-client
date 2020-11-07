using System;
using System.Collections.Generic;
using ElectionVote.Services;
using ElectionVote.Services.Enums;
using ElectionVote.Services.Models;

namespace ElectionVote {
    class MainClass {
        public static async System.Threading.Tasks.Task Main(string[] args) {
            Console.WriteLine("Welcome to the Election Voting App!\n");
            Console.WriteLine("Are you Logging in or Signing up?");
            Console.WriteLine("Enter 1 for Logging in or 2 for Signing up.\n");

            int entryVal = int.Parse(Console.ReadLine());

            //Console.WriteLine("Are you a Voter or Admin?");
            //Console.WriteLine("Enter 1 for Voter or 2 for Admin.\n");

            //int userTypeVal = int.Parse(Console.ReadLine());

            //Console.WriteLine(entryVal);
            //Console.WriteLine(userTypeVal);

            //if (entryVal == 1) { // Logging in

            //} else if (entryVal == 2) { // Signing up
            //    Console.Write("Enter first name: ");
            //    String firstName = Console.ReadLine();
            //    Console.Write("Enter last name: ");
            //    String lastName = Console.ReadLine();
            //    Console.Write("Enter email address: ");
            //    String email = Console.ReadLine();

            //    String userType = "VOTER";
            //    if (userTypeVal == 2) userType = "ADMIN";

            //    User user = await Auth.SignUp(firstName, lastName, email, userType);

            //    Console.WriteLine(user);
            //    Console.WriteLine(user.firstName);
            //}

            User user = await Auth.SignUp("Charles", "mcc", "test@test.com", UserType.VOTER);
            //User user = await Auth.Login("test@test.com");

            if (user != null) {
                Console.WriteLine(user);
                Console.WriteLine(user.FirstName);
                Console.WriteLine(user.LastName);
                Console.WriteLine(user.Email);
                Console.WriteLine(user.UserType);
                Console.WriteLine(user.Times);
            }

        }
    }
}
