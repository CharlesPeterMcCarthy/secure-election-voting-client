using System;
using ElectionVote.Services.Models.Core;
using Newtonsoft.Json;

namespace ElectionVote.Services.DTO.Response {
    public class UpdateElectionResponseDto : IResponse {

        [JsonProperty("election")]
        public Election Election { get; set; }

    }
}
