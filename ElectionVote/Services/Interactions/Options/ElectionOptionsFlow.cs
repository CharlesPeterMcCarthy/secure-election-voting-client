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
                Console.WriteLine("2) View Upcoming Elections I've Registered For");
                //Console.WriteLine("3) View Election Candidates");

                try {
                    optionVal = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    InvalidValueWarning();
                    continue;
                }
            } while (optionVal < 1 || optionVal > 2);

            Console.Clear();

            switch (optionVal) {
                case 1: // View Elections
                    await ViewElectionsFlow.Interact();
                    break;
                case 2: // View Registered Elections
                    await ViewRegisteredElectionsFlow.Interact();
                    break;
                default:
                    InvalidValueWarning();
                    break;
            }
        }

        private static void InvalidValueWarning() {
            Console.WriteLine("You entered an invalid value!\n");
        }
    }
}
