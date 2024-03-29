﻿using System;
using System.Collections.Generic;
using ElectionVote.Services.Models;
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
                if (!e.ElectionStarted && !e.ElectionFinished) Console.Write(" (New)");
                else if (e.ElectionFinished) Console.Write(" (Finished)");
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

        public static void PrintNavigationOptions(List<NavigationOption> navigationOptions, String optionsSection) {
            int index = 0;
            Console.WriteLine($"What {optionsSection} option would you like?");
            Console.WriteLine("Options:");

            navigationOptions.ForEach(option => {
                if (option.IsAccessibleToAll || (option.IsAdminOnly && CurrentUser.IsAdmin) || (option.IsVoterOnly && !CurrentUser.IsAdmin)) {
                    index++;
                    Console.WriteLine($"{index}) {option.Name}");
                }
            });
        }

        public static void PrintAuthtenticationOptions(List<AuthenticationOption> authOptions) {
            int index = 0;

            authOptions.ForEach(option => {
                index++;
                Console.WriteLine($"{index}) {option.Name}");
            });
        }

        public static List<NavigationOption> FilterNavigationOptions(List<NavigationOption> navigationOptions) {
            if (CurrentUser.IsAdmin) return navigationOptions.FindAll(option => option.IsAccessibleToAll || option.IsAdminOnly);
            return navigationOptions.FindAll(option => option.IsAccessibleToAll || option.IsVoterOnly);
        }

        public static void InvalidValueWarning() {
            Console.WriteLine("You entered an invalid value!\n");
        }

    }
}
