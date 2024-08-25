using System.Diagnostics;

namespace GMNDS.Calculator
{
    class Program 
    {
        static void Main(string[] args) {
            Menu();
        }
        static void Menu() {
            Console.Clear();
            Console.Write(@"
            ╔══════════════════════════════════════════════════════════════════════════════╗
            ║                          Escolha uma das opções abaixo                       ║
            ║------------------------------------------------------------------------------║
            ║                              [1] Soma ➕                                     ║
            ║                              [2] Subtração ➖                                ║
            ║                              [3] Divisão ➗                                  ║
            ║                              [4] Multiplicação ✖️                            ║
            ║                              [5] Sair ❌                                     ║
            ╚══════════════════════════════════════════════════════════════════════════════╝
                                            ");

            short.TryParse(Console.ReadLine(), out short input);

            switch(input) {
                case 1: ReadNums(Sum); break;
                case 2: ReadNums(Subtraction); break;
                case 3: ReadNums(Division); break;
                case 4: ReadNums(Multiplication); break;
                case 5: Environment.Exit(0); break;
                default: {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@"                   
                    ████████████████████ VOCÊ PRECISA DIGITAR UM NÚMERO VÁLIDO ████████████████████");
                    Console.ResetColor();
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao Menu...");
                    Console.ReadKey();                    
                    Menu();
                    };break;
            }
        }
        static void ReadNums(Func<double, double, double> operation) {
            while(true){
                Console.Write("Insira o primeiro valor: ");
                string inputOne = Console.ReadLine();
                Console.Write("Insira o segundo valor: ");
                string inputTwo = Console.ReadLine();

                if (double.TryParse(inputOne, out double valueOne) && double.TryParse(inputTwo, out double valueTwo)) {
                    double op = operation(valueOne, valueTwo);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Clear();
                    Console.WriteLine($@"                   
                    ████████████████████ O resultado da operação é {op} ████████████████████");
                    Console.ResetColor();
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao Menu...");
                    Console.ReadKey();
                    Menu();
                } else {
                    Console.WriteLine("Insira valores válidos válido");
                }
            }
        }  
        
        static double Sum(double ValueOne, double ValueTwo) {
            double result = ValueOne + ValueTwo;
            return result; 
        }
        static double Subtraction(double ValueOne, double ValueTwo) {
            double result = ValueOne - ValueTwo;
            return result; 
        }
        static double Division(double ValueOne, double ValueTwo) {
            double result = ValueOne / ValueTwo;
            return result; 
        }
        static double Multiplication(double ValueOne, double ValueTwo) {
            double result = ValueOne * ValueTwo;
            return result; 
        }
    }
    
}
