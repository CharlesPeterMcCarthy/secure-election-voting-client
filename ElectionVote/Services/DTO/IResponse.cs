using System;
using Newtonsoft.Json;

namespace ElectionVote.Services.DTO {
    public class IResponse {

        [JsonProperty("success")]
        public bool Success { get; set; }

    }
}
