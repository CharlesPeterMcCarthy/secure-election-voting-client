using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Models.Core;

namespace ElectionVote.Services.Interactions.Tasks {
    public static class EndElectionFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ Finish Election ------");
            Console.WriteLine("Which election do you want to end?");

            try {
                List<Election> elections = await Elections.GetCurrentElections();

                if (elections.Count > 0) {
                    CommonFlow.PrintElections(elections);
                    Election selectedElection = CommonFlow.GetSelectedElection(elections);

                    bool started = await Elections.EndElection(selectedElection.ElectionId);

                    if (started) Console.WriteLine($"{selectedElection.ElectionName} has successfully ended. Voters can no longer vote on this election.");
                    else Console.WriteLine($"Failed to end {selectedElection.ElectionName}.");
                } else {
                    Console.WriteLine("There are no ongoing elections to end.");
                }
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Unable to end election");
            }

            CommonFlow.EndFlowPrompt();
        }

    }
}
