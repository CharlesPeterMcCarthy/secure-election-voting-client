using System;
using System.Threading.Tasks;
using ElectionVote.Services.Interactions.Tasks.Registrations;

namespace ElectionVote.Services.Interactions.Options {
    public static class RegistrationOptionsFlow {

        public static async Task Interact() {
            int optionVal = 0;

            Console.WriteLine("------ selectedElection Registrations ------");

            do {
                Console.WriteLine("What election registration option would you like?");
                Console.WriteLine("Options:");
                Console.WriteLine("1) Register for an Election");
                Console.WriteLine("2) Remove a Registration");

                try {
                    optionVal = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    CommonFlow.InvalidValueWarning();
                    continue;
                }
            } while (optionVal < 1 || optionVal > 2);

            Console.Clear();

            switch (optionVal) {
                case 1: // Register for an Election
                    await RegisterForElectionFlow.Interact();
                    break;
                case 2: // Remove a Registration
                    await RemoveRegistrationFlow.Interact();
                    break;
                default:
                    CommonFlow.InvalidValueWarning();
                    break;
            }
        }

    }
}
