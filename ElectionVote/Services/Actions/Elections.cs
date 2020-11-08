using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Constants;
using ElectionVote.Services.DTO.Request;
using ElectionVote.Services.DTO.Response;
using ElectionVote.Services.Models.Core;
using Newtonsoft.Json;

namespace ElectionVote.Services.Actions {
    public static class Elections {

        public static async Task<bool> RegisterForElection(String userId, String electionId) {
            RegisterForElectionRequestDto dto = new RegisterForElectionRequestDto() {
                UserId = userId,
                ElectionId = electionId
            };

            try {
                String response = await HttpRequest.Post(API.BASE_URL + "/election/register", dto);

                RegisterForElectionResponseDto repsonseObj = JsonConvert.DeserializeObject<RegisterForElectionResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to register for election");

                return true;
            } catch (Exception e) {
                Console.WriteLine("Unable to register for election");
                return false;
            }
        }

        public static async Task<List<Election>> GetAllElections() {
            try {
                String response = await HttpRequest.Get($"{API.BASE_URL}/election/all");
                GetElectionsResponseDto repsonseObj = JsonConvert.DeserializeObject<GetElectionsResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to retrieve all elections");

                List<Election> elections = repsonseObj.Elections;

                return elections;
            } catch (Exception e) {
                Console.WriteLine("Unable to retrieve all elections");
                return null;
            }
        }

        public static async Task<List<Election>> GetUpcomingElections() {
            try {
                String response = await HttpRequest.Get($"{API.BASE_URL}/election/upcoming");
                GetElectionsResponseDto repsonseObj = JsonConvert.DeserializeObject<GetElectionsResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to retrieve upcoming elections");

                List<Election> elections = repsonseObj.Elections;

                return elections;
            } catch (Exception e) {
                Console.WriteLine("Unable to retrieve upcoming elections");
                return null;
            }
        }

        public static async Task<List<Election>> GetUFinishedElections() {
            try {
                String response = await HttpRequest.Get($"{API.BASE_URL}/election/finished");
                GetElectionsResponseDto repsonseObj = JsonConvert.DeserializeObject<GetElectionsResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to retrieve finished elections");

                List<Election> elections = repsonseObj.Elections;

                return elections;
            } catch (Exception e) {
                Console.WriteLine("Unable to retrieve finished elections");
                return null;
            }
        }

        public static async Task<List<Election>> GetCurrentElections() {
            try {
                String response = await HttpRequest.Get($"{API.BASE_URL}/election/current");
                GetElectionsResponseDto repsonseObj = JsonConvert.DeserializeObject<GetElectionsResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to retrieve current elections");

                List<Election> elections = repsonseObj.Elections;

                return elections;
            } catch (Exception e) {
                Console.WriteLine("Unable to retrieve current elections");
                return null;
            }
        }

        public static async Task<List<Election>> GetUserUnregisteredElections() {
            try {
                String response = await HttpRequest.Get($"{API.BASE_URL}/election/all-registered/{CurrentUser.UserID}");
                GetElectionsResponseDto repsonseObj = JsonConvert.DeserializeObject<GetElectionsResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to retrieve unregistered elections");

                List<Election> elections = repsonseObj.Elections;

                return elections;
            } catch (Exception e) {
                Console.WriteLine("Unable to retrieve unregistered elections");
                return null;
            }
        }

        public static async Task<Election> CreateElection(Election election) {
            CreateElectionRequestDto dto = new CreateElectionRequestDto() {
                UserId = CurrentUser.UserID,
                ElectionName = election.ElectionName
            };

            try {
                String response = await HttpRequest.Post($"{API.BASE_URL}/election", dto);
                ElectionResponseDto repsonseObj = JsonConvert.DeserializeObject<ElectionResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to create election");

                Election created = repsonseObj.Election;

                return created;
            } catch (Exception e) {
                Console.WriteLine("Unable to create election");
                return null;
            }
        }

        public static async Task<bool> StartElection(String electionId) {
            try {
                String response = await HttpRequest.Put($"{API.BASE_URL}/election/start/{electionId}", null);
                ElectionResponseDto repsonseObj = JsonConvert.DeserializeObject<ElectionResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to start election");

                Election election = repsonseObj.Election;

                return true;
            } catch (Exception e) {
                Console.WriteLine("Unable to start election");
                return false;
            }
        }

        public static async Task<bool> EndElection(String electionId) {
            try {
                String response = await HttpRequest.Put($"{API.BASE_URL}/election/finish/{electionId}", null);
                ElectionResponseDto repsonseObj = JsonConvert.DeserializeObject<ElectionResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to end election");

                Election election = repsonseObj.Election;

                return true;
            } catch (Exception e) {
                Console.WriteLine("Unable to end election");
                return false;
            }
        }

    }
}
