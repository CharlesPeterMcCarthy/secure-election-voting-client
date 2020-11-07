using System;
using System.Threading.Tasks;
using ElectionVote.Services.Interactions.Tasks;

namespace ElectionVote.Services.Interactions.Options {
    public static class CandidateOptionsFlow {

        public static async Task Interact() {
            int optionVal = 0;

            Console.WriteLine("------ Candidates ------");

            do {
                Console.WriteLine("What candidate option would you like?");
                Console.WriteLine("Options:");
                Console.WriteLine("1) Add Candidate To Election");
                Console.WriteLine("2) Update Candidate");
                Console.WriteLine("3) Delete Candidate");

                try {
                    optionVal = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    InvalidValueWarning();
                    continue;
                }
            } while (optionVal < 1 || optionVal > 3);

            Console.Clear();

            switch (optionVal) {
                case 1: // Add Candidate To Election
                    await AddCandidateToElectionFlow.Interact();
                    break;
                case 2: // Update Candidate
                    await UpdateCandidateFlow.Interact();
                    break;
                case 3: // Delete Candidate
                    await DeleteCandidateFlow.Interact();
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
