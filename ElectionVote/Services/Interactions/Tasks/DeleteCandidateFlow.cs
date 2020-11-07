using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Constants;
using ElectionVote.Services.DTO.Response;
using ElectionVote.Services.Models.Core;
using Newtonsoft.Json;

namespace ElectionVote.Services.Interactions.Tasks {
    public static class DeleteCandidateFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ Delete Candidate ------");
            Console.WriteLine("From which election do you want to delete a candidate?");

            try {
                List<Election> elections = await GetUpcomingElections();

                if (elections.Count > 0) {
                    PrintElections(elections);
                    Election selectedElection = GetSelectedElection(elections);

                    if (selectedElection.Candidates.Count > 0) {
                        Console.Clear();
                        Console.WriteLine("Which candidate do you want to delete?");

                        PrintCandidates(selectedElection.Candidates);
                        Candidate candidate = GetSelectedCandidate(selectedElection.Candidates);

                        bool deleted = await Candidates.DeleteCandidate(candidate);

                        if (deleted) Console.WriteLine($"The Candidate \"{candidate.FirstName} {candidate.LastName}\" has been successfully deleted!");
                        else Console.WriteLine($"Failed to delete the Candidate \"{candidate.FirstName} {candidate.LastName}\".");
                    } else {
                        Console.WriteLine($"There are no candidates associated with {selectedElection.ElectionName} to delete.");
                    }
                } else {
                    Console.WriteLine("There are no upcoming elections to add a new candidate to.");
                }
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Unable to get elections");
            }
            Console.Read();
        }

        private static async Task<List<Election>> GetUpcomingElections() {
            String response = await HttpRequest.Get($"{API.BASE_URL}/election/all");
            GetElectionsResponseDto repsonseObj = JsonConvert.DeserializeObject<GetElectionsResponseDto>(response);

            if (!repsonseObj.Success) throw new Exception("Failed to retrieve elections");

            return repsonseObj.Elections;
        }

        private static void PrintElections(List<Election> elections) {
            int i = 0;

            elections.ForEach(e => {
                i++;
                Console.WriteLine($"{i}: {e.ElectionName}");
            });
        }

        private static void PrintCandidates(List<Candidate> candidates) {
            int i = 0;

            candidates.ForEach(c => {
                i++;
                Console.WriteLine($"{i}: {c.FirstName} {c.LastName} ({c.Party})");
            });
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

                Console.WriteLine(electionVal);
                Console.WriteLine(elections.Count);

                if (electionVal < 1 || electionVal > elections.Count) continue;

                selectedEelection = elections[electionVal - 1];
            } while (selectedEelection == null);

            return selectedEelection;
        }

        private static Candidate GetSelectedCandidate(List<Candidate> candidates) {
            int candidateVal = 0;
            Candidate selectedCandidate = null;

            do {
                Console.Write("Enter candidate number: ");

                try {
                    candidateVal = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    InvalidValueWarning();
                    continue;
                }

                if (candidateVal < 1 || candidateVal > candidates.Count) continue;

                selectedCandidate = candidates[candidateVal - 1];
            } while (candidateVal < 1 || candidateVal > candidates.Count);

            return selectedCandidate;
        }

        private static void InvalidValueWarning() {
            Console.WriteLine("You entered an invalid value!\n");
        }

    }
}
