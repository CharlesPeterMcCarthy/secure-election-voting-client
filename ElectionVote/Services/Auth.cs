using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Constants;
using ElectionVote.Services.DTO;
using ElectionVote.Services.Models;
using Newtonsoft.Json;

namespace ElectionVote.Services {

    public static class Auth {

        public static async Task<User> SignUp(String firstName, String lastName, String email, String userType) {
            Dictionary<String, String> userDetails = new Dictionary<String, String> {
                    { "firstName", firstName },
                    { "lastName", lastName },
                    { "email", email },
                    { "userType", userType }
                };

            String response = await HttpRequest.Post(API.BASE_URL + "/user", userDetails);
            CreateUserResponseDto repsonseObj = JsonConvert.DeserializeObject<CreateUserResponseDto>(response);

            if (!repsonseObj.Success) throw new Exception("Failed to create user");

            return repsonseObj.User;
        }

    }

}
