using System;
using System.Threading.Tasks;

namespace ElectionVote.Services.Models {
    public class AuthenticationOption : OptionType {

        public String Name { get; set; }

        public Func<Task<User>> Action { get; set; }

    }
}
