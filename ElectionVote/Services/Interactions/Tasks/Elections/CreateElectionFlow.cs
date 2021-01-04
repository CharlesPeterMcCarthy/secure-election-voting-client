using System;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Exceptions;
using ElectionVote.Services.Models.Core;

namespace ElectionVote.Services.Interactions.Tasks.Elections {
    public static class CreateElectionFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ Create New Election ------");
            Console.WriteLine("Enter the election details.\n");

            try {
                Election election = GetElectionDetails();

                Election createdElection = await ElectionActions.CreateElection(election);

                if (createdElection != null) Console.WriteLine($"{createdElection.ElectionName} was successfully created!");
                else Console.WriteLine($"Unable to created {createdElection.ElectionName}");
            } catch (ConsecutiveActionsException e) {
                throw e;
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Unable to create election");
            }

            StateListener.PerformAction();

            CommonFlow.EndFlowPrompt();
        }

        private static Election GetElectionDetails() {
            Console.Write("Enter Election Name: ");
            String electionName = Console.ReadLine();
            StateListener.PerformAction();

            return new Election() {
                ElectionName = electionName
            };
        }

    }
}
