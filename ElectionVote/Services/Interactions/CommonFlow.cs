using System;
using System.Collections.Generic;
using ElectionVote.Services.Models.Core;

namespace ElectionVote.Services.Interactions {
    public static class CommonFlow {

        public static void EndFlowPrompt() {
            Console.WriteLine("\nHit the Enter key to go back.");
            Console.Read();
            Console.Clear();
        }

        public static void PrintElections(List<Election> elections) {
            int i = 0;

            elections.ForEach(e => {
                i++;
                Console.Write($"{i}: {e.ElectionName}");
                if (e.ElectionFinished) Console.Write(" (Finished)");
                else if (e.ElectionStarted) Console.Write(" (Ongoing)");
                Console.WriteLine();
            });
        }

        public static void PrintCandidates(List<Candidate> candidates) {
            int i = 0;

            candidates.ForEach(c => {
                i++;
                Console.WriteLine($"{i}: {c.FirstName} {c.LastName} ({c.Party})");
            });
        }

        public static Election GetSelectedElection(List<Election> elections) {
            int electionVal = 0;
            Election selectedEelection = null;

            do {
                Console.Write("Enter election number: ");

                try {
                    electionVal = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    CommonFlow.InvalidValueWarning();
                    continue;
                }

                if (electionVal < 1 || electionVal > elections.Count) continue;

                selectedEelection = elections[electionVal - 1];
            } while (electionVal < 1 || electionVal > elections.Count);

            return selectedEelection;
        }

        public static Candidate GetSelectedCandidate(List<Candidate> candidates) {
            int candidateVal = 0;
            Candidate selectedCandidate = null;

            do {
                Console.Write("Enter candidate number: ");

                try {
                    candidateVal = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    CommonFlow.InvalidValueWarning();
                    continue;
                }

                if (candidateVal < 1 || candidateVal > candidates.Count) continue;

                selectedCandidate = candidates[candidateVal - 1];
            } while (candidateVal < 1 || candidateVal > candidates.Count);

            return selectedCandidate;
        }

        public static void InvalidValueWarning() {
            Console.WriteLine("You entered an invalid value!\n");
        }

    }
}
