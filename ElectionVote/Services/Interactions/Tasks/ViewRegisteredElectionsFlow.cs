using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Models.Core;

namespace ElectionVote.Services.Interactions.Tasks {
    public static class ViewRegisteredElectionsFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ Your Upcoming Registered Elections ------");

            try {
                List<Election> elections = await Elections.GetUserUnregisteredElections();

                if (elections.Count > 0) {
                    CommonFlow.PrintElections(elections);
                } else {
                    Console.WriteLine("You have no upcoming elections to display.");
                }
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Unable to get elections");
            }

            CommonFlow.EndFlowPrompt();
        }

    }
}
