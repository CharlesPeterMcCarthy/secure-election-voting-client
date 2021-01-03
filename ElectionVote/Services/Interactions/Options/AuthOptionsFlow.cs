using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Enums;
using ElectionVote.Services.Interactions.Tasks.Authtentication;
using ElectionVote.Services.Models;

namespace ElectionVote.Services.Interactions {
    public static class AuthOptionsFlow {

        private static List<AuthenticationOption> AuthenticationOptions = new List<AuthenticationOption>() {
            new AuthenticationOption() {
                Name = "Login",
                Action = LoginFlow.Interact
            },
            new AuthenticationOption() {
                Name = "Sign Up",
                Action = SignUpFlow.Interact
            }
        };

        public static async Task<User> Interact() {
            User user = null;
            int selectedVal = 0;

            do {
                Console.Write("Are you Logging in or Signing up? ");
                CommonFlow.PrintAuthtenticationOptions(AuthenticationOptions);

                try {
                    selectedVal = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    CommonFlow.InvalidValueWarning();
                    continue;
                }

                if (selectedVal < 1 || selectedVal > AuthenticationOptions.Count) CommonFlow.InvalidValueWarning();
            } while (selectedVal < 1 || selectedVal > AuthenticationOptions.Count);

            Console.Clear();

            return await AuthenticationOptions[selectedVal - 1].Action();
        }

    }
}
