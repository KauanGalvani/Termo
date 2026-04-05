namespace Termo.ConsoleApp
{
    static class Tentativas
    {
        public static int tentativas;
        public static bool ContadorDeTentativas()
        {
            if (tentativas == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nSuas tentativas acabaram, você perdeu o jogo");
                Console.ResetColor();

                Console.WriteLine("Pressione ENTER para sair...");
                Console.ReadLine();
                Console.Clear();
                return true;
            }
            tentativas--;
            return false;
        }
    }
}