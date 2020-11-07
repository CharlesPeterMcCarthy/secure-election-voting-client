using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ElectionVote.Services.Models.Core {
    public class BallotPaper {

        [JsonProperty("ballotPaperId")]
        public String BallotPaperId { get; set; }

        [JsonProperty("electionId")]
        public String ElectionId { get; set; }

        [JsonProperty("userId")]
        public String UserId { get; set; }

        [JsonProperty("candidates")]
        public List<Candidate> Candidates { get; set; }

        [JsonProperty("voted")]
        public bool Voted { get; set; }

        [JsonProperty("vote")]
        public Candidate Vote { get; set; }

        [JsonProperty("voteCandidateId")]
        public String VoteCandidateId { get; set; }

    }
}
