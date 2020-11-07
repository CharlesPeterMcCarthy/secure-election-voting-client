using System;
using System.Collections.Generic;
using ElectionVote.Services.Models.Core;
using Newtonsoft.Json;

namespace ElectionVote.Services.DTO.Response {
    public class GetElectionsResponseDto : IResponse {

        [JsonProperty("elections")]
        public List<Election> Elections { get; set; }

    }
}
