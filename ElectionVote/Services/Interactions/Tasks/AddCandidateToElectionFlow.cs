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
                List<Election> elections = await GetUpcomingElections();

                if (elections.Count > 0) {
                    PrintElections(elections);
                    Election selectedElection = GetSelectedElection(elections);
                    Candidate candidate = GetCandidateDetails(selectedElection);
                    await Candidates.CreateCandidate(candidate);
                } else {
                    Console.WriteLine("There are no upcoming elections to add a new candidate to.");
                }
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Unable to get elections");
            }
            Console.Read();
        }

        private static void PrintElections(List<Election> elections) {
            int i = 0;

            elections.ForEach(e => {
                i++;
                Console.WriteLine($"{i}: {e.ElectionName}");
            });
        }

        private static async Task<List<Election>> GetUpcomingElections() {
            String response = await HttpRequest.Get($"{API.BASE_URL}/election/all");
            GetElectionsResponseDto repsonseObj = JsonConvert.DeserializeObject<GetElectionsResponseDto>(response);

            if (!repsonseObj.Success) throw new Exception("Failed to retrieve elections");

            return repsonseObj.Elections;
        }

        private static Election GetSelectedElection(List<Election> elections) {
            int electionVal = 0;
            Election selectedEelection = null;

            do {
                Console.Write("Enter election number: ");

                try {
                    electionVal = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    InvalidValueWarning();
                    continue;
                }

                if (electionVal < 1 || electionVal > elections.Count) continue;

                selectedEelection = elections[electionVal - 1];
            } while (electionVal < 1 || electionVal > elections.Count);

            return selectedEelection;
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

        private static void InvalidValueWarning() {
            Console.WriteLine("You entered an invalid value!\n");
        }

    }
}
