using System;
using ElectionVote.Services.Models.Core;
using Newtonsoft.Json;

namespace ElectionVote.Services.DTO.Request {
    public class UpdateElectionRequestDto : IRequest {

        [JsonProperty("election")]
        public Election Election { get; set; }

    }
}
