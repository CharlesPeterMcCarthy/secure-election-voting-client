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
            } while (optionVal < 1 || optionVal > 7);

            Console.Clear();

            switch (optionVal) {
                case 1: // View All Elections
                    await ViewElectionsFlow.Interact();
                    break;
                case 2: // View Registered Elections
                    await ViewRegisteredElectionsFlow.Interact();
                    break;
                case 3: // Create Election
                    await CreateElectionFlow.Interact();
                    break;
                case 4: // Start Election
                    await StartElectionFlow.Interact();
                    break;
                case 5: // End Election
                    await EndElectionFlow.Interact();
                    break;
                case 6: // Update Election
                    await UpdateElectionFlow.Interact();
                    break;
                case 7: // Delete Election
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

            if (CurrentUser.IsAdmin) {
                Console.WriteLine("3) Create Election");
                Console.WriteLine("4) Start Election");
                Console.WriteLine("5) End Election");
                Console.WriteLine("6) Update Election");
                Console.WriteLine("7) Delete Election");
            }
        }

    }
}
