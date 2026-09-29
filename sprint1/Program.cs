using System;
using System.Security.Cryptography.X509Certificates;

namespace sprint1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool running = true;

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("███████╗██████╗░███████╗██████╗░░█████╗░░█████╗░███████╗");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("██╔════╝██╔══██╗██╔════╝██╔══██╗██╔══██╗██╔══██╗██╔════╝");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("█████╗░░██║░░██║█████╗░░██║░░██║██║░░██║██║░░╚═╝█████╗░░");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("██╔══╝░░██║░░██║██╔══╝░░██║░░██║██║░░██║██║░░██╗██╔══╝░░");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("███████╗██████╔╝███████╗██████╔╝╚█████╔╝╚█████╔╝███████╗");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("╚══════╝╚═════╝░╚══════╝╚═════╝░░╚════╝░░╚════╝░╚══════╝");


                Console.ResetColor();

                Console.WriteLine("═══════════════════════ ℰ́𝒹ℯ𝒟ℴ𝒸ℯ! ═══════════════════════");
                Console.WriteLine("\nAcesse nosso menu abaixo:");
                Console.WriteLine("\nDigite 1 para acessar o cardápio de lanches");
                Console.WriteLine("Digite 2 para acessar o cardápio de bebidas");
                Console.WriteLine("Digite 3 para acessar o carrinho");
                Console.WriteLine("Digite 0 para sair");

                Console.Write("\nDigite a opção desejada: ");
                string opcao = Console.ReadLine()!;

                switch (opcao)
                {
                    case "1":
                        Lanche menuLanche = new Lanche();
                        menuLanche.MostrarCardapioLanches();
                        break;
                    case "2":
                        Bebida menuBebidaSolo = new Bebida();
                        menuBebidaSolo.MostrarCardapioBebidas();
                        break;
                    case "3":
                        Carrinho.MostrarCarrinho();
                        break;
                    case "0":
                        Console.WriteLine("Obrigado por visitar a doceria  ℰ́𝒹ℯ𝒟ℴ𝒸ℯ! Até logo!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Digite um dos valores do menu por favor.");
                        Sair();
                        break;
                }

                Console.Clear();
            }
        }

        public static void Sair()
        {
            Console.Write("\nPressione ENTER para retornar ao menu principal...");
            Console.ReadLine();
            Thread.Sleep(700);
            Console.Clear();
        }

       

    }
}




