using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Exceptions;
using ElectionVote.Services.Models.Core;

namespace ElectionVote.Services.Interactions.Tasks.Registrations {
    public class RemoveRegistrationFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ Remove Election Registration ------");
            Console.WriteLine("Which election would you like to remove your registration from?");
            Console.WriteLine("Note: You can only remove a registration if the election hasn't started yet.");

            try {
                List<Election> elections = await ElectionActions.GetUserRegisteredElections();

                if (elections.Count > 0) {
                    CommonFlow.PrintElections(elections);
                    Election selectedElection = CommonFlow.GetSelectedElection(elections);

                    bool removed = await RegistrationActions.RemoveRegistration(selectedElection.ElectionId);

                    if (removed) Console.WriteLine($"You have successfully removed your registration for {selectedElection.ElectionName}");
                    else Console.WriteLine($"Failed to removed your registration for {selectedElection.ElectionName}");
                } else {
                    Console.WriteLine("There are no elections to remove your registration from.");
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

    }
}
