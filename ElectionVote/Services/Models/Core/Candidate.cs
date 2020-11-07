using System;
using Newtonsoft.Json;

namespace ElectionVote.Services.Models.Core {
    public class Candidate {

        [JsonProperty("candidateId")]
        public String CandidateId { get; set; }

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
