using System;
using ElectionVote.Services.Models.Core;
using Newtonsoft.Json;

namespace ElectionVote.Services.DTO.Request {
    public class UpdateCandidateRequestDto : IRequest {

        [JsonProperty("candidate")]
        public Candidate Candidate { get; set; }

    }
}
