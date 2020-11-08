using System;
using ElectionVote.Services.Models.Core;
using Newtonsoft.Json;

namespace ElectionVote.Services.DTO.Request {
    public class SubmitBallotPaperRequestDto : IRequest {

        [JsonProperty("ballotPaper")]
        public BallotPaper BallotPaper { get; set; }

        [JsonProperty("candidate")]
        public Candidate Candidate { get; set; }

        [JsonProperty("userId")]
        public String UserId { get; set; }

    }
}
