using System;
using Newtonsoft.Json;

namespace ElectionVote.Services.DTO.Request {
    public class CreateElectionRequestDto : IRequest {

        [JsonProperty("userId")]
        public String UserId { get; set; }

        [JsonProperty("electionName")]
        public String ElectionName { get; set; }

    }
}
