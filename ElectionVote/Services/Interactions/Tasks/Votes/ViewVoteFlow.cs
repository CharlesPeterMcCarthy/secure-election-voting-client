using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Exceptions;
using ElectionVote.Services.Models.Core;

namespace ElectionVote.Services.Interactions.Tasks.Votes {
    public class ViewVoteFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ View Votes ------");
            Console.WriteLine("Which election do you want to view your previous vote in?");

            try {
                List<Election> elections = await ElectionActions.GetVotedElections();

                if (elections.Count > 0) {
                    CommonFlow.PrintElections(elections);
                    Election selectedElection = CommonFlow.GetSelectedElection(elections);

                    if (selectedElection.Candidates.Count > 0) await DisplayVote(selectedElection);
                    else Console.WriteLine($"There are no candidates in \"{selectedElection.ElectionName}\" so you couldn't have voted yet.");
                } else {
                    Console.WriteLine("You have not voted in any elections yet.");
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

        public static async Task DisplayVote(Election election) {
            BallotPaper ballotPaper = await BallotPaperActions.GetElectionBallotPaper(election.ElectionId);
            StateListener.PerformAction();

            Console.WriteLine($"Here is how you voted for the {election.ElectionName}:");
            Console.WriteLine($"You voted for {ballotPaper.Vote.FirstName} {ballotPaper.Vote.LastName}!");
        }

    }
}
