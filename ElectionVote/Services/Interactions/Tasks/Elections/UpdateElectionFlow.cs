using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Models.Core;

namespace ElectionVote.Services.Interactions.Tasks.Elections {
    public class UpdateElectionFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ Update Election ------");
            Console.WriteLine("Which election do you want to update?");

            try {
                List<Election> elections = await ElectionActions.GetUpcomingElections();

                if (elections.Count > 0) {
                    CommonFlow.PrintElections(elections);
                    Election selectedElection = CommonFlow.GetSelectedElection(elections);
                    Election changedElection = GetUpdatedElectionDetails(selectedElection);
                    Election updatedElection = await ElectionActions.UpdateElection(changedElection);

                    if (updatedElection != null) Console.WriteLine($"{updatedElection.ElectionName} has been successfully updated.");
                    else Console.WriteLine($"Failed to update {selectedElection.ElectionName}.");
                } else {
                    Console.WriteLine("There are no elections to update.");
                }
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Unable to update election");
            }

            CommonFlow.EndFlowPrompt();
        }

        private static Election GetUpdatedElectionDetails(Election election) {
            Console.WriteLine("For the following inputs, hit Enter to keep the current value. Or type in a new value to update.");
            Console.Write($"Election Name: ({election.ElectionName}): ");
            String electionName = Console.ReadLine();

            if (electionName != "") election.ElectionName = electionName;

            return election;
        }

    }
}
