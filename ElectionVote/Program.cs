using System;
using System.Collections.Generic;
using ElectionVote.Services;

namespace ElectionVote {
    class MainClass {
        public static async System.Threading.Tasks.Task Main(string[] args) {
            Console.WriteLine("Welcome to the Election Voting App!\n");
            Console.WriteLine("Are you Logging in or Signing up?");
            Console.WriteLine("Enter 1 for Logging in or 2 for Signing up.\n");

            //int entryVal = int.Parse(Console.ReadLine());

            //Dictionary<String, String> userDetails = new Dictionary<String, String> {
            //        { "firstName", "Charlie" },
            //        { "lastName", "McC" },
            //        { "email", "chazooo555@gmail.com" },
            //        { "userType", "VOTER" }
            //    };

            //Console.WriteLine("About to post");

            //HttpRequest.Post("https://sp321m383l.execute-api.eu-west-1.amazonaws.com/dev/user", userDetails);

            //Console.WriteLine("Posted");

            //int ssf = int.Parse(Console.ReadLine());

            //HttpRequest.Request();

            int entryVal = int.Parse(Console.ReadLine());

            Console.WriteLine("Are you a Voter or Admin?");
            Console.WriteLine("Enter 1 for Voter or 2 for Admin.\n");

            int userTypeVal = int.Parse(Console.ReadLine());

            Console.WriteLine(entryVal);
            Console.WriteLine(userTypeVal);

            if (entryVal == 1) { // Logging in

            } else if (entryVal == 2) { // Signing up
                Console.Write("Enter first name: ");
                String firstName = Console.ReadLine();
                Console.Write("Enter last name: ");
                String lastName = Console.ReadLine();
                Console.Write("Enter email address: ");
                String email = Console.ReadLine();

                String userType = "VOTER";
                if (userTypeVal == 2) userType = "ADMIN";

                Dictionary<String, String> userDetails = new Dictionary<String, String> {
                    { "firstName", firstName },
                    { "lastName", lastName },
                    { "email", email },
                    { "userType", userType }
                };

                String response = await HttpRequest.Post("https://sp321m383l.execute-api.eu-west-1.amazonaws.com/dev/user", userDetails);

                Console.WriteLine(response);
            }


        }
    }
}
