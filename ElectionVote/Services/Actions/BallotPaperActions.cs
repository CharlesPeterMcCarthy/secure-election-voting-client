using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Constants;
using ElectionVote.Services.DTO.Request;
using ElectionVote.Services.DTO.Response;
using ElectionVote.Services.Models.Core;
using Newtonsoft.Json;

namespace ElectionVote.Services.Actions {
    public static class BallotPaperActions {

        public static async Task<BallotPaper> GetElectionBallotPaper(String electionId) {
            try {
                String response = await HttpRequest.Get($"{API.BASE_URL}/ballot/voter/{electionId}/{CurrentUser.UserID}");
                GetBallotPaperResponseDto repsonseObj = JsonConvert.DeserializeObject<GetBallotPaperResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to retrieve ballot paper");

                return repsonseObj.BallotPaper;
            } catch (Exception e) {
                Console.WriteLine("Unable to retrieve ballot paper");
                return null;
            }
        }

        public static async Task<bool> SubmitBallotPaperVote(BallotPaper ballotPaper, Candidate candidate) {
            SubmitBallotPaperRequestDto dto = new SubmitBallotPaperRequestDto() {
                BallotPaper = ballotPaper,
                Candidate = candidate,
                UserId = CurrentUser.UserID
            };

            try {
                String response = await HttpRequest.Put($"{API.BASE_URL}/ballot/submit", dto);
                GetBallotPaperResponseDto repsonseObj = JsonConvert.DeserializeObject<GetBallotPaperResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to submit ballot paper");

                return true;
            } catch (Exception e) {
                Console.WriteLine("Unable to submit ballot paper");
                return false;
            }
        }

    }
}
