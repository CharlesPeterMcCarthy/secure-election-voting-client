using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Interactions.Tasks.Registrations;
using ElectionVote.Services.Models;

namespace ElectionVote.Services.Interactions.Options {
    public static class RegistrationOptionsFlow {

        private static List<NavigationOption> NavigationOptions = new List<NavigationOption>() {
            new NavigationOption() {
                Name = "Register for an Election",
                Action = RegisterForElectionFlow.Interact,
                IsAccessibleToAll = false,
                IsVoterOnly = true
            },
            new NavigationOption() {
                Name = "Remove a Registration",
                Action = RemoveRegistrationFlow.Interact,
                IsAccessibleToAll = false,
                IsVoterOnly = true
            },
            new NavigationOption() {
                Name = "-- Cancel --",
                Action = null
            }
        };

        public static async Task Interact() {
            int selectedNavOption = 0;

            Console.WriteLine("------ Election Registrations ------");

            do {
                CommonFlow.PrintNavigationOptions(NavigationOptions, "election registration");

                try {
                    selectedNavOption = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    CommonFlow.InvalidValueWarning();
                    continue;
                }

                if (selectedNavOption < 1 || selectedNavOption > NavigationOptions.Count) CommonFlow.InvalidValueWarning();
            } while (selectedNavOption < 1 || selectedNavOption > NavigationOptions.Count);

            Console.Clear();

            StateListener.PerformAction();

            NavigationOption option = NavigationOptions[selectedNavOption - 1];

            if (option.Action == null) return;

            await option.Action();
        }

    }
}
