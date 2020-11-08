using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ElectionVote.Services.Models.Core {
    public class Election {

        [JsonProperty("electionId")]
        public String ElectionId { get; set; }

        [JsonProperty("electionName")]
        public String ElectionName { get; set; }

        [JsonProperty("electionStarted")]
        public Boolean ElectionStarted { get; set; }

        [JsonProperty("electionFinished")]
        public Boolean ElectionFinished { get; set; }

        [JsonProperty("candidates")]
        public List<Candidate> Candidates { get; set; }

    }
}
