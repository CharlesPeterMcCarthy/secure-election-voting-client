using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Exceptions;
using ElectionVote.Services.Models.Core;

namespace ElectionVote.Services.Interactions.Tasks.Votes {
    public class SubmitVoteFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ Submit Vote ------");
            Console.WriteLine("Which election do you want to vote in?");
            Console.WriteLine("Only elections in progress will show up here.");

            try {
                List<Election> elections = await ElectionActions.GetCurrentNonVotedElections();

                if (elections.Count > 0) {
                    CommonFlow.PrintElections(elections);
                    Election selectedElection = CommonFlow.GetSelectedElection(elections);

                    if (selectedElection.Candidates.Count > 0) await SetupVote(selectedElection);
                    else Console.WriteLine($"There are no candidates in \"{selectedElection.ElectionName}\".");
                } else {
                    Console.WriteLine("There are no elections to vote in right now.");
                }
            } catch (ConsecutiveActionsException e) {
                throw e;
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Unable to get elections");
            }

            StateListener.PerformAction();

            CommonFlow.EndFlowPrompt();
        }

        public static async Task SetupVote(Election election) {
            BallotPaper ballotPaper = await BallotPaperActions.GetElectionBallotPaper(election.ElectionId);

            Console.WriteLine("Which candidate do you want to vote for?");
            CommonFlow.PrintCandidates(election.Candidates);

            Candidate candidate = CommonFlow.GetSelectedCandidate(election.Candidates);

            bool voted = await BallotPaperActions.SubmitBallotPaperVote(ballotPaper, candidate);
            StateListener.PerformAction();

            if (voted) Console.WriteLine($"You have successfully submitted your vote for {candidate.FirstName} {candidate.LastName}!");
            else Console.WriteLine($"Unable to submit your vote for {candidate.FirstName} {candidate.LastName}.");
        }

    }
}
