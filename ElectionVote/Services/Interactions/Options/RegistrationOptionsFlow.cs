using System;
using System.Threading.Tasks;
using ElectionVote.Services.Interactions.Tasks;

namespace ElectionVote.Services.Interactions.Options {
    public static class RegistrationOptionsFlow {

        public static async Task InteractAsync() {
            int optionVal = 0;

            Console.WriteLine("------ Registrations ------");

            do {
                Console.WriteLine("What registrations option would you like?");
                Console.WriteLine("Options:");
                Console.WriteLine("1) View my Registrations");
                Console.WriteLine("2) Register for an Election");

                try {
                    optionVal = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    InvalidValueWarning();
                    continue;
                }
            } while (optionVal < 1 || optionVal > 2);

            Console.Clear();

            switch (optionVal) {
                case 1: // View Registrations
                    break;
                case 2: // Register for election
                    await RegisterForElectionFlow.Interact();
                    break;
                default:
                    break;
            }
        }

        private static void InvalidValueWarning() {
            Console.WriteLine("You entered an invalid value!\n");
        }

    }
}
