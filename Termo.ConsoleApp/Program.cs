using System.Security.Cryptography;

namespace Termo.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tiposDePalavras =
            [
                "pedra",
                "barco",
                "noite",
                "sonho",
                "campo",
                "verde",
                "clima",
                "vento",
                "fogoa",
                "livro"
            ];

            int EscolhaDaPalavra = RandomNumberGenerator.GetInt32(tiposDePalavras.Length);

            string PalavraAleatoria = tiposDePalavras[EscolhaDaPalavra];//escolhe a palavra guardada no vetor e guarda em uma variavel para apresentala.

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


                    if (palavraDigitada?.Length != 5 ||
                       string.IsNullOrWhiteSpace(palavraDigitada) ||
                      !palavraDigitada.All(char.IsLetter)) //nesta linha esta tratando sobre o erro ao inserir numero e caractere
                    {
                        Console.WriteLine("sua palavra deve ter no maximo 5 caracteres sem espaços, numeros ou caracteres especiais");
                        Console.WriteLine("\nDigite ENTER para digitar novamente...");
                        Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        break;
                    }



                }


                Console.ReadLine();
            }
        }
    }
}