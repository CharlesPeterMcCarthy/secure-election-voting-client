using System;
using ElectionVote.Services.Models;

namespace ElectionVote.Services.DTO.Response {
    public class CreateUserResponseDto : IResponse {

        public User User { get; set; }

    }
}
