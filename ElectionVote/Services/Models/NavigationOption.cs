using System;
using System.Threading.Tasks;

namespace ElectionVote.Services.Models {

    public class NavigationOption {

        public String Name { get; set; }

        public Func<Task> Action { get; set; }

        public bool IsAccessibleToAll { get; set; } = true;

        public bool IsAdminOnly { get; set; } = false;

        public bool IsVoterOnly { get; set; } = false;

    }

}
