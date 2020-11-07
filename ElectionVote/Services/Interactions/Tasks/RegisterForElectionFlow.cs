using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Constants;
using ElectionVote.Services.DTO.Response;
using ElectionVote.Services.Models.Core;
using Newtonsoft.Json;

namespace ElectionVote.Services.Interactions.Tasks {
    public static class RegisterForElectionFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ Election Registration ------");
            Console.WriteLine("Which election would you like to register for?");

            try {
                String response = await HttpRequest.Get($"{API.BASE_URL}/election/all-unregistered/{CurrentUser.UserID}");
                GetElectionsResponseDto repsonseObj = JsonConvert.DeserializeObject<GetElectionsResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to retrieve elections");

                List<Election> elections = repsonseObj.Elections;

                if (elections.Count > 0) {
                    await RegisterForElection(elections);
                } else {
                    Console.WriteLine("There are no elections to register for.");
                }
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Unable to get elections");
            }
            Console.Read();
        }

        private static async Task RegisterForElection(List<Election> elections) {
            int electionVal = 0;

            do {
                Console.Clear();
                Console.WriteLine("------ Election Registration ------");

                PrintElections(elections);

                Console.Write("\nEnter election number: ");

                try {
                    electionVal = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    InvalidValueWarning();
                    continue;
                }

                if (electionVal < 1 || electionVal > elections.Count) continue;

                Election selectedEelection = elections[electionVal - 1];

                Console.WriteLine($"Registering for {selectedEelection.ElectionName}");

                bool registered = await Elections.RegisterForElection(CurrentUser.UserID, selectedEelection.ElectionId);

                if (registered) {
                    Console.WriteLine($"You have successfully registered for \"{selectedEelection.ElectionName}\"!");
                } else {
                    Console.WriteLine($"Failed to register for \"{selectedEelection.ElectionName}\".");
                }
            } while (electionVal < 1 || electionVal > elections.Count);
        }

        private static void PrintElections(List<Election> elections) {
            int i = 0;

            elections.ForEach(e => {
                i++;
                Console.WriteLine($"{i}: {e.ElectionName}");
            });
        }

        private static void InvalidValueWarning() {
            Console.WriteLine("You entered an invalid value!\n");
        }

    }
}
