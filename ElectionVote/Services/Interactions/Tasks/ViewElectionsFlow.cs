using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Models.Core;

namespace ElectionVote.Services.Interactions.Tasks {
    public static class ViewElectionsFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ All Elections ------");

            try {
                List<Election> elections = await Elections.GetAllElections();

                if (elections.Count > 0) {
                    CommonFlow.PrintElections(elections);
                } else {
                    Console.WriteLine("There are no elections to show.");
                }
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Unable to get elections");
            }

            CommonFlow.EndFlowPrompt();
        }

    }
}
