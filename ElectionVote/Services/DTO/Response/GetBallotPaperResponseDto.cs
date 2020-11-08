using ElectionVote.Services.Models.Core;
using Newtonsoft.Json;

namespace ElectionVote.Services.DTO.Response {
    public class GetBallotPaperResponseDto : IResponse {

        [JsonProperty("ballotPaper")]
        public BallotPaper BallotPaper { get; set; }

    }
}
