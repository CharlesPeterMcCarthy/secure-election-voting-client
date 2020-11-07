using System;
using ElectionVote.Services.Models.Core;
using Newtonsoft.Json;

namespace ElectionVote.Services.DTO.Response {
    public class CreateCandidateResponseDto : IResponse {

        [JsonProperty("candidate")]
        public Candidate Candidate { get; set; }

    }
}
