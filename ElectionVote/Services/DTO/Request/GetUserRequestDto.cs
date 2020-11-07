using System;
using Newtonsoft.Json;

namespace ElectionVote.Services.DTO.Request {
    public class GetUserRequestDto : IRequest {

        [JsonProperty("userId")]
        public String UserId { get; set; }

        [JsonProperty("firstName")]
        public String FirstName { get; set; }

        [JsonProperty("lastName")]
        public String LastName { get; set; }

        [JsonProperty("email")]
        public String Email { get; set; }

        [JsonProperty("userType")]
        public String UserType { get; set; }

    }
}
