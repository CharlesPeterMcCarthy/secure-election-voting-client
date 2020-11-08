using System;
using Newtonsoft.Json;

namespace ElectionVote.Services.DTO.Request {
    public class RemoveRegistrationRequestDto : IRequest {

        [JsonProperty("userId")]
        public String UserId { get; set; }

        [JsonProperty("electionId")]
        public String ElectionId { get; set; }

    }
}
