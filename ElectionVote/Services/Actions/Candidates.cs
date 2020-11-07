using System;
using System.Threading.Tasks;
using ElectionVote.Services.Constants;
using ElectionVote.Services.DTO;
using ElectionVote.Services.DTO.Request;
using ElectionVote.Services.DTO.Response;
using ElectionVote.Services.Models.Core;
using Newtonsoft.Json;

namespace ElectionVote.Services.Actions {
    public static class Candidates {

        public static async Task<bool> CreateCandidate(Candidate candidate) {
            CreateCandidateRequestDto dto = new CreateCandidateRequestDto() {
                ElectionId = candidate.ElectionId,
                FirstName = candidate.FirstName,
                LastName = candidate.LastName,
                Party = candidate.Party
            };

            try {
                String response = await HttpRequest.Post(API.BASE_URL + "/candidate", dto);

                CreateCandidateResponseDto repsonseObj = JsonConvert.DeserializeObject<CreateCandidateResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to create Candidate");

                return true;
            } catch (Exception e) {
                Console.WriteLine("Unable to create Candidate");
                return false;
            }
        }

        public static async Task<bool> DeleteCandidate(Candidate candidate) {
            try {
                String response = await HttpRequest.Delete($"{API.BASE_URL}/candidate/{candidate.CandidateId}/{candidate.ElectionId}");

                IResponse repsonseObj = JsonConvert.DeserializeObject<IResponse>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to delete Candidate");

                return true;
            } catch (Exception e) {
                Console.WriteLine("Unable to delete Candidate");
                return false;
            }
        }

    }
}
