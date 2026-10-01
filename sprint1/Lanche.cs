using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace sprint1
{
    public class Lanche : ItemCardapio
    {
        public Lanche(int codigo, string descricao, double precoBase)
            : base(codigo, descricao, precoBase) { }

        public Lanche() : base() { }

        // Recebe lista de bebidas selecionadas (null quando chamado do menu principal)
        public Lanche? MostrarCardapioLanches(List<Bebida>? bebidasSelecionadas = null)
        {
            // 1. Lista com todos os lanches do seu código
            List<Lanche> cardapio = new List<Lanche>
            {
                new Lanche(1, "Torta de Floresta Negra", 18.00),
                new Lanche(2, "Torta de Limão", 15.00),
                new Lanche(3, "Torta de Brigadeiro com mousse", 16.50),
                new Lanche(4, "Torta de Maracujá", 16.50),
                new Lanche(5, "Torta de Pudim", 16.50),
                new Lanche(6, "Torta de Frango com Catupiry", 17.00),
                new Lanche(7, "Torta de Frango com Quatro queijos", 16.50),
                new Lanche(8, "Torta de Carne com Banana da Terra", 16.50),
                new Lanche(9, "Torta de Queijo e Presunto", 16.50),
                new Lanche(10, "Torta de Bacalhau", 16.50)
            };

            List<Lanche> selecionados = new List<Lanche>();

            while (true)
            {
                Thread.Sleep(500);
                Console.Clear();

            Console.WriteLine("════════════ 𝒞𝒶𝓇𝒹𝒶́𝓅𝒾ℴ 𝒹ℯ 𝒯ℴ𝓇𝓉𝒶𝓈  ════════════");

                // Exibição automática dos doces (códigos 1 a 5)
                Console.WriteLine("\nTortas Doces:");
                foreach (var item in cardapio.Where(l => l.getCodigo() <= 5))
                {
                    Console.WriteLine($"{item.getCodigo()}. {item.getDescricao()} - R$ {item.getPrecoBase():F2}");
                }

                // Exibição automática das salgadas (códigos 6 a 10)
                Console.WriteLine("\nTortas Salgadas:");
                foreach (var item in cardapio.Where(l => l.getCodigo() > 5))
                {
                    Console.WriteLine($"{item.getCodigo()}. {item.getDescricao()} - R$ {item.getPrecoBase():F2}");
                }

                Console.WriteLine("\nPara retornar ao menu principal digite 'cancelar'");
                Console.Write("\nEscolha uma opção: ");
                string? input = Console.ReadLine();

                if (input == "cancelar")
                {
                    Thread.Sleep(600);
                    Program.Sair();
                    return null;
                }

                if (!int.TryParse(input, out int escolha))
                {
                    Console.WriteLine("Entrada inválida. Digite o código da torta.");
                    Thread.Sleep(1000);
                    continue;
                }

                Lanche? lancheSelecionado = cardapio.FirstOrDefault(l => l.getCodigo() == escolha);
                if (lancheSelecionado == null)
                {
                    Console.WriteLine("Torta não encontrada. Tente novamente.");
                    Thread.Sleep(1000);
                    continue;
                }

                selecionados.Add(lancheSelecionado);
                // adiciona ao carrinho global
                Carrinho.AddItem(lancheSelecionado.getDescricao(), lancheSelecionado.getPrecoBase());

                // Pergunta se deseja adicionar mais tortas
                while (true)
                {
                    Console.Write("\nGostaria de adicionar mais uma torta? (sim/não): ");
                    string? resposta = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(resposta))
                    {
                        Console.WriteLine("Resposta inválida. Digite 'sim' ou 'não'.");
                        continue;
                    }

                    resposta = resposta.Trim().ToLower();
                    if (resposta == "sim" || resposta == "s")
                    {
                        // Volta ao loop externo para escolher outra torta
                        break;
                    }
                    else if (resposta == "não" || resposta == "n")
                    {
                        // Se este método foi chamado a partir do menu de bebidas (bebidasSelecionadas != null),
                        // não perguntar sobre bebidas aqui; apenas finalizar.
                        if (bebidasSelecionadas != null && bebidasSelecionadas.Any())
                        {
                            Console.WriteLine($"\nItens adicionados ao carrinho:");
                            foreach (var t in selecionados)
                                Console.WriteLine($"- {t.getDescricao()} - R$ {t.getPrecoBase():F2}");

                            Program.Sair();
                            return selecionados.FirstOrDefault();
                        }

                        // Pergunta sobre bebida apenas quando não veio do menu de bebidas
                        while (true)
                        {
                            Console.Write("\nGostaria de escolher uma bebida? (sim/não): ");
                            string? respBebida = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(respBebida))
                            {
                                Console.WriteLine("Resposta inválida. Digite 'sim' ou 'não'.");
                                continue;
                            }

                            respBebida = respBebida.Trim().ToLower();
                            if (respBebida == "sim" || respBebida == "s")
                            {
                                Bebida menuBebida = new Bebida();
                                // chama o cardápio de bebidas junto da lista de tortas selecionadas
                                menuBebida.MostrarCardapioBebidas(selecionados);
                                
                                return selecionados.FirstOrDefault();
                            }
                            else if (respBebida == "não" || respBebida == "n")
                            {
                                // Caso o usuário não queira adicionar mais tortas nem bebidas, exibe os itens selecionados e retorna
                                Console.WriteLine($"\nItens adicionados ao carrinho:");
                                foreach (var t in selecionados)
                                    Console.WriteLine($"- {t.getDescricao()} - R$ {t.getPrecoBase():F2}");

                                Program.Sair();
                                return selecionados.FirstOrDefault();
                            }
                            else
                            {
                                Console.WriteLine("Resposta inválida. Digite 'sim' ou 'não'.");
                                continue;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Resposta inválida. Digite 'sim' ou 'não'.");
                        continue;
                    }
                }

                // Se o usuário escolheu adicionar mais tortas, o loop externo continua e exibe o cardápio novamente
            }
        }
    }
}