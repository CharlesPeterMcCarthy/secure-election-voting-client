using System;
using System.Threading.Tasks;

namespace ElectionVote.Services.Interactions {
    public class LogoutFlow {

        public static Task Interact() {
            Console.WriteLine("You have chosen to logout of the Secure Voting Application.");

            CurrentUser.UnsetCurrentUser();

            Console.WriteLine("You have successfully logged out.");

            return null;
        }

    }
}
