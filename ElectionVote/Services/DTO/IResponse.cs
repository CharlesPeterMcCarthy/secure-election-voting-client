using System;
using Newtonsoft.Json;

namespace ElectionVote.Services.DTO {
    public abstract class Response {

        [JsonProperty("success")]
        public bool Success { get; set; }

    }
}
