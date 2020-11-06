using System;
using ElectionVote.Services.Models;

namespace ElectionVote.Services.DTO {
    public class CreateUserResponseDto : Response {

        public User User { get; set; }

    }
}
