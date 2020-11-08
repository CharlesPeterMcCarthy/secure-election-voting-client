using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Models.Core;

namespace ElectionVote.Services.Interactions.Tasks.Registrations {
    public static class RegisterForElectionFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ Election Registration ------");
            Console.WriteLine("Which election would you like to register for?");

            try {
                List<Election> elections = await ElectionActions.GetUserUnregisteredElections();

                if (elections.Count > 0) {
                    await RegisterForElection(elections);
                } else {
                    Console.WriteLine("There are no elections to register for.");
                }
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Unable to get elections");
            }

            CommonFlow.EndFlowPrompt();
        }

        private static async Task RegisterForElection(List<Election> elections) {
            int electionVal = 0;

            do {
                Console.Clear();
                Console.WriteLine("------ Election Registration ------");

                CommonFlow.PrintElections(elections);

                Console.Write("\nEnter election number: ");

                try {
                    electionVal = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    CommonFlow.InvalidValueWarning();
                    continue;
                }

                if (electionVal < 1 || electionVal > elections.Count) continue;

                Election selectedEelection = elections[electionVal - 1];

                Console.WriteLine($"Registering for {selectedEelection.ElectionName}");

                bool registered = await RegistrationActions.RegisterForElection(CurrentUser.UserID, selectedEelection.ElectionId);

                if (registered) {
                    Console.WriteLine($"You have successfully registered for \"{selectedEelection.ElectionName}\"!");
                } else {
                    Console.WriteLine($"Failed to register for \"{selectedEelection.ElectionName}\".");
                }
            } while (electionVal < 1 || electionVal > elections.Count);
        }

    }
}
