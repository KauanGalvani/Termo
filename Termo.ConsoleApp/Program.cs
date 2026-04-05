using System.Drawing;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;

namespace Termo.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) //loop principal
            {
                Console.Clear();
                int tentativas = 5;

                bool jogoAcabou = false;
                string palavra = SortearPalavra(JogoTermo.tiposDePalavras);

                Cabecalho();

                while (jogoAcabou == false)
                {
                    Console.WriteLine();
                    Console.Write(">");
                    string? palavraDigitada = Console.ReadLine();

                    if (TratamentoDeErro.ValidarPalavra(palavraDigitada)) continue;

                    Console.WriteLine($"\nVocê tem {tentativas} tentativas.");

                    jogoAcabou = JogoTermo.ChecarPalavra(palavraDigitada, palavra);

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
                    tentativas--;

                    if (!jogoAcabou)continue;
                    else break;
                }

                if (!DevContinuar()) break;
                else continue;
            }
        }

        public static string SortearPalavra(string[] tiposDePalavras)
        {
            int indice = RandomNumberGenerator.GetInt32(tiposDePalavras.Length);

            return tiposDePalavras[indice];//escolhe a palavra guardada no vetor e guarda em uma variavel para apresentala.
        }
        static void Cabecalho()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" ═════════════════════════════  ");
            Console.WriteLine("             TERMO              ");
            Console.WriteLine(" ═════════════════════════════  ");

            Console.ResetColor();
        }

        static bool DevContinuar()
        {
            Console.WriteLine("Deseja jogar novamente? (S/N)");
            string? devContinuar = Console.ReadLine()?.ToUpper();

            if (devContinuar != "S")
            {
                Console.WriteLine("Seu jogo será fechado, obrigado por jogar.");
                Console.WriteLine("Pressione ENTER para sair...");
                Console.ReadLine();
                return false;
            }
            else return true;

        }
    }
}