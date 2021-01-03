using System;
using ElectionVote.Services.Enums;
using Newtonsoft.Json;

namespace ElectionVote.Services.Models {
    public class User {

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

        [JsonProperty("userId")]
        public String UserId { get; set; }

        [JsonProperty("userType")]
        public UserType UserType { get; set; }

        [JsonProperty("times")]
        public object Times { get; set; }

    }
}
