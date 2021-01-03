using System;
using Newtonsoft.Json;

namespace ElectionVote.Services.DTO.Request {
    public class CreateUserRequestDto : IRequest {

        [JsonProperty("firstName")]
        public String FirstName { get; set; }

        [JsonProperty("lastName")]
        public String LastName { get; set; }

        [JsonProperty("email")]
        public String Email { get; set; }

        [JsonProperty("salt")]
        public String Salt { get; set; }

        [JsonProperty("hashedPassword")]
        public String HashedPassword { get; set; }

        [JsonProperty("userType")]
        public String UserType { get; set; }

    }
}
