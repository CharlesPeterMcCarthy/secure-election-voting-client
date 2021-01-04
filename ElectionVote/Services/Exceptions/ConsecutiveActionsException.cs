using System;
namespace ElectionVote.Services.Exceptions {
    public class ConsecutiveActionsException : Exception {

        public ConsecutiveActionsException(string message) : base(message) {}

    }
}
