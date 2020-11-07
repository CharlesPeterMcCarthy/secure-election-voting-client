using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Constants;
using ElectionVote.Services.DTO.Response;
using ElectionVote.Services.Models.Core;
using Newtonsoft.Json;

namespace ElectionVote.Services.Interactions.Tasks {
    public static class ViewElectionsFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ All Elections ------");

            try {
                String response = await HttpRequest.Get($"{API.BASE_URL}/election/all");
                GetElectionsResponseDto repsonseObj = JsonConvert.DeserializeObject<GetElectionsResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to retrieve elections");

                List<Election> elections = repsonseObj.Elections;

                if (elections.Count > 0) {
                    PrintElections(elections);
                } else {
                    Console.WriteLine("There are no elections to show.");
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
    }
}
