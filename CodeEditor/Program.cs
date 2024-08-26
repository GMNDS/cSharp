// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Text;
namespace GMNDS.CodeEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            ArgsVerify(args);
        }

        static void ArgsVerify(string[] args) {
            switch (args.Length)
            {
                case 0:
                    Editor("", "");
                    break;
                case 1:
                    string text = FileVerify(args[0]);
                    Editor(text, args[0]);
                    break;
                default:
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Você deve passar apenas o nome do arquivo");
                    Console.ResetColor();
                    Environment.Exit(1);
                    break;
                }
            }
        }

        static string FileVerify(string path) {
            using (StreamReader file = new StreamReader(path)) {
                if (file == null) {
                    return "";
                }
                return file.ReadToEnd();
            }
        }

        static void Editor(string text, string path) {
            StringBuilder initialText = new StringBuilder(text);

            Console.Clear();
                                        Console.WriteLine($@"
╔══════════════════════════════════════════════════════════════════════════════╗
║                           GMNDS CODE EDITOR                                  ║
╚══════════════════════════════════════════════════════════════════════════════╝");  
            while(true) {
                ConsoleKeyInfo KeyInfo = Console.ReadKey(intercept: true);

                switch (KeyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        Save(text, path);
                        break;
                    case ConsoleKey.Backspace:
                        if (text.Length > 0) {
                            text = text.Remove(text.Length - 1);
                            Console.Write("\b \b");
                        }
                        break;
                    case ConsoleKey.Enter:
                        text += Environment.NewLine;
                        Console.WriteLine();
                        break;
                    default:
                        text += KeyInfo.KeyChar;
                        Console.Write(KeyInfo.KeyChar);
                        break;
                }

            }
        }

        static void Save(string text, string? path) {
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("Deseja salvar o arquivo? (S/N)");
            if (Console.ReadKey().Key == ConsoleKey.N) {
                Environment.Exit(0);
            }

            do {
                Console.Clear();
                Console.WriteLine("Digite o nome do arquivo:");
                path = Console.ReadLine();
            }while(path == null || path == "");

            using (StreamWriter file = new StreamWriter(path)) {
                file.Write(text);
            }
            Console.WriteLine("Arquivo salvo com sucesso!");
            Environment.Exit(0);
        }
        
    }
}