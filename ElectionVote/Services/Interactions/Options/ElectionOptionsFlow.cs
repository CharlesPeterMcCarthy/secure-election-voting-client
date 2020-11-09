using System;
using System.Threading.Tasks;
using ElectionVote.Services.Interactions.Tasks.Elections;

namespace ElectionVote.Services.Interactions.Options {
    public static class ElectionOptionsFlow {

        public static async Task Interact() {
            int optionVal = 0;

            Console.WriteLine("------ Elections ------");

            do {
                PrintOptions();

                try {
                    optionVal = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    CommonFlow.InvalidValueWarning();
                    continue;
                }
            } while (optionVal < 1 || optionVal > 8);

            Console.Clear();

            switch (optionVal) {
                case 1: // View All Elections
                    await ViewElectionsFlow.Interact();
                    break;
                case 2: // View Registered Elections
                    await ViewRegisteredElectionsFlow.Interact();
                    break;
                case 3: // View Election Results
                    await ViewElectionResultsFlow.Interact();
                    break;
                case 4: // Create Election
                    await CreateElectionFlow.Interact();
                    break;
                case 5: // Start Election
                    await StartElectionFlow.Interact();
                    break;
                case 6: // End Election
                    await EndElectionFlow.Interact();
                    break;
                case 7: // Update Election
                    await UpdateElectionFlow.Interact();
                    break;
                case 8: // Delete Election
                    await DeleteElectionFlow.Interact();
                    break;
                default:
                    CommonFlow.InvalidValueWarning();
                    break;
            }
        }

        private static void PrintOptions() {
            Console.WriteLine("What election option would you like?");
            Console.WriteLine("Options:");
            Console.WriteLine("1) View All Elections");
            Console.WriteLine("2) View Upcoming Elections I've Registered For");
            Console.WriteLine("3) View Election Results");

            if (CurrentUser.IsAdmin) {
                Console.WriteLine("4) Create Election");
                Console.WriteLine("5) Start Election");
                Console.WriteLine("6) End Election");
                Console.WriteLine("7) Update Election");
                Console.WriteLine("8) Delete Election");
            }
        }

    }
}
