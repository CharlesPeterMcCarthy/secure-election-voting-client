using System;
using System.Threading.Tasks;
using ElectionVote.Services.Constants;
using ElectionVote.Services.DTO.Request;
using ElectionVote.Services.DTO.Response;
using Newtonsoft.Json;

namespace ElectionVote.Services.Actions {
    public static class RegistrationActions {

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

        public static async Task<bool> RemoveRegistration(String electionId) {
            RemoveRegistrationRequestDto dto = new RemoveRegistrationRequestDto() {
                UserId = CurrentUser.UserID,
                ElectionId = electionId
            };

            try {
                String response = await HttpRequest.Put(API.BASE_URL + "/election/unregister", dto);

                RemoveRegistrationResponseDto repsonseObj = JsonConvert.DeserializeObject<RemoveRegistrationResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to remove registration for election");

                return true;
            } catch (Exception e) {
                Console.WriteLine("Unable to remove registration for election");
                return false;
            }
        }

    }
}
