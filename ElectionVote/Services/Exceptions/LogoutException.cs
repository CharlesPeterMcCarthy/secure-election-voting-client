using System;
namespace ElectionVote.Services.Exceptions {
    public class LogoutException: Exception {

        public bool IsUserInvoked { get; set; }

        public LogoutException(string message, bool isUserInvokved): base(message) {
            IsUserInvoked = isUserInvokved;
        }

    }
}
