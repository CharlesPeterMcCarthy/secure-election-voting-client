using System;
using System.Threading.Tasks;
using ElectionVote.Services.Interactions.Tasks.Votes;

namespace ElectionVote.Services.Interactions.Options {
    public static class VoteOptionsFlow {

        public static async Task Interact() {
            int optionVal = 0;

            Console.WriteLine("------ Voting ------");

            do {
                PrintOptions();

                try {
                    optionVal = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    CommonFlow.InvalidValueWarning();
                    continue;
                }
            } while (optionVal < 1 || optionVal > 1);

            Console.Clear();

            switch (optionVal) {
                case 1: // Submit Vote
                    await SubmitVoteFlow.Interact();
                    break;
                default:
                    CommonFlow.InvalidValueWarning();
                    break;
            }
        }

        private static void PrintOptions() {
            Console.WriteLine("What voting option would you like?");
            Console.WriteLine("Options:");
            Console.WriteLine("1) Submit Vote");
        }

    }
}
