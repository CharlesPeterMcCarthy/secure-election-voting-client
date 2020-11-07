using System;
using Newtonsoft.Json;

namespace ElectionVote.Services.DTO.Request {
    public class CreateCandidateRequestDto : IRequest {

        [JsonProperty("electionId")]
        public String ElectionId { get; set; }

        [JsonProperty("firstName")]
        public String FirstName { get; set; }

        [JsonProperty("lastName")]
        public String LastName { get; set; }

        [JsonProperty("party")]
        public String Party { get; set; }

    }
}
