using System.Drawing;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;

namespace Termo.ConsoleApp
{
    class Program
    {

        static string SortearPalavra(string[] tiposDePalavras)
        {
            int indice = RandomNumberGenerator.GetInt32(tiposDePalavras.Length);

            return tiposDePalavras[indice];//escolhe a palavra guardada no vetor e guarda em uma variavel para apresentala.
        }
        static void Cabecalho()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║            TERMO             ║");
            Console.WriteLine("╠══════════════════════════════╣");
            Console.WriteLine("║  Desenvolvido por Galvani    ║");
            Console.WriteLine("╚══════════════════════════════╝");
            Console.ResetColor();
        }

        static bool ValidarPalavra(string? palavraDigitada)
        {
            if (palavraDigitada?.Length != 5 ||
               string.IsNullOrWhiteSpace(palavraDigitada) ||
               !palavraDigitada.All(char.IsLetter)) //nesta linha esta tratando sobre o erro ao inserir numero e caractere
            {
                Console.WriteLine("Sua palavra deve ter no maximo 5 caracteres, sem espaços, numeros ou caracteres especiais.");
                Console.WriteLine("\nDigite ENTER para digitar novamente...");
                Console.ReadLine();
                return true;
            }
            return false;
        }
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
                "mosca",
                "livro"
            ];

            while (true) //loop principal
            {
                Console.Clear();
                int tentativas = 5;

                string palavra = SortearPalavra(tiposDePalavras);

                Cabecalho();

                while (true)
                {
                    Console.WriteLine($"\nVocê tem {tentativas} tentativas.");

                    Console.WriteLine();

                    Console.Write(">");
                    string? palavraDigitada = Console.ReadLine();
                   
                    if (ValidarPalavra(palavraDigitada))continue;
                    

                    if (palavraDigitada != palavra) //caso nn tenha ganhado direto ele entra em outro criterio de verificação
                    {
                        for (int i = 0; i < palavraDigitada?.Length; i++)
                        {
                            char verificadorDeLetras = palavraDigitada[i];

                            if (verificadorDeLetras == palavra[i]) //letra existe e esta na pósição correta
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write(verificadorDeLetras);
                                Console.ResetColor();

                            }
                            else if (palavra.Contains(verificadorDeLetras)) //contains verifica se existe na palavra mas ele nn diz a posição e nem quantas vezes ele s erepete.
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

                        tentativas--;
                    }
                    else if (palavraDigitada == palavra && tentativas > 0) // virifica se o usuario acertou em cheio e ganhou
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine(palavraDigitada);
                        Console.BackgroundColor = ConsoleColor.Black;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nVocê ganhou, parabéns!");
                        Console.ResetColor();
                        Console.WriteLine("Pressione ENTER para sair...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }

                    if (tentativas == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nSuas tentativas acabaram, você perdeu o jogo");
                        Console.ResetColor();

                        Console.WriteLine("Pressione ENTER para sair...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                }


                Console.WriteLine("Deseja jogar novamente? (S/N)");
                string? devContinuar = Console.ReadLine()?.ToUpper();

                if (devContinuar != "S")
                {
                    Console.WriteLine("Seu jogo será fechado, obrigado por jogar.");
                    Console.WriteLine("Pressione ENTER para sair...");
                    Console.ReadLine();
                    break;
                }
                else continue;

            }
        }
    }
}