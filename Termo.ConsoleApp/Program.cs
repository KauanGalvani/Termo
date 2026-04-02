namespace Termo.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {


            while (true) //loop principal
            {
                string? palavraDigitada;
                while (true) //loop para validação, verifica se o usuario esta jogando de acordo com as regras.
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Jogo Termo");
                    Console.WriteLine("--------------------------");

                    Console.WriteLine("");

                    Console.Write(">");
                    palavraDigitada = Console.ReadLine();

                    if (palavraDigitada?.Length < 5 ||
                       string.IsNullOrWhiteSpace(palavraDigitada) ||
                       palavraDigitada.Any(char.IsDigit)||
                       palavraDigitada?.Length > 5) // estudar o tratamenter de erro de caracteres.
                    {
                        Console.WriteLine("sua palavra deve ter no maximo 5 caracteres sem espaços ou numero");
                        Console.WriteLine("\nDigite ENTER para digitar novamente...");
                        Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        break;
                    }

                }
                Console.WriteLine(palavraDigitada);
                Console.ReadLine();
            }
        }
    }
}