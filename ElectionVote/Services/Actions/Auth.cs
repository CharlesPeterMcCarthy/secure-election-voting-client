using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Constants;
using ElectionVote.Services.DTO.Request;
using ElectionVote.Services.DTO.Response;
using ElectionVote.Services.Enums;
using ElectionVote.Services.Models;
using Newtonsoft.Json;

namespace ElectionVote.Services.Actions {

    public static class Auth {

        public static async Task<User> SignUp(String firstName, String lastName, String email, String salt, String hashedPassword, UserType userType) {
            CreateUserRequestDto dto = new CreateUserRequestDto() {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Salt = salt,
                HashedPassword = hashedPassword,
                UserType = userType.ToString()
            };

            try {
                String response = await HttpRequest.Post(API.BASE_URL + "/user", dto);
                CreateUserResponseDto repsonseObj = JsonConvert.DeserializeObject<CreateUserResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to create user");

                return repsonseObj.User;
            } catch (Exception e) {
                Console.WriteLine("Unable to sign up - An error occurred");
                return null;
            }
        }

        public static async Task<User> GetUser(String email) {
            try {
                String response = await HttpRequest.Get(API.BASE_URL + "/user/by-email/" + email);

                GetUserResponseDto repsonseObj = JsonConvert.DeserializeObject<GetUserResponseDto>(response);

                if (!repsonseObj.Success) throw new Exception("Failed to create user");

                return repsonseObj.User;
            } catch (Exception e) {
                Console.WriteLine("Unable to find user / login - An error occurred");
                return null;
            }
        }

    }

}
