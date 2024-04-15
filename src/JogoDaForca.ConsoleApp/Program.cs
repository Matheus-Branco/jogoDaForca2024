using System;
using System.Collections.Generic;
using System.Linq;

namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-Vindo ao jogo da forca!!");
            
            JogoDaForca jogo = new JogoDaForca();
            jogo.IniciarJogo();
        }
    }

    public class JogoDaForca
    {
        private string[] PalavrasSecretas = {
            "ABACATE", "ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA",
            "BACABA", "BACURI", "BANANA", "CAJÁ", "CAJÚ",
            "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA", "JABUTICABA",
            "JENIPAPO", "MAÇÃ", "MANGABA", "MANGA", "MARACUJÁ",
            "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI",
            "BERGAMOTA", "UMBU", "UVA", "UVAIA"
        };
        private string PalavraEscolhida;
        private char[] PalavraAtual;
        private int TentativasRestantes;
        private List<char> LetrasTentadas;

        public JogoDaForca()
        {
            Random random = new Random();
            PalavraEscolhida = PalavrasSecretas[random.Next(PalavrasSecretas.Length)].ToUpper();
            PalavraAtual = new char[PalavraEscolhida.Length];
            for (int i = 0; i < PalavraEscolhida.Length; i++)
            {
                PalavraAtual[i] = '_';
            }
            TentativasRestantes = 5;
            LetrasTentadas = new List<char>();
        }

        public void IniciarJogo()
        {
            Console.WriteLine("Bem-vindo ao Jogo da Forca!");

            while (TentativasRestantes > 0 && PalavraAtual.Contains('_'))
            {
                Console.WriteLine($"\nTentativas restantes: {TentativasRestantes}");
                Console.WriteLine("Letras tentadas: " + string.Join(", ", LetrasTentadas));

                Console.Write("\nDigite uma letra: ");
                char letra = Console.ReadLine().ToUpper()[0];

                if (LetrasTentadas.Contains(letra))
                {
                    Console.WriteLine("Você já tentou essa letra. Tente outra.");
                    continue;
                }

                LetrasTentadas.Add(letra);

                bool acertou = AtualizarPalavraAtual(letra);

                if (!acertou)
                {
                    TentativasRestantes--;
                }

                ExibirPalavraAtual();
            }

            if (!PalavraAtual.Contains('_'))
            {
                Console.WriteLine("\nParabéns! Você acertou a palavra.");
            }
            else
            {
                Console.WriteLine("\nVocê perdeu! A palavra era: " + PalavraEscolhida);
            }
        }

        private bool AtualizarPalavraAtual(char letra)
        {
            bool acertou = false;
            for (int i = 0; i < PalavraEscolhida.Length; i++)
            {
                if (PalavraEscolhida[i] == letra)
                {
                    PalavraAtual[i] = letra;
                    acertou = true;
                }
            }
            return acertou;
        }

        private void ExibirPalavraAtual()
        {
            foreach (char c in PalavraAtual)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }
    }
}
