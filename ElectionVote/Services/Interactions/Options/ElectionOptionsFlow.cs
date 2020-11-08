using System;
using System.Threading.Tasks;
using ElectionVote.Services.Interactions.Tasks;

namespace ElectionVote.Services.Interactions.Options {
    public static class ElectionOptionsFlow {

        public static async Task Interact() {
            int optionVal = 0;

            Console.WriteLine("------ Elections ------");

            do {
                Console.WriteLine("What election option would you like?");
                Console.WriteLine("Options:");
                Console.WriteLine("1) View All Elections");
                //Console.WriteLine("2) View Upcoming Elections");
                //Console.WriteLine("3) View Finsihed Elections");
                Console.WriteLine("4) View Upcoming Elections I've Registered For");
                Console.WriteLine("5) Create Election");
                Console.WriteLine("6) Start Election");
                Console.WriteLine("7) Stop Election");
                Console.WriteLine("8) Update Election");
                Console.WriteLine("9) Delete Election");

                try {
                    optionVal = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    CommonFlow.InvalidValueWarning();
                    continue;
                }
            } while (optionVal < 1 || optionVal > 9);

            Console.Clear();

            switch (optionVal) {
                case 1: // View All Elections
                    await ViewElectionsFlow.Interact();
                    break;
                case 4: // View Registered Elections
                    await ViewRegisteredElectionsFlow.Interact();
                    break;
                case 5: // Create Election
                    break;
                case 6: // Start Election
                    await StartElectionFlow.Interact();
                    break;
                case 7: // Finish Election
                    break;
                default:
                    CommonFlow.InvalidValueWarning();
                    break;
            }
        }

    }
}
