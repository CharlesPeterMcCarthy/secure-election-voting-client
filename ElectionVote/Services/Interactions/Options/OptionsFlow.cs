using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Exceptions;
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
            },
            new NavigationOption() {
                Name = "Logout",
                Action = null
            }
        };

        public static async Task InteractAsync() {
            while (true) await Options();
        }

        private static async Task Options() {
            int selectedNavOption = 0;
            var userFilteredOptions = CommonFlow.FilterNavigationOptions(NavigationOptions);

            do {
                CommonFlow.PrintNavigationOptions(userFilteredOptions, "area");

                try {
                    selectedNavOption = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    CommonFlow.InvalidValueWarning();
                    continue;
                }

                if (selectedNavOption < 1 || selectedNavOption > userFilteredOptions.Count) CommonFlow.InvalidValueWarning();
            } while (selectedNavOption < 1 || selectedNavOption > userFilteredOptions.Count);

            Console.Clear();

            StateListener.PerformAction();

            NavigationOption option = userFilteredOptions[selectedNavOption - 1];

            if (option.Action == null) throw new LogoutException("User Invoked Logout", true);

            await option.Action();
        }

    }
}
