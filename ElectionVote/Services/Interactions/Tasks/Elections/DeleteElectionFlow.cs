using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Models.Core;

namespace ElectionVote.Services.Interactions.Tasks.Elections {
    public static class DeleteElectionFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ Delete Election ------");
            Console.WriteLine("Which election do you want to delete?");

            try {
                List<Election> elections = await ElectionActions.GetUpcomingElections();

                if (elections.Count > 0) {
                    CommonFlow.PrintElections(elections);
                    Election selectedElection = CommonFlow.GetSelectedElection(elections);

                    bool started = await ElectionActions.DeleteElection(selectedElection.ElectionId);

                    if (started) Console.WriteLine($"{selectedElection.ElectionName} has been successfully deleted.");
                    else Console.WriteLine($"Failed to delete {selectedElection.ElectionName}.");
                } else {
                    Console.WriteLine("There are no elections to delete.");
                }
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Unable to delete election");
            }

            CommonFlow.EndFlowPrompt();
        }

    }
}
