using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Interactions.Tasks.Elections;
using ElectionVote.Services.Models;

namespace ElectionVote.Services.Interactions.Options {
    public static class ElectionOptionsFlow {

        private static List<NavigationOption> NavigationOptions = new List<NavigationOption>() {
            new NavigationOption() {
                Name = "View All Elections",
                Action = ViewElectionsFlow.Interact
            },
            new NavigationOption() {
                Name = "View Upcoming Elections I've Registered For",
                Action = ViewRegisteredElectionsFlow.Interact,
                IsAccessibleToAll = false,
                IsVoterOnly = true
            },
            new NavigationOption() {
                Name = "View Election Results",
                Action = ViewElectionResultsFlow.Interact,
                IsAccessibleToAll = false,
                IsAdminOnly = true
            },
            new NavigationOption() {
                Name = "Create Election",
                Action = CreateElectionFlow.Interact,
                IsAccessibleToAll = false,
                IsAdminOnly = true
            },
            new NavigationOption() {
                Name = "Start Election",
                Action = StartElectionFlow.Interact,
                IsAccessibleToAll = false,
                IsAdminOnly = true
            },
            new NavigationOption() {
                Name = "End Election",
                Action = EndElectionFlow.Interact,
                IsAccessibleToAll = false,
                IsAdminOnly = true
            },
            new NavigationOption() {
                Name = "Update Election Details",
                Action = UpdateElectionFlow.Interact,
                IsAccessibleToAll = false,
                IsAdminOnly = true
            },
            new NavigationOption() {
                Name = "Delete Election",
                Action = DeleteElectionFlow.Interact,
                IsAccessibleToAll = false,
                IsAdminOnly = true
            },
            new NavigationOption() {
                Name = "-- Cancel --",
                Action = null
            }
        };

        public static async Task Interact() {
            int selectedNavOption = 0;
            var userFilteredOptions = CommonFlow.FilterNavigationOptions(NavigationOptions);

            Console.WriteLine("------ Elections ------");

            do {
                CommonFlow.PrintNavigationOptions(userFilteredOptions, "election");

                try {
                    selectedNavOption = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    CommonFlow.InvalidValueWarning();
                    continue;
                }

                if (selectedNavOption < 1 || selectedNavOption > userFilteredOptions.Count) CommonFlow.InvalidValueWarning();
            } while (selectedNavOption < 1 || selectedNavOption > userFilteredOptions.Count);

            Console.Clear();

            NavigationOption option = userFilteredOptions[selectedNavOption - 1];

            if (option.Action == null) return;

            await option.Action();
        }

    }
}
