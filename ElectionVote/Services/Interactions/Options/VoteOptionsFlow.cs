using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Interactions.Tasks.Votes;
using ElectionVote.Services.Models;

namespace ElectionVote.Services.Interactions.Options {
    public static class VoteOptionsFlow {

        private static List<NavigationOption> NavigationOptions = new List<NavigationOption>() {
            new NavigationOption() {
                Name = "Submit Vote",
                Action = SubmitVoteFlow.Interact,
                IsAccessibleToAll = false,
                IsVoterOnly = true
            }
        };

        public static async Task Interact() {
            int selectedNavOption = 0;

            Console.WriteLine("------ Voting ------");

            do {
                CommonFlow.PrintNavigationOptions(NavigationOptions, "voting");

                try {
                    selectedNavOption = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    CommonFlow.InvalidValueWarning();
                    continue;
                }

                if (selectedNavOption < 1 || selectedNavOption > NavigationOptions.Count) CommonFlow.InvalidValueWarning();
            } while (selectedNavOption < 1 || selectedNavOption > NavigationOptions.Count);

            Console.Clear();

            await NavigationOptions[selectedNavOption - 1].Action();
        }

    }
}
