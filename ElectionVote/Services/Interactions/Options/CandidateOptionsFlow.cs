using System;
using System.Threading.Tasks;
using ElectionVote.Services.Interactions.Tasks.Candidates;

namespace ElectionVote.Services.Interactions.Options {
    public static class CandidateOptionsFlow {

        public static async Task Interact() {
            int optionVal = 0;

            Console.WriteLine("------ Candidates ------");

            do {
                PrintOptions();

                try {
                    optionVal = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    CommonFlow.InvalidValueWarning();
                    continue;
                }
            } while (optionVal < 1 || optionVal > 4);

            Console.Clear();

            switch (optionVal) {
                case 1: // View Election Candidates
                    await ViewCandidatesFlow.Interact();
                    break;
                case 2: // Add Candidate To Election
                    await AddCandidateToElectionFlow.Interact();
                    break;
                case 3: // Update Candidate
                    await UpdateCandidateFlow.Interact();
                    break;
                case 4: // Delete Candidate
                    await DeleteCandidateFlow.Interact();
                    break;
                default:
                    CommonFlow.InvalidValueWarning();
                    break;
            }
        }

        private static void PrintOptions() {
            Console.WriteLine("What candidate option would you like?");
            Console.WriteLine("Options:");
            Console.WriteLine("1) View Election Candidates");

            if (CurrentUser.IsAdmin) {
                Console.WriteLine("2) Add Candidate To Election");
                Console.WriteLine("3) Update Candidate");
                Console.WriteLine("4) Delete Candidate");
            }
        }

    }
}
