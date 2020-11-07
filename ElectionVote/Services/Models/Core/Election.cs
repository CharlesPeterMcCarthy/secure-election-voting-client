using System;
using Newtonsoft.Json;

namespace ElectionVote.Services.Models.Core {
    public class Election {

        [JsonProperty("electionId")]
        public String ElectionId { get; set; }

        [JsonProperty("electionName")]
        public String ElectionName { get; set; }

    }
}
