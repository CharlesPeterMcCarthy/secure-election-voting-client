using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Models.Core;

namespace ElectionVote.Services.Interactions.Tasks {
    public static class DeleteCandidateFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ Delete Candidate ------");
            Console.WriteLine("From which election do you want to delete a candidate?");

            try {
                List<Election> elections = await ElectionActions.GetUpcomingElections();

                if (elections.Count > 0) {
                    CommonFlow.PrintElections(elections);
                    Election selectedElection = CommonFlow.GetSelectedElection(elections);

                    if (selectedElection.Candidates.Count > 0) {
                        Console.Clear();
                        Console.WriteLine("Which candidate do you want to delete?");

                        CommonFlow.PrintCandidates(selectedElection.Candidates);
                        Candidate candidate = CommonFlow.GetSelectedCandidate(selectedElection.Candidates);

                        bool deleted = await Candidates.DeleteCandidate(candidate);

                        if (deleted) Console.WriteLine($"The Candidate \"{candidate.FirstName} {candidate.LastName}\" has been successfully deleted!");
                        else Console.WriteLine($"Failed to delete the Candidate \"{candidate.FirstName} {candidate.LastName}\".");
                    } else {
                        Console.WriteLine($"There are no candidates associated with {selectedElection.ElectionName} to delete.");
                    }
                } else {
                    Console.WriteLine("There are no upcoming elections to delete a candidate from.");
                }
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Unable to delete candidate");
            }

            CommonFlow.EndFlowPrompt();
        }

    }
}
