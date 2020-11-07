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
                Console.WriteLine(API.BASE_URL + "/election/all-unregistered/" + "c47962a6-283f-41ef-b929-6da771cb39ae");
                String response = await HttpRequest.Get(API.BASE_URL + "/election/all-unregistered/" + "c47962a6-283f-41ef-b929-6da771cb39ae");
                GetElectionsResponseDto repsonseObj = JsonConvert.DeserializeObject<GetElectionsResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to retrieve elections");

                List<Election> elections = repsonseObj.Elections;

                if (elections.Count > 0) {
                    PrintElections(repsonseObj.Elections);
                    Console.Write("\nEnter election number: ");

                    int electionVal = 0;
                    try {
                        electionVal = int.Parse(Console.ReadLine());
                    } catch (FormatException) {
                        InvalidValueWarning();
                        //continue;
                    }

                    Election selectedEelection = elections[electionVal - 1];

                    Console.WriteLine($"Registering for {selectedEelection.ElectionName}");

                    await Elections.RegisterForElection("testid", selectedEelection.ElectionId);
                } else {
                    Console.WriteLine("There are no elections to register for.");
                }
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Unable to get elections");
            }
            Console.Read();
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
