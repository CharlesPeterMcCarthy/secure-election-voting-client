using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Interactions.Tasks.Candidates;
using ElectionVote.Services.Models;

namespace ElectionVote.Services.Interactions.Options {
    public static class CandidateOptionsFlow {

        private static List<NavigationOption> NavigationOptions = new List<NavigationOption>() {
            new NavigationOption() {
                Name = "View Election Candidates",
                Action = ViewCandidatesFlow.Interact
            },
            new NavigationOption() {
                Name = "Add Candidate To Election",
                Action = AddCandidateToElectionFlow.Interact,
                IsAccessibleToAll = false,
                IsAdminOnly = true
            },
            new NavigationOption() {
                Name = "Update Candidate",
                Action = UpdateCandidateFlow.Interact,
                IsAccessibleToAll = false,
                IsAdminOnly = true
            },
            new NavigationOption() {
                Name = "Delete Candidate",
                Action = DeleteCandidateFlow.Interact,
                IsAccessibleToAll = false,
                IsAdminOnly = true
            }
        };

        public static async Task Interact() {
            int selectedNavOption = 0;
            var userFilteredOptions = CommonFlow.FilterNavigationOptions(NavigationOptions);

            Console.WriteLine("------ Candidates ------");

            do {
                CommonFlow.PrintNavigationOptions(userFilteredOptions, "candidate");

                try {
                    selectedNavOption = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    CommonFlow.InvalidValueWarning();
                    continue;
                }

                if (selectedNavOption < 1 || selectedNavOption > userFilteredOptions.Count) CommonFlow.InvalidValueWarning();
            } while (selectedNavOption < 1 || selectedNavOption > userFilteredOptions.Count);

            Console.Clear();

            await userFilteredOptions[selectedNavOption - 1].Action();
        }

    }
}
