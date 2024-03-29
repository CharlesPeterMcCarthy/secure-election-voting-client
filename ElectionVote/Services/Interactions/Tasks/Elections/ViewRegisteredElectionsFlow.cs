﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Exceptions;
using ElectionVote.Services.Models.Core;

namespace ElectionVote.Services.Interactions.Tasks.Elections {
    public static class ViewRegisteredElectionsFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ Your Upcoming Registered Elections ------");

            try {
                List<Election> elections = await ElectionActions.GetUserRegisteredElections();

                if (elections.Count > 0) {
                    CommonFlow.PrintElections(elections);
                } else {
                    Console.WriteLine("You have no upcoming elections to display.");
                }
            } catch (ConsecutiveActionsException e) {
                throw e;
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Unable to get elections");
            }

            StateListener.PerformAction();

            CommonFlow.EndFlowPrompt();
        }

    }
}
