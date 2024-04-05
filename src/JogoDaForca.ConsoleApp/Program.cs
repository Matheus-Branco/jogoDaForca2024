namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-Vindo ao jogo da forca!!");

            string[] PalavraSecreta = 
            {
            "ABACATE", "ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA",
            "BACABA", "BACURI", "BANANA", "CAJÁ", "CAJÚ",
            "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA", "JABUTICABA",
            "JENIPAPO", "MAÇÃ", "MANGABA", "MANGA", "MARACUJÁ",
            "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI",
            "BERGAMOTA", "UMBU", "UVA", "UVAIA"
            };

            Random random = new Random();
            string palavraEscolhida = PalavraSecreta[random.Next(PalavraSecreta.Length)].ToUpper();
            char[] palavraAtual = new char[palavraEscolhida.Length];

            for (int i = 0; i < palavraEscolhida.Length; i++)
            {
                palavraAtual[i] = '_';
            }

            int tentativasRestantes = 5;
            List<char> letrasTentadas = new List<char>();

            Console.WriteLine("Bem-vindo ao Jogo da Forca!");

            while (tentativasRestantes > 0 && palavraAtual.Contains('_'))
            {
                Console.WriteLine($"\nTentativas restantes: {tentativasRestantes}");
                Console.WriteLine("Letras tentadas: " + string.Join(", ", letrasTentadas));

                Console.Write("\nDigite uma letra: ");
                char letra = Console.ReadLine().ToUpper()[0];

                if (letrasTentadas.Contains(letra))
                {
                    Console.WriteLine("Você já tentou essa letra. Tente outra.");
                    continue;
                }

                letrasTentadas.Add(letra);

                bool acertou = false;
                for (int i = 0; i < palavraEscolhida.Length; i++)
                {
                    if (palavraEscolhida[i] == letra)
                    {
                        palavraAtual[i] = letra;
                        acertou = true;
                    }
                }

                if (!acertou)
                {
                    tentativasRestantes--;
                }

                ExibirPalavraAtual(palavraAtual);
            }

            if (!palavraAtual.Contains('_'))
            {
                Console.WriteLine("\nParabéns! Você acertou a palavra.");
            }
            else
            {
                Console.WriteLine("\nVocê perdeu! A palavra era: " + palavraEscolhida);
            }
        }

        static void ExibirPalavraAtual(char[] palavraAtual)
        {
            foreach (char c in palavraAtual)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }
    }
}
