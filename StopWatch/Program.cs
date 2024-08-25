// See https://aka.ms/new-console-template for more information
namespace GMNDS.StopWatch {
    class Program {
        
        static void Main(string[] args) {
            bool isPaused = false;
            double initialTime = 0;
            double finalTime = ArgsVerify(args);

            while( initialTime <= finalTime) {
                Console.Clear();
                Menu();
                Console.ForegroundColor = ConsoleColor.Blue;
                string timeStamp = TimeSpan.FromSeconds(initialTime).ToString(@"hh\h\:mm\m\:ss\s");
                                        Console.WriteLine($@"
            ╔══════════════════════════════════════════════════════════════════════════════╗
            ║                                 {timeStamp}                                  ║
            ╚══════════════════════════════════════════════════════════════════════════════╝");
                Console.ResetColor();
                Thread.Sleep(1000);
                if (!isPaused) {
                    initialTime++;
                }

                if (Console.KeyAvailable) {
                    ConsoleKeyInfo key = Console.ReadKey(intercept: true);

                    switch (key.Key) {
                        case ConsoleKey.P:
                            initialTime--;
                            isPaused = true;
                            break;
                        case ConsoleKey.R:
                            isPaused = false;
                            break;
                        case ConsoleKey.S:
                            initialTime = 0;
                            isPaused = true;
                            break;
                        case ConsoleKey.X:
                            Environment.Exit(0);
                            break;
                    }
                }

                
            }
        }

        static void Menu() {
                        System.Console.WriteLine(@"
            ╔══════════════════════════════════════════════════════════════════════════════╗
            ║                                   Cronômetro                                 ║
            ║------------------------------------------------------------------------------║
            ║                              [p] Pausar⏸️                                    ║
            ║                              [r] Retomar/Iniciar▶️                           ║
            ║                              [s] Reiniciar↩️                                 ║
            ║                              [x] Sair ❌                                     ║
            ╚══════════════════════════════════════════════════════════════════════════════╝");
        }

        static double ArgsVerify(string[] args) {
            double second = 1;
            double minute = 60;
            double hour = 3600;

            int argsLen = args.Length;
            if(argsLen != 1) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You must set the time correctly for the stopwatch.");
                Console.WriteLine($"stopWatch <time><s|m|h>, Example: stopWatch 10s");
                Console.ResetColor();
                Environment.Exit(1);
            }
            string input = args[0];
            double.TryParse(input.Substring(0,input.Length-1), out double time);
            char.TryParse(input.Substring(input.Length-1,1), out char unit);

            switch (unit) {
                case 's': return time * second;
                case 'm': return time * minute;
                case 'h': return time * hour;
                default: {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid time unit. Use 's' for seconds, 'm' for minutos or 'h' for hours.");
                    Console.ResetColor();
                    Environment.Exit(2);
                    return 0;
                };
            }

        }
    }
}