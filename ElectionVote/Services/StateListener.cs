using System;
using ElectionVote.Services.Exceptions;

namespace ElectionVote.Services {
    public class StateListener {

        public static void PerformAction() {
            TimeSpan timeSince = DateTime.Now - CurrentUser.LastActionPerformed;

            if (timeSince.TotalSeconds >= 10) {
                throw new LogoutException("Inactivity for more than 60 seconds", false);
            }

            CurrentUser.ActionPerformed();
        }

    }
}
