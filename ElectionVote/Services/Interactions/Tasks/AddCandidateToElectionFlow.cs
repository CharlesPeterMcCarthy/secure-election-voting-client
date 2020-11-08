using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Constants;
using ElectionVote.Services.DTO.Response;
using ElectionVote.Services.Models.Core;
using Newtonsoft.Json;

namespace ElectionVote.Services.Interactions.Tasks {
    public static class AddCandidateToElectionFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ Add Candidate To Election ------");
            Console.WriteLine("Which election do you want to add the new candidate to?");

            try {
                List<Election> elections = await Elections.GetUpcomingElections();

                if (elections.Count > 0) {
                    CommonFlow.PrintElections(elections);
                    Election selectedElection = CommonFlow.GetSelectedElection(elections);
                    Candidate candidate = GetCandidateDetails(selectedElection);
                    bool created = await Candidates.CreateCandidate(candidate);

                    if (created) Console.WriteLine($"The Candidate \"{candidate.FirstName} {candidate.LastName}\" was successfully created!");
                    else Console.WriteLine($"Failed to create Candidate \"{candidate.FirstName} {candidate.LastName} \".");
                } else {
                    Console.WriteLine("There are no upcoming elections to add a new candidate to.");
                }
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Unable to get elections");
            }
            Console.Read();
        }

        private static Candidate GetCandidateDetails(Election election) {
            Console.Write("Enter Candidate First Name: ");
            String firstName = Console.ReadLine();
            Console.Write("Enter Candidate Last Name: ");
            String lastName = Console.ReadLine();
            Console.Write("Enter Candidate Party: ");
            String party = Console.ReadLine();

            return new Candidate() {
                FirstName = firstName,
                LastName = lastName,
                Party = party,
                ElectionId = election.ElectionId
            };
        }

    }
}
