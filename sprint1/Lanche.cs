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

        public Lanche? MostrarCardapioLanches()
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

            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine("════════════ 𝒞𝒶𝓇𝒹𝒶́𝓅𝒾ℴ 𝒹ℯ 𝒯ℴ𝓇𝓉𝒶𝓈 ════════════");

            // 2. Exibição automática dos doces (códigos 1 a 5)
            Console.WriteLine("\nTortas Doces:");
            foreach (var item in cardapio.Where(l => l.getCodigo() <= 5))
            {
                Console.WriteLine($"{item.getCodigo()}. {item.getDescricao()} - R$ {item.getPrecoBase():F2}");
            }

            // 3. Exibição automática das salgadas (códigos 6 a 10)
            Console.WriteLine("\nTortas Salgadas:");
            foreach (var item in cardapio.Where(l => l.getCodigo() > 5))
            {
                Console.WriteLine($"{item.getCodigo()}. {item.getDescricao()} - R$ {item.getPrecoBase():F2}");
            }

            Console.Write("\nEscolha uma opção: ");
            string? input = Console.ReadLine();

            // 4. Validação e retorno direto sem usar 'switch'
            if (int.TryParse(input, out int escolha))
            {
                // Busca na lista o lanche com o código correspondente à escolha do usuário
                Lanche? lancheSelecionado = cardapio.FirstOrDefault(l => l.getCodigo() == escolha);

                if (lancheSelecionado != null)
                {
                    Console.WriteLine($"Você escolheu: {lancheSelecionado.getDescricao()} — adicionado ao carrinho.");
                    return lancheSelecionado;
                }
            }

            Console.WriteLine("Opção inválida.");
            return null;
        }
    }
}