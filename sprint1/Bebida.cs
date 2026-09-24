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

        // Retorna a bebida selecionada e o tamanho escolhido (null se inválido)
        public (Bebida? bebida, string? tamanho) MostrarCardapioBebidas(Lanche? lancheSelecionado = null)
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

            Thread.Sleep(500);
            Console.Clear();

            Console.WriteLine("════════════ 𝒞𝒶𝓇𝒹𝒶́𝓅𝒾ℴ 𝒹ℯ ℬ℮𝒷𝒾𝒷𝒶s ════════════\n");

            foreach (var bebidas in cardapioBebidas.Where(l => l.getCodigo() <= 8))
            {
                Console.WriteLine($"{bebidas.getCodigo()}. {bebidas.getDescricao()} - R$ {bebidas.getPrecoBase():F2}");
            }

            Console.Write("\nEscolha uma opção: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int escolha))
            {
                Console.WriteLine("Opção inválida.");
                return (null, null);
            }

            Bebida? bebidaSelecionada = cardapioBebidas.FirstOrDefault(b => b.getCodigo() == escolha);
            if (bebidaSelecionada == null)
            {
                Console.WriteLine("Opção inválida.");
                return (null, null);
            }

            string tamanhoEscolhido = "Padrão";

            // Se não for água (código 8), solicitar tamanho
            if (bebidaSelecionada.getCodigo() != 8)
            {
                tamanhoEscolhido = TamanhoBebida(bebidaSelecionada);
            }

            // Mensagem final incluindo a torta (se houver)
            if (lancheSelecionado != null)
            {
                Console.WriteLine($"{lancheSelecionado.getDescricao()} e {bebidaSelecionada.getDescricao()} ({tamanhoEscolhido}) foram adicionados ao seu carrinho.");
            }
            else
            {
                Console.WriteLine($"{bebidaSelecionada.getDescricao()} ({tamanhoEscolhido}) foi adicionado ao seu carrinho.");
            }

            return (bebidaSelecionada, tamanhoEscolhido);
        }

        // Seleciona o tamanho e ajusta o preço da bebida; retorna string representando o tamanho
        public string TamanhoBebida(Bebida bebida)
        {
            Thread.Sleep(500);
            Console.Clear();
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
