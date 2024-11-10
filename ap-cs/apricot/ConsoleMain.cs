
namespace apricot
{
    public class ConsoleMain
    {
        private bool activeConsole = true;

        //public async Task RunAsync()
        public void RunAsync()
        {
            int consoleAction = 0;
            string userOption = string.Empty;
            const string noResponse = "none";
            var defaultForeground = Console.ForegroundColor;

            while (activeConsole)
            {
                Console.WriteLine(" 1. Do Something");
                Console.WriteLine(" 2. Do Something Else");
                Console.WriteLine(" x. Exit");

                userOption = Console.ReadLine() ?? noResponse;

                if (userOption.ToLower() == "x")
                    activeConsole = false;
                else if (userOption == noResponse)
                    activeConsole = true;
                else 
                {
                    if (int.TryParse(userOption, out consoleAction))
                    {
                        Console.WriteLine($"Your action is {userOption}");
                    }
                    else 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Invalid Option {userOption}");
                        Console.ForegroundColor = defaultForeground;
                    }
                }
            }
        }
    }
}