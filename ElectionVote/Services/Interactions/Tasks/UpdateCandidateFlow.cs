using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Models.Core;

namespace ElectionVote.Services.Interactions.Tasks {
    public static class UpdateCandidateFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ Update Candidate ------");
            Console.WriteLine("From which election do you want to update a candidate?");

            try {
                List<Election> elections = await ElectionActions.GetUpcomingElections();

                if (elections.Count > 0) {
                    CommonFlow.PrintElections(elections);
                    Election selectedElection = CommonFlow.GetSelectedElection(elections);

                    if (selectedElection.Candidates.Count > 0) {
                        Console.Clear();
                        Console.WriteLine("Which candidate do you want to update?");

                        CommonFlow.PrintCandidates(selectedElection.Candidates);

                        Candidate candidate = CommonFlow.GetSelectedCandidate(selectedElection.Candidates);
                        Candidate changedCandidate = GetUpdatedCandidateDetails(candidate);
                        Candidate updatedCandidate = await Candidates.UpdateCandidate(candidate);

                        if (updatedCandidate != null) Console.WriteLine($"The Candidate \"{updatedCandidate.FirstName} {updatedCandidate.LastName}\" has been successfully updated!");
                        else Console.WriteLine($"Failed to update the Candidate \"{candidate.FirstName} {candidate.LastName}\".");
                    } else {
                        Console.WriteLine($"There are no candidates associated with {selectedElection.ElectionName} to update.");
                    }
                } else {
                    Console.WriteLine("There are no upcoming elections to choose a candidate to update from.");
                }
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Unable to update candidate");
            }

            CommonFlow.EndFlowPrompt();
        }

        private static Candidate GetUpdatedCandidateDetails(Candidate candidate) {
            Console.WriteLine("For the following inputs, hit Enter to keep the current value. Or type in a new value to update.");
            Console.Write($"Candidate First Name: ({candidate.FirstName}): ");
            String updatedFirstName = Console.ReadLine();
            Console.Write($"Candidate Last Name: ({candidate.LastName}): ");
            String updatedLasttName = Console.ReadLine();
            Console.Write($"Candidate Party: ({candidate.Party}): ");
            String updatedParty = Console.ReadLine();

            if (updatedFirstName != "") candidate.FirstName = updatedFirstName;
            if (updatedLasttName != "") candidate.LastName = updatedLasttName;
            if (updatedParty != "") candidate.Party = updatedParty;

            return candidate;
        }

    }
}
