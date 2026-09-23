using System;
using System.Security.Cryptography.X509Certificates;

namespace sprint1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("═══════════ ℬℯ𝓂-𝓋𝒾𝓃𝒹ℴ(𝒶) 𝒶 𝒹ℴ𝒸ℯ𝓇𝒾𝒶 ℰ́𝒹ℯ𝒟ℴ𝒸ℯ!  ════════════");
            Console.WriteLine("\nAcesse nosso menu abaixo:");
            Console.WriteLine("\nDigite 1 para acessar o cardápio de lanches");
            Console.WriteLine("Digite 2 para acessar o cardápio de bebidas");
            Console.WriteLine("Digite 3 para acessar o carrinho");
            Console.WriteLine("Digite 4 para sair");

            Console.Write("\nDigite a opção desejada: ");
            string opcao = Console.ReadLine()!;

            switch (opcao)
            {
                case "1":
                    Lanche menuLanche = new Lanche();
                    menuLanche.MostrarCardapioLanches();
                    break;
                case "2":
                    Bebida menuBebida = new Bebida();
                    menuBebida.MostrarCardapioBebidas();
                    break;
                case "3":
                    break;
                case "4":
                    Console.WriteLine("Obrigado por visitar a doceria ℰ́𝒹ℯ𝒟ℴ𝒸ℯ! Até logo!");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Digite um dos valores do menu por favor.");
                    break;
            }

        }
    }
}


