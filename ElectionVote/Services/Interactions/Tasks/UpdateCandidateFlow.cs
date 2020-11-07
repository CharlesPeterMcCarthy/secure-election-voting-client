using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Constants;
using ElectionVote.Services.DTO.Response;
using ElectionVote.Services.Models.Core;
using Newtonsoft.Json;

namespace ElectionVote.Services.Interactions.Tasks {
    public static class UpdateCandidateFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ Update Candidate ------");
            Console.WriteLine("From which election do you want to update a candidate?");

            try {
                List<Election> elections = await GetUpcomingElections();

                if (elections.Count > 0) {
                    PrintElections(elections);
                    Election selectedElection = GetSelectedElection(elections);

                    if (selectedElection.Candidates.Count > 0) {
                        Console.Clear();
                        Console.WriteLine("Which candidate do you want to update?");

                        PrintCandidates(selectedElection.Candidates);
                        Candidate candidate = GetSelectedCandidate(selectedElection.Candidates);

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

        private static void InvalidValueWarning() {
            Console.WriteLine("You entered an invalid value!\n");
        }

    }
}
