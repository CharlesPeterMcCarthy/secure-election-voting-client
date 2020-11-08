using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Constants;
using ElectionVote.Services.DTO.Request;
using ElectionVote.Services.DTO.Response;
using ElectionVote.Services.Models.Core;
using Newtonsoft.Json;

namespace ElectionVote.Services.Actions {
    public static class ElectionActions {

        public static async Task<List<Election>> GetAllElections() {
            try {
                String response = await HttpRequest.Get($"{API.BASE_URL}/election/all");
                GetElectionsResponseDto repsonseObj = JsonConvert.DeserializeObject<GetElectionsResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to retrieve all elections");

                return repsonseObj.Elections;
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

                return repsonseObj.Elections;
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

                return repsonseObj.Elections;
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

                return repsonseObj.Elections;
            } catch (Exception e) {
                Console.WriteLine("Unable to retrieve current elections");
                return null;
            }
        }

        public static async Task<List<Election>> GetCurrentNonVotedElections() {
            try {
                String response = await HttpRequest.Get($"{API.BASE_URL}/election/non-voted/{CurrentUser.UserID}");
                GetElectionsResponseDto repsonseObj = JsonConvert.DeserializeObject<GetElectionsResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to retrieve non-voted elections");

                return repsonseObj.Elections;
            } catch (Exception e) {
                Console.WriteLine("Unable to retrieve non-voted elections");
                return null;
            }
        }

        public static async Task<List<Election>> GetUserUnregisteredElections() {
            try {
                String response = await HttpRequest.Get($"{API.BASE_URL}/election/unregistered/{CurrentUser.UserID}/false"); // All elections
                GetElectionsResponseDto repsonseObj = JsonConvert.DeserializeObject<GetElectionsResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to retrieve unregistered elections");

                return repsonseObj.Elections;
            } catch (Exception e) {
                Console.WriteLine("Unable to retrieve unregistered elections");
                return null;
            }
        }

        public static async Task<List<Election>> GetUserRegisteredElections() {
            try {
                String response = await HttpRequest.Get($"{API.BASE_URL}/election/registered/{CurrentUser.UserID}/true"); // Upcoming elections only
                GetElectionsResponseDto repsonseObj = JsonConvert.DeserializeObject<GetElectionsResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to retrieve registered elections");

                return repsonseObj.Elections;
            } catch (Exception e) {
                Console.WriteLine("Unable to retrieve registered elections");
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

                return repsonseObj.Election;
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

                return true;
            } catch (Exception e) {
                Console.WriteLine("Unable to end election");
                return false;
            }
        }

        public static async Task<Election> UpdateElection(Election election) {
            UpdateElectionRequestDto dto = new UpdateElectionRequestDto() {
                Election = election
            };

            try {
                String response = await HttpRequest.Put($"{API.BASE_URL}/election", dto);
                ElectionResponseDto repsonseObj = JsonConvert.DeserializeObject<ElectionResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to update election");

                return repsonseObj.Election;
            } catch (Exception e) {
                Console.WriteLine("Unable to update election");
                return null;
            }
        }

        public static async Task<bool> DeleteElection(String electionId) {
            try {
                String response = await HttpRequest.Delete($"{API.BASE_URL}/election/{electionId}");
                ElectionResponseDto repsonseObj = JsonConvert.DeserializeObject<ElectionResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to delete election");

                return true;
            } catch (Exception e) {
                Console.WriteLine("Unable to delete election");
                return false;
            }
        }

    }
}
