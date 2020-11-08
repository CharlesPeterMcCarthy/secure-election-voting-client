using System;
using System.Threading.Tasks;

namespace ElectionVote.Services.Interactions.Options {
    public static class OptionsFlow {

        public static async Task InteractAsync() {
            while (true) {
                await Options();
            }
        }

        private static async Task Options() {
            int optionSectionVal = 0;

            do {
                PrintOptions();

                try {
                    optionSectionVal = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    CommonFlow.InvalidValueWarning();
                    continue;
                }
            } while (optionSectionVal < 1 || optionSectionVal > 5);

            Console.Clear();

            switch (optionSectionVal) {
                case 1: // Elecctions
                    await ElectionOptionsFlow.Interact();
                    break;
                case 2: // Registrations
                    await RegistrationOptionsFlow.Interact();
                    break;
                case 3: // Vote
                    await VoteOptionsFlow.Interact();
                    break;
                case 4: // Candidates (admins)
                    await CandidateOptionsFlow.Interact();
                    break;
                default:
                    break;
            }
        }

        private static void PrintOptions() {
            Console.WriteLine("What type of options would like?");
            Console.WriteLine("Options:");
            Console.WriteLine("1) Elections");
            Console.WriteLine("2) Election Registrations");
            Console.WriteLine("3) Vote");
            Console.WriteLine("4) Candidates");
        }

    }
}
