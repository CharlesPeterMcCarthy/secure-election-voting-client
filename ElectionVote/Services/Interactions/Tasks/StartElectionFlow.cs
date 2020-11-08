﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectionVote.Services.Actions;
using ElectionVote.Services.Models.Core;

namespace ElectionVote.Services.Interactions.Tasks {
    public static class StartElectionFlow {

        public static async Task Interact() {
            Console.Clear();
            Console.WriteLine("------ Start Elections ------");
            Console.WriteLine("Which election do you want to start?");

            try {
                List<Election> elections = await Elections.GetUpcomingElections();

                if (elections.Count > 0) {
                    CommonFlow.PrintElections(elections);
                    Election selectedElection = CommonFlow.GetSelectedElection(elections);

                    bool started = await Elections.StartElection(selectedElection.ElectionId);

                    if (started) Console.WriteLine($"{selectedElection.ElectionName} has successfully started. Voters can now begin voting.");
                    else Console.WriteLine($"Failed to start {selectedElection.ElectionName}.");
                } else {
                    Console.WriteLine("There are no upcoming elections to start.");
                }
            } catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine("Unable to start election");
            }

            CommonFlow.EndFlowPrompt();
        }

    }
}
