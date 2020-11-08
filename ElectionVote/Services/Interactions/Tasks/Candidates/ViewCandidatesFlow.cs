using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Models.Core;

namespace ElectionVote.Services.Interactions.Tasks.Candidates {
    public static class ViewCandidatesFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ View Election Candidates ------");
            Console.WriteLine("Which election do you want to view the candidates from?");

            try {
                List<Election> elections = await ElectionActions.GetAllElections();

                if (elections.Count > 0) {
                    CommonFlow.PrintElections(elections);
                    Election selectedElection = CommonFlow.GetSelectedElection(elections);

                    if (selectedElection.Candidates.Count > 0) CommonFlow.PrintCandidates(selectedElection.Candidates);
                    else Console.WriteLine($"There are no current candidates in \"{selectedElection.ElectionName}\".");
                } else {
                    Console.WriteLine("There are no elections to view candidates from.");
                }
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Unable to get elections");
            }

            CommonFlow.EndFlowPrompt();
        }

    }
}
