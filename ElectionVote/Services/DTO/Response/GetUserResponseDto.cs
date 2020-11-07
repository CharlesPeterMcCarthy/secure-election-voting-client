using System;
using ElectionVote.Services.Models;

namespace ElectionVote.Services.DTO.Response {
    public class GetUserResponseDto : IResponse {

        public User User { get; set; }

    }
}
