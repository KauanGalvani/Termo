namespace Termo.ConsoleApp
{
    static class TratamentoDeErro
    {
        public static bool ValidarPalavra(string? palavraDigitada)
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
    }
}