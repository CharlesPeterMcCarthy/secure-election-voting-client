using System;
using ElectionVote.Services.Models.Core;
using Newtonsoft.Json;

namespace ElectionVote.Services.DTO.Response {
    public class UpdateCandidateResponseDto : IResponse {

        [JsonProperty("candidate")]
        public Candidate Candidate { get; set; }

    }
}
