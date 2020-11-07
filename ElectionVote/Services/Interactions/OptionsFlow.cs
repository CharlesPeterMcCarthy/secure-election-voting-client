using System;
namespace ElectionVote.Services.Interactions {
    public static class OptionsFlow {

        public static void Interact() {
            int optionSectionVal = 0;

            do {
                Console.WriteLine("What type of options would like?");
                Console.WriteLine("Options:");
                Console.WriteLine("1) Elections");
                Console.WriteLine("2) Registrations");
                Console.WriteLine("3) My Account");

                try { 
                    optionSectionVal = int.Parse(Console.ReadLine());
                } catch (FormatException) {
                    InvalidValueWarning();
                    continue;
                }

            } while (optionSectionVal < 1 || optionSectionVal > 3);

            Console.Clear();

            switch (optionSectionVal) {
                case 1: // Elecctions
                    break;
                case 2: // Registrations
                    break;
                case 3: // My Account
                    break;
                default:
                    break;
            }
        }

        private static void InvalidValueWarning() {
            Console.WriteLine("You entered an invalid value!\n");
        }

    }
}
