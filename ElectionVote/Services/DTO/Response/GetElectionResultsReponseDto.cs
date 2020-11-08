using System;
using ElectionVote.Services.Models.Core;
using Newtonsoft.Json;

namespace ElectionVote.Services.DTO.Response {
    public class GetElectionResultsReponseDto : IResponse {

        [JsonProperty("election")]
        public Election Election { get; set; }

        //[JsonProperty("winner")]
        //public Candidate Winner { get; set; }

    }
}
