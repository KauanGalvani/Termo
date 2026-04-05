namespace Termo.ConsoleApp
{
    static class JogoTermo
    {
        public static string[] tiposDePalavras =
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
        public static string palavra = Program.SortearPalavra(tiposDePalavras);
        public static bool ChecarPalavra(string? palavraDigitada, string palavra)
        {
            if (palavraDigitada != palavra) //caso nn tenha ganhado direto ele entra em outro criterio de verificação.
            {
                for (int i = 0; i < palavraDigitada?.Length; i++)
                {
                    char verificadorDeLetras = palavraDigitada[i];

                    if (verificadorDeLetras == palavra[i]) //letra existe e esta na pósição correta.
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
            }
            else if (palavraDigitada == palavra) // virifica se o usuario acertou em cheio e ganhou.
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
                return true;
            }
            return false;
        }
    

    }
}