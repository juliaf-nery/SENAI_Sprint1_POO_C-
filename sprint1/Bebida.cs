using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace sprint1
{
    public class Bebida : ItemCardapio
    {
        // Construtor herdado da classe pai
        public Bebida(int codigo, string descricao, double precoBase)
            : base(codigo, descricao, precoBase)
        {
        }

        // Construtor padrão
        public Bebida() : base() { }

        public void MostrarCardapioBebidas(List<Lanche>? tortasSelecionadas = null)
        {
            List<Bebida> cardapioBebidas = new List<Bebida>
            {
                new Bebida(1, "Soda italiana de Limão", 8.50),
                new Bebida(2, "Suco de Laranja", 7.00),
                new Bebida(3, "Suco de Pêssego", 7.00),
                new Bebida(4, "Suco de Morango", 7.50),
                new Bebida(5, "Milkshake de Nutella", 15.00),
                new Bebida(6, "Milkshake de Baunilha", 13.50),
                new Bebida(7, "Milkshake de Doce de Leite", 14.00),
                new Bebida(8, "Água mineral", 5.00)
            };

            List<(Bebida bebida, string tamanho)> selecionadas = new List<(Bebida, string)>();

            while (true)
            {
                Thread.Sleep(300);
                Console.Clear();
                Console.WriteLine("════════════ 𝒞𝒶𝓇𝒹𝒶́𝓅𝒾ℴ 𝒹ℯ ℬ℮𝒷𝒾𝒷𝒶s ════════════\n");

                foreach (var bebidas in cardapioBebidas)
                {
                    Console.WriteLine($"{bebidas.getCodigo()}. {bebidas.getDescricao()} - R$ {bebidas.getPrecoBase():F2}");
                }

                Console.Write("\nEscolha uma opção: ");
                string? input = Console.ReadLine();

                if (!int.TryParse(input, out int escolha))
                {
                    Console.WriteLine("Entrada inválida. Digite o código da bebida.");
                    Thread.Sleep(1000);
                    continue;
                }

                Bebida? bebidaSelecionada = cardapioBebidas.FirstOrDefault(b => b.getCodigo() == escolha);
                if (bebidaSelecionada == null)
                {
                    Console.WriteLine("Bebida não encontrada. Tente novamente.");
                    Thread.Sleep(1000);
                    continue;
                }

                string tamanhoEscolhido = "Padrão";
                if (bebidaSelecionada.getCodigo() != 8)
                {
                    tamanhoEscolhido = TamanhoBebida(bebidaSelecionada);
                }

                selecionadas.Add((bebidaSelecionada, tamanhoEscolhido));
                Carrinho.AddItem(bebidaSelecionada.getDescricao(), bebidaSelecionada.getPrecoBase(), tamanhoEscolhido);

                while (true)
                {
                    Console.Write("\nGostaria de adicionar mais uma bebida? (sim/não): ");
                    string? resp = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(resp))
                    {
                        Console.WriteLine("Resposta inválida. Digite 'sim' ou 'não'.");
                        continue;
                    }

                    resp = resp.Trim().ToLower();
                    if (resp == "sim" || resp == "s")
                    {
                        // volta ao loop externo para escolher outra bebida
                        break;
                    }
                    else if (resp == "não" || resp == "n")
                    {
                        if (tortasSelecionadas != null && tortasSelecionadas.Any())
                        {
                            MostrarResumo(tortasSelecionadas, selecionadas);
                            Program.Sair();
                            return;
                        }

                        // Pergunta se quer escolher uma torta apenas quando não veio do menu de lanches
                        while (true)
                        {
                            Console.Write("\nGostaria de escolher uma torta? (sim/não): ");
                            string? respTorta = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(respTorta))
                            {
                                Console.WriteLine("Resposta inválida. Digite 'sim' ou 'não'.");
                                continue;
                            }

                            respTorta = respTorta.Trim().ToLower();
                            if (respTorta == "sim" || respTorta == "s")
                            {
                                // Chama o cardápio de tortas, passando lista de bebidas selecionadas para que Lanche.cs não pergunte se quer escolher alguma bebida
                                Lanche menuLanche = new Lanche();
                                var bebidasSimples = selecionadas.Select(s => s.bebida).ToList();
                                menuLanche.MostrarCardapioLanches(bebidasSimples);
                                Program.Sair();

                                // Após retornar do cardápio de tortas, mostra o resumo atual do pedido
                                MostrarResumo(null, selecionadas);
                                Program.Sair();
                                return;
                            }
                            else if (respTorta == "não" || respTorta == "nao" || respTorta == "n")
                            {
                                // Finaliza e mostra resumo do pedido
                                MostrarResumo(null, selecionadas);
                                Program.Sair();
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Resposta inválida. Digite 'sim' ou 'não'.");
                                continue;
                            }
                        }

                        // sai do loop de 'mais bebida' para reiniciar o fluxo se necessário
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Resposta inválida. Digite 'sim' ou 'não'.");
                        continue;
                    }
                }

                // se aqui significa que usuário escolheu 'sim' para adicionar mais — o loop externo recomeça
            }
        }

        // Exibe resumo das escolhas do pedido, incluindo tortas e bebidas selecionadas
        private void MostrarResumo(List<Lanche>? tortas, List<(Bebida bebida, string tamanho)> bebidas)
        {
            Console.WriteLine("\nItens adicionados ao carrinho:");
            if (tortas != null && tortas.Any())
            {
                foreach (var t in tortas)
                {
                    Console.WriteLine($"- {t.getDescricao()} - R$ {t.getPrecoBase():F2}");
                }
            }

            if (bebidas != null && bebidas.Any())
            {
                foreach (var b in bebidas)
                {
                    Console.WriteLine($"- {b.bebida.getDescricao()} ({b.tamanho}) - R$ {b.bebida.getPrecoBase():F2}");
                }
            }
        }

        // Seleciona o tamanho e ajusta o preço da bebida; retorna string representando o tamanho
        public string TamanhoBebida(Bebida bebida)
        {
            Thread.Sleep(500);
            Console.WriteLine("\nEscolha o tamanho da bebida:\n");
            Console.WriteLine("P (300ml) - Padrão");
            Console.WriteLine("M (500ml) - + R$4,00");
            Console.WriteLine("G (700ml) - + R$6,00");

            Console.Write("\nEscolha uma opção (P/M/G): ");
            string? opcaoTamanho = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(opcaoTamanho))
            {
                Console.WriteLine("Tamanho padrão selecionado.");
                return "Padrão";
            }

            switch (opcaoTamanho.Trim().ToUpper())
            {
                case "P":
                    bebida.SetPrecoBase(bebida.getPrecoBase());
                    return "P (300ml)";
                case "M":
                    bebida.SetPrecoBase(bebida.getPrecoBase() + 4.00);
                    return "M (500ml)";
                case "G":
                    bebida.SetPrecoBase(bebida.getPrecoBase() + 6.00);
                    return "G (700ml)";
                default:
                    Console.WriteLine("Opção inválida. O tamanho padrão será selecionado.");
                    bebida.SetPrecoBase(bebida.getPrecoBase());
                    return "Padrão";
            }
        }

    }
}
