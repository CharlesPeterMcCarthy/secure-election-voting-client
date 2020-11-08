using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.DTO.Response;
using ElectionVote.Services.Models.Core;

namespace ElectionVote.Services.Interactions.Tasks.Elections {
    public static class ViewElectionResultsFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ Election Results ------");
            Console.WriteLine("Which election do you want to see the results for?");

            try {
                List<Election> elections = await ElectionActions.GetFinishedElections();

                if (elections.Count > 0) {
                    CommonFlow.PrintElections(elections);

                    Election selectedElection = CommonFlow.GetSelectedElection(elections);

                    //Election results = await ElectionActions.GetElectionResults(selectedElection.ElectionId);

                    PrintResults(selectedElection);
                } else {
                    Console.WriteLine("There are no elections to show.");
                }
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Unable to get elections");
            }

            CommonFlow.EndFlowPrompt();
        }

        private static void PrintResults(Election election) {
            Console.Clear();
            Console.WriteLine($"***** Results of {election.ElectionName} *****");
            Console.WriteLine($"WINNER: {election.Winner.FirstName} {election.Winner.LastName}");
        }

    }
}
