using System;
using ElectionVote.Services.Models;

namespace ElectionVote.Services {
    public static class CurrentUser {

        public static String UserID { get; set; }

        public static String FirstName { get; set; }

        public static String LastName { get; set; }

        public static void SetCurrentUser(User user) {
            UserID = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }

    }
}
