using System;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Models.Core;

namespace ElectionVote.Services.Interactions.Tasks {
    public static class CreateElectionFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ Create New Election ------");
            Console.WriteLine("Enter the election details.\n");

            try {
                Election election = GetElectionDetails();

                Election createdElection = await Elections.CreateElection(election);

                if (createdElection != null) Console.WriteLine($"{createdElection.ElectionName} was successfully created!");
                else Console.WriteLine($"Unable to created {createdElection.ElectionName}");
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Unable to create election");
            }

            CommonFlow.EndFlowPrompt();
        }

        private static Election GetElectionDetails() {
            Console.Write("Enter Election Name: ");
            String electionName = Console.ReadLine();

            return new Election() {
                ElectionName = electionName
            };
        }

    }
}
