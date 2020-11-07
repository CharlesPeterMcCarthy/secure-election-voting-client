﻿using System;
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
                    InvalidValueWarning();
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
                    break;
                case 4: // My Account
                    break;
                case 5: // Candidates (admins)
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
            Console.WriteLine("2) Registrations");
            Console.WriteLine("3) Vote");
            Console.WriteLine("4) My Account");

            if (CurrentUser.IsAdmin) Console.WriteLine("5) Candidates");
        }

        private static void InvalidValueWarning() {
            Console.WriteLine("You entered an invalid value!\n");
        }

    }
}
