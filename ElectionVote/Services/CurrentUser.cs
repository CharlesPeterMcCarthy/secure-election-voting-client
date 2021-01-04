using System;
using ElectionVote.Services.Enums;
using ElectionVote.Services.Models;

namespace ElectionVote.Services {
    public static class CurrentUser {

        public static String UserID { get; set; }

        public static String FirstName { get; set; }

        public static String LastName { get; set; }

        public static UserType UserType { get; set; }

        public static bool IsAdmin { get; set; }

        public static DateTime LastActionPerformed { get; set; }

        public static DateTime LastEndpointCalled { get; set; }

        public static void SetCurrentUser(User user) {
            UserID = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserType = user.UserType;
            IsAdmin = user.UserType == UserType.ADMIN;
            ActionPerformed();
        }

        public static void UnsetCurrentUser() {
            UserID = null;
            FirstName = null;
            LastName = null;
            UserType = UserType.VOTER;
            IsAdmin = false;
        }

        public static void ActionPerformed() {
            LastActionPerformed = DateTime.Now;
        }

        public static void EndpointCalled() {
            LastEndpointCalled = DateTime.Now;
        }

    }
}
