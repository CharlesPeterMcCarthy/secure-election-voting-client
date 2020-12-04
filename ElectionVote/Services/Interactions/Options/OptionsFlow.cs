using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Models;

namespace ElectionVote.Services.Interactions.Options {
    public static class OptionsFlow {

        private static List<NavigationOption> NavigationOptions = new List<NavigationOption>() {
            new NavigationOption() {
                Name = "Elections",
                Action = ElectionOptionsFlow.Interact
            },
            new NavigationOption() {
                Name = "Election Registrations",
                Action = RegistrationOptionsFlow.Interact,
                IsAccessibleToAll = false,
                IsVoterOnly = true
            },
            new NavigationOption() {
                Name = "Vote",
                Action = VoteOptionsFlow.Interact,
                IsAccessibleToAll = false,
                IsVoterOnly = true
            },
            new NavigationOption() {
                Name = "Candidates",
                Action = CandidateOptionsFlow.Interact
            }
        };

        public static async Task InteractAsync() {
            while (true) {
                await Options();
            }
        }

        private static async Task Options() {
            int optionSectionVal = 0;

            var userFilteredOptions = CommonFlow.FilterNavigationOptions(NavigationOptions);

            do {
                CommonFlow.PrintNavigationOptions(userFilteredOptions);

                try {
                    optionSectionVal = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    CommonFlow.InvalidValueWarning();
                    continue;
                }

                if (optionSectionVal < 1 || optionSectionVal > userFilteredOptions.Count) CommonFlow.InvalidValueWarning();
            } while (optionSectionVal < 1 || optionSectionVal > userFilteredOptions.Count);

            Console.Clear();

            await userFilteredOptions[optionSectionVal - 1].Action();
        }

    }
}
