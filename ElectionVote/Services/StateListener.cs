using System;
using ElectionVote.Services.Exceptions;

namespace ElectionVote.Services {
    public class StateListener {

        public static void PerformAction() {
            TimeSpan timeSince = DateTime.Now - CurrentUser.LastActionPerformed;

            if (timeSince.TotalSeconds >= 180) {
                throw new LogoutException("Inactivity for more than 3 minutes", false);
            }

            CurrentUser.ActionPerformed();
        }

        public static void EndpointCall() {
            TimeSpan timeSince = DateTime.Now - CurrentUser.LastEndpointCalled;

            if (timeSince.TotalSeconds < 5) {
                throw new ConsecutiveActionsException("Quick Consecutive Actions - You are limited to one action every 5 seconds. Please wait and try again.");
            } else {
                CurrentUser.EndpointCalled();
            }                       
        }

    }
}
