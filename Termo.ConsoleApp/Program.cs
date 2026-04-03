using System.Drawing;
using System.Reflection.PortableExecutable;
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


            Console.WriteLine("--------------------------");
            Console.WriteLine("Jogo Termo");
            Console.WriteLine("--------------------------");

            while (true) //loop principal
            {
                string? palavraDigitada;


                Console.WriteLine();

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

                if (palavraDigitada != PalavraAleatoria) //caso nn tenha ganhado direto ele entra em outro criterio de verificação
                {
                    for (int i = 0; i < palavraDigitada.Length; i++)
                    {
                        char verificadorDeLetras = palavraDigitada[i];

                        if (verificadorDeLetras == PalavraAleatoria[i]) //letra existe e esta na pósição correta
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write(verificadorDeLetras);
                            Console.ResetColor();
                        }
                        else if (PalavraAleatoria.Contains(verificadorDeLetras)) //contains verifica se existe na palavra mas ele nn diz a posição e nem quantas vezes ele s erepete.
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.Write(verificadorDeLetras);
                            Console.ResetColor();
                        }
                        else //letra nn existe
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write(verificadorDeLetras);
                            Console.ResetColor();
                        }
                    }
                }
                else if (palavraDigitada == PalavraAleatoria) // virifica se o usuario acertou em cheio e ganhou
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(palavraDigitada);
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                }
            }
        }
    }
}