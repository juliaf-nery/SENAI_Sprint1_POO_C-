using System;
using System.Threading;

namespace sprint1
{
    //public class Lanche : ItemCardapio
    //{
    //    // Construtor herdado da classe pai
    //    public Lanche(int codigo, string descricao, double precoBase)
    //        : base(codigo, descricao, precoBase)
    //    {
    //    }

    //    // Construtor padrão
    //    public Lanche() : base() { }

    //    public Lanche? MostrarCardapioLanches()
    //    {
    //        // Criando os itens do cardápio usando o construtor com parâmetros
    //        Lanche lanche1 = new Lanche(1, "Torta de Floresta Negra", 18.00);
    //        Lanche lanche3 = new Lanche(3, "Torta de Brigadeiro com mousse", 16.50);
    //        Lanche lanche2 = new Lanche(2, "Torta de Limão", 15.00);
    //        Lanche lanche5 = new Lanche(4, "Torta de Marácuja", 16.50);
    //        Lanche lanche4 = new Lanche(5, "Torta de Pudim", 16.50);
    //        Lanche lanche6 = new Lanche(6, "Torta de Frango com Catupiry", 17.00);
    //        Lanche lanche7 = new Lanche(7, "Torta de Frango com Quatro queijos", 16.50);
    //        Lanche lanche8 = new Lanche(8, "Torta de Carne com Banana da Terra", 16.50);
    //        Lanche lanche9 = new Lanche(9, "Torta de Queijo e Presunto", 16.50);
    //        Lanche lanche10 = new Lanche(10, "Torta de Bacalhau", 16.50);

    //        Thread.Sleep(1000);
    //        Console.Clear();

    //        Console.WriteLine("================ Cardápio de Tortas ================");
    //        Console.WriteLine("\nTortas Doces:");
    //        // Exibindo a descrição e o preço formatado (F2 exibe 2 casas decimais)
    //        Console.WriteLine($"{lanche1.getCodigo()}. {lanche1.getDescricao()} - R$ {lanche1.getPrecoBase():F2}");
    //        Console.WriteLine($"{lanche2.getCodigo()}. {lanche2.getDescricao()} - R$ {lanche2.getPrecoBase():F2}");
    //        Console.WriteLine($"{lanche3.getCodigo()}. {lanche3.getDescricao()} - R$ {lanche3.getPrecoBase():F2}");
    //        Console.WriteLine($"{lanche4.getCodigo()}. {lanche4.getDescricao()} - R$ {lanche4.getPrecoBase():F2}");
    //        Console.WriteLine($"{lanche5.getCodigo()}. {lanche5.getDescricao()} - R$ {lanche5.getPrecoBase():F2}");

    //        Console.WriteLine("\nTortas Salgadas:");
    //        Console.WriteLine($"{lanche6.getCodigo()}. {lanche6.getDescricao()} - R$ {lanche6.getPrecoBase():F2}");
    //        Console.WriteLine($"{lanche7.getCodigo()}. {lanche7.getDescricao()} - R$ {lanche7.getPrecoBase():F2}");
    //        Console.WriteLine($"{lanche8.getCodigo()}. {lanche8.getDescricao()} - R$ {lanche8.getPrecoBase():F2}");
    //        Console.WriteLine($"{lanche9.getCodigo()}. {lanche9.getDescricao()} - R$ {lanche9.getPrecoBase():F2}");
    //        Console.WriteLine($"{lanche10.getCodigo()}. {lanche10.getDescricao()} - R$ {lanche10.getPrecoBase():F2}");

    //        Console.Write("\nEscolha uma opção: ");
    //        string? input = Console.ReadLine();

    //        if (!int.TryParse(input, out int escolha))
    //        {
    //            Console.WriteLine("Opção inválida.");
    //            return null;
    //        }

    //        // Retorna o objeto correspondente à escolha do usuário
    //        switch (escolha)
    //        {
    //            case 1:
    //                return lanche1;
    //            case 2:
    //                return lanche2;
    //            case 3:
    //                return lanche3;
    //            case 4:
    //                return lanche4;
    //            case 5:
    //                return lanche5;
    //            case 6:
    //                return lanche6;
    //            case 7:
    //                return lanche7;
    //            case 8:
    //                return lanche8;
    //            case 9:
    //                return lanche9;
    //            case 10:
    //                return lanche10;
    //            default:
    //                Console.WriteLine("Opção inválida.");
    //                return null;
    //        }
    //    }
    //}

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

            Console.WriteLine("================ Cardápio de Tortas ================");

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
                    return lancheSelecionado;
                }
            }

            Console.WriteLine("Opção inválida.");
            return null;
        }
    }






}