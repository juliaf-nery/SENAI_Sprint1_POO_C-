using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace sprint1
{
    internal class Carrinho
    {
        private static readonly List<CartItem> itens = new List<CartItem>();

        internal class CartItem
        {
            public string Nome { get; init; }
            public double Valor { get; set; }
            public string? Tamanho { get; init; }

            public CartItem(string nome, double valor, string? tamanho = null)
            {
                Nome = nome;
                Valor = valor;
                Tamanho = tamanho;
            }
        }

        public static void AddItem(string nome, double valor, string? tamanho = null)
        {
            itens.Add(new CartItem(nome, valor, tamanho));
            Console.WriteLine($"Você escolheu {nome} {tamanho}");
        }

        public static void MostrarCarrinho()
        {
            Console.Clear();
            Console.WriteLine("════════════ 𝒞𝒶𝓇𝓇𝒾𝓃𝒽ℴ 𝒹ℯ 𝒸ℴ𝓂𝓅𝓇𝒶𝓈 ════════════\n");

            if (!itens.Any())
            {
                Console.WriteLine("Seu carrinho está vazio.");
                Console.WriteLine();
                Program.Sair();
                return;
            }

            for (int i = 0; i < itens.Count; i++)
            {
                var it = itens[i];
                string tamanho = string.IsNullOrEmpty(it.Tamanho) ? string.Empty : $" ({it.Tamanho})";
                Console.WriteLine($"{i + 1}. {it.Nome}{tamanho} - R$ {it.Valor:F2}");
            }

            double total = GetTotal();
            Console.WriteLine($"\nTotal: R$ {total:F2}");

            // Pergunta se deseja finalizar a compra
            while (true)
            {
                Console.Write("\nDeseja finalizar a compra? (sim/não): ");
                string? resp = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(resp)) { Console.WriteLine("Resposta inválida."); continue; }
                resp = resp.Trim().ToLower();
                if (resp == "sim" || resp == "s")
                {
                    Checkout(total);
                    break;
                }
                else if (resp == "não" || resp == "nao" || resp == "n")
                {
                    Console.WriteLine("Retornando ao menu principal...");
                    Program.Sair();
                    break;
                }
                else
                {
                    Console.WriteLine("Resposta inválida. Digite 'sim' ou 'não'.");
                }
            }
        }

        private static double GetTotal()
        {
            return itens.Sum(i => i.Valor);
        }

        private static void Checkout(double total)
        {
            while (true)
            {
                Console.WriteLine("\nEscolha a forma de pagamento: ");
                Console.WriteLine("1. Pix");
                Console.WriteLine("2. Cartão");
                Console.Write("Opção: ");
                string? metodo = Console.ReadLine();

                

                if (string.IsNullOrWhiteSpace(metodo))
                {
                    Console.WriteLine("Opção de pagamento invalida. Por favor escolha uma das opções acima.");
                    Thread.Sleep(1000);
                    continue;
                }

                metodo = metodo.Trim();

                if (metodo == "1" || string.Equals(metodo, "pix", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Pagamento por Pix selecionado.");

                    while (true)
                    {
                        Console.Write("\nInforme a chave Pix (minímo 11 digitos): ");
                        string? rawChave = Console.ReadLine();
                        string chave = rawChave?.Trim() ?? string.Empty;

                        if (chave.Length >= 11)
                        {
                            Console.Write("Processando pagamento");

                            for (int ciclo = 0; ciclo < 2; ciclo++)
                            {

                            for (int i = 0; i < 3; i++)
                            
                            {
                                Thread.Sleep(500);
                                Console.Write(".");
                                
                            }

                            if (ciclo == 0)
                                {
                                    Thread.Sleep(500);
                                    Console.Write("\b \b\b \b\b \b");
                                }
                            }

                            Thread.Sleep(500);
                            Console.WriteLine();
                            Console.WriteLine($"\nPagamento via Pix confirmado. Valor: R$ {total:F2}");
                            Thread.Sleep(700);
                            Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣀⣀⠀⠀⠀⢀⡤⠤⠤⣄⠀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⠤⢴⣴⠒⠉⠹⣴⣏⠀⠀⠀⡀⠈⢇⠀⠀⣼⠀⠀⠀⠘⣶⠇⠀⢨⢃⡾⠓⠲⢤⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⣀⠤⠔⠒⠙⣯⣇⠀⠈⣿⣇⠀⠀⣿⣿⣿⠀⠀⣷⠀⠘⡄⠀⣿⠀⠀⠀⠀⢹⠀⠀⢸⡏⠇⠀⢀⠇⣀⠤⠒⠒⠤⣄\r\n⢰⡖⠉⠀⠀⠀⠀⣀⣸⣿⠀⠀⠉⠉⠀⠀⢸⠁⣿⠀⠈⠉⠁⠀⢱⠀⣿⠀⠀⣦⠀⠀⠀⠀⣿⡸⠀⠀⠘⠉⠀⠀⣀⣤⣴⠟\r\n⢼⢣⣀⣴⡀⠀⠘⡿⠏⠗⡆⠀⠠⣶⡆⠀⠸⡄⡏⠀⠀⣶⣷⠀⠀⢧⣿⠀⠀⣿⡆⠀⠀⢸⣿⠃⠀⢰⡄⠀⠐⡿⠛⠋⠀⠀\r\n⠘⢿⡿⢿⣧⠀⠀⢳⠀⢸⠸⠀⠀⢹⣧⢀⣀⣷⣧⣤⣤⠛⣏⣦⣤⣾⣿⢦⣤⣿⢸⣄⣀⣼⡏⠀⢠⡟⡇⠀⠀⡇⠀⠀⠀⠀\r\n⠀⠀⠀⠀⢏⢇⠀⠀⣣⠀⣆⣷⣶⣿⣿⡿⠿⠿⢷⡿⠟⣠⠟⠋⠛⢿⡛⠛⠿⡼⠿⠿⢿⣿⣿⣶⠞⡅⢸⠀⠀⢸⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠘⣾⣿⣿⠇⢠⣟⠉⠙⠷⡿⠀⠀⠀⢸⢀⡼⠁⠀⣀⠀⠀⠹⡄⡼⡇⠀⠀⡜⣸⡏⠙⠢⣧⣾⣦⣀⢸⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠈⠀⠀⠀⢿⣿⣷⣦⡀⠀⠀⠀⠀⣇⡾⠀⠀⣼⣿⢷⠀⠀⢻⢱⠀⠀⢀⣿⡿⠀⠀⢠⠋⢻⡿⠿⣏⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠳⣿⣿⠆⠀⠀⢸⡏⡇⠀⠀⡏⡟⡟⠀⠀⢸⡸⠀⠀⢸⣿⠃⠀⠀⡜⡰⢩⠃⠀⠈⣱⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⢹⠀⠀⠀⢸⠀⡇⠀⠀⠙⠋⠀⠀⢀⡏⡇⠀⠀⠘⠋⠀⠀⣰⣱⢣⠇⠀⠀⣰⠃⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡘⡎⠀⠀⠀⡏⣿⣧⡀⠀⠀⠀⠀⢀⣾⣷⡇⠀⠀⠀⠀⠀⢠⣯⣧⣾⣦⣄⣰⠃⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣧⣧⣤⣶⣶⠃⠘⢿⣿⣷⣶⣶⣾⠟⠉⣿⣿⣦⣄⣀⣠⣴⢏⣽⠋⠉⠙⢿⠁⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠛⠛⠛⠋⠁⠀⠀⠀⠉⠉⠉⠉⠀⠀⠀⠈⠛⠻⠿⠟⠋⠁⣿⣿⣦⣀⣀⡼⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠛⠛⠛⠁⠀⠀⠀⠀⠀⠀⠀");
                            itens.Clear();
                            Program.Sair();
                            return;
                        }

                        Console.WriteLine("Chave Pix inválida. Por favor, digite pelo menos 11 caracteres ou 'cancelar'.");
                    }
                    // se sair do loop de chave com 'cancelar', volta a escolher forma de pagamento
                    continue;

                }
                else if (metodo == "2" || string.Equals(metodo, "cartao", StringComparison.OrdinalIgnoreCase) || string.Equals(metodo, "cartão", StringComparison.OrdinalIgnoreCase))
                {
                    while (true)
                    {
                        Console.Write("\nCartão - débito ou crédito? (débito/crédito): ");
                        string? tipo = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(tipo)) { Console.WriteLine("Resposta inválida."); continue; }
                        tipo = tipo.Trim().ToLower();
                        if (tipo == "débito" || tipo == "d")
                        {

                            Console.Write("Processando pagamento");

                            for (int ciclo = 0; ciclo < 2; ciclo++)
                            {

                                for (int i = 0; i < 3; i++)

                                {
                                    Thread.Sleep(500);
                                    Console.Write(".");

                                }

                                if (ciclo == 0)
                                {
                                    Thread.Sleep(500);
                                    Console.Write("\b \b\b \b\b \b");
                                }
                            }

                            Thread.Sleep(500);
                            Console.WriteLine();
                            Console.WriteLine($"\nPagamento no débito confirmado. Valor: R$ {total:F2}");
                            Thread.Sleep(700);
                            Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣀⣀⠀⠀⠀⢀⡤⠤⠤⣄⠀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⠤⢴⣴⠒⠉⠹⣴⣏⠀⠀⠀⡀⠈⢇⠀⠀⣼⠀⠀⠀⠘⣶⠇⠀⢨⢃⡾⠓⠲⢤⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⣀⠤⠔⠒⠙⣯⣇⠀⠈⣿⣇⠀⠀⣿⣿⣿⠀⠀⣷⠀⠘⡄⠀⣿⠀⠀⠀⠀⢹⠀⠀⢸⡏⠇⠀⢀⠇⣀⠤⠒⠒⠤⣄\r\n⢰⡖⠉⠀⠀⠀⠀⣀⣸⣿⠀⠀⠉⠉⠀⠀⢸⠁⣿⠀⠈⠉⠁⠀⢱⠀⣿⠀⠀⣦⠀⠀⠀⠀⣿⡸⠀⠀⠘⠉⠀⠀⣀⣤⣴⠟\r\n⢼⢣⣀⣴⡀⠀⠘⡿⠏⠗⡆⠀⠠⣶⡆⠀⠸⡄⡏⠀⠀⣶⣷⠀⠀⢧⣿⠀⠀⣿⡆⠀⠀⢸⣿⠃⠀⢰⡄⠀⠐⡿⠛⠋⠀⠀\r\n⠘⢿⡿⢿⣧⠀⠀⢳⠀⢸⠸⠀⠀⢹⣧⢀⣀⣷⣧⣤⣤⠛⣏⣦⣤⣾⣿⢦⣤⣿⢸⣄⣀⣼⡏⠀⢠⡟⡇⠀⠀⡇⠀⠀⠀⠀\r\n⠀⠀⠀⠀⢏⢇⠀⠀⣣⠀⣆⣷⣶⣿⣿⡿⠿⠿⢷⡿⠟⣠⠟⠋⠛⢿⡛⠛⠿⡼⠿⠿⢿⣿⣿⣶⠞⡅⢸⠀⠀⢸⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠘⣾⣿⣿⠇⢠⣟⠉⠙⠷⡿⠀⠀⠀⢸⢀⡼⠁⠀⣀⠀⠀⠹⡄⡼⡇⠀⠀⡜⣸⡏⠙⠢⣧⣾⣦⣀⢸⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠈⠀⠀⠀⢿⣿⣷⣦⡀⠀⠀⠀⠀⣇⡾⠀⠀⣼⣿⢷⠀⠀⢻⢱⠀⠀⢀⣿⡿⠀⠀⢠⠋⢻⡿⠿⣏⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠳⣿⣿⠆⠀⠀⢸⡏⡇⠀⠀⡏⡟⡟⠀⠀⢸⡸⠀⠀⢸⣿⠃⠀⠀⡜⡰⢩⠃⠀⠈⣱⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⢹⠀⠀⠀⢸⠀⡇⠀⠀⠙⠋⠀⠀⢀⡏⡇⠀⠀⠘⠋⠀⠀⣰⣱⢣⠇⠀⠀⣰⠃⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡘⡎⠀⠀⠀⡏⣿⣧⡀⠀⠀⠀⠀⢀⣾⣷⡇⠀⠀⠀⠀⠀⢠⣯⣧⣾⣦⣄⣰⠃⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣧⣧⣤⣶⣶⠃⠘⢿⣿⣷⣶⣶⣾⠟⠉⣿⣿⣦⣄⣀⣠⣴⢏⣽⠋⠉⠙⢿⠁⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠛⠛⠛⠋⠁⠀⠀⠀⠉⠉⠉⠉⠀⠀⠀⠈⠛⠻⠿⠟⠋⠁⣿⣿⣦⣀⣀⡼⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠛⠛⠛⠁⠀⠀⠀⠀⠀⠀⠀");
                            itens.Clear();
                            Program.Sair();
                            return;
                        }
                        else if (tipo == "crédito" || tipo == "c")
                        {

                            Console.Write("Processando pagamento");

                            for (int ciclo = 0; ciclo < 2; ciclo++)
                            {

                                for (int i = 0; i < 3; i++)

                                {
                                    Thread.Sleep(500);
                                    Console.Write(".");

                                }

                                if (ciclo == 0)
                                {
                                    Thread.Sleep(500);
                                    Console.Write("\b \b\b \b\b \b");
                                }
                            }

                            Thread.Sleep(500);
                            Console.WriteLine();
                            Console.WriteLine($"\nPagamento no crédito confirmado. Valor: R$ {total:F2}");
                            Thread.Sleep(700);
                            Console.WriteLine("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣀⣀⠀⠀⠀⢀⡤⠤⠤⣄⠀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⠤⢴⣴⠒⠉⠹⣴⣏⠀⠀⠀⡀⠈⢇⠀⠀⣼⠀⠀⠀⠘⣶⠇⠀⢨⢃⡾⠓⠲⢤⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⣀⠤⠔⠒⠙⣯⣇⠀⠈⣿⣇⠀⠀⣿⣿⣿⠀⠀⣷⠀⠘⡄⠀⣿⠀⠀⠀⠀⢹⠀⠀⢸⡏⠇⠀⢀⠇⣀⠤⠒⠒⠤⣄\r\n⢰⡖⠉⠀⠀⠀⠀⣀⣸⣿⠀⠀⠉⠉⠀⠀⢸⠁⣿⠀⠈⠉⠁⠀⢱⠀⣿⠀⠀⣦⠀⠀⠀⠀⣿⡸⠀⠀⠘⠉⠀⠀⣀⣤⣴⠟\r\n⢼⢣⣀⣴⡀⠀⠘⡿⠏⠗⡆⠀⠠⣶⡆⠀⠸⡄⡏⠀⠀⣶⣷⠀⠀⢧⣿⠀⠀⣿⡆⠀⠀⢸⣿⠃⠀⢰⡄⠀⠐⡿⠛⠋⠀⠀\r\n⠘⢿⡿⢿⣧⠀⠀⢳⠀⢸⠸⠀⠀⢹⣧⢀⣀⣷⣧⣤⣤⠛⣏⣦⣤⣾⣿⢦⣤⣿⢸⣄⣀⣼⡏⠀⢠⡟⡇⠀⠀⡇⠀⠀⠀⠀\r\n⠀⠀⠀⠀⢏⢇⠀⠀⣣⠀⣆⣷⣶⣿⣿⡿⠿⠿⢷⡿⠟⣠⠟⠋⠛⢿⡛⠛⠿⡼⠿⠿⢿⣿⣿⣶⠞⡅⢸⠀⠀⢸⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠘⣾⣿⣿⠇⢠⣟⠉⠙⠷⡿⠀⠀⠀⢸⢀⡼⠁⠀⣀⠀⠀⠹⡄⡼⡇⠀⠀⡜⣸⡏⠙⠢⣧⣾⣦⣀⢸⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠈⠀⠀⠀⢿⣿⣷⣦⡀⠀⠀⠀⠀⣇⡾⠀⠀⣼⣿⢷⠀⠀⢻⢱⠀⠀⢀⣿⡿⠀⠀⢠⠋⢻⡿⠿⣏⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠳⣿⣿⠆⠀⠀⢸⡏⡇⠀⠀⡏⡟⡟⠀⠀⢸⡸⠀⠀⢸⣿⠃⠀⠀⡜⡰⢩⠃⠀⠈⣱⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⢹⠀⠀⠀⢸⠀⡇⠀⠀⠙⠋⠀⠀⢀⡏⡇⠀⠀⠘⠋⠀⠀⣰⣱⢣⠇⠀⠀⣰⠃⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡘⡎⠀⠀⠀⡏⣿⣧⡀⠀⠀⠀⠀⢀⣾⣷⡇⠀⠀⠀⠀⠀⢠⣯⣧⣾⣦⣄⣰⠃⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣧⣧⣤⣶⣶⠃⠘⢿⣿⣷⣶⣶⣾⠟⠉⣿⣿⣦⣄⣀⣠⣴⢏⣽⠋⠉⠙⢿⠁⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠛⠛⠛⠋⠁⠀⠀⠀⠉⠉⠉⠉⠀⠀⠀⠈⠛⠻⠿⠟⠋⠁⣿⣿⣦⣀⣀⡼⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠛⠛⠛⠁⠀⠀⠀⠀⠀⠀⠀");
                            itens.Clear();
                            Program.Sair();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Opção inválida. Digite 'débito' ou 'crédito'.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Opção de pagamento invalida. Por favor escolha uma das opções acima.");
                    // volta para reencontrar a forma de pagamento
                    continue;
                }
            }
        }
    }
}
