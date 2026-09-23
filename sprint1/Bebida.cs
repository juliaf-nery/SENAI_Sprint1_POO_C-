using System;

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

        public Bebida? MostrarCardapioBebidas()
        {
            // Criando os itens do cardápio usando o construtor com parâmetros
            Bebida b1 = new Bebida(1, "Soda italiana de Limão", 8.50);
            Bebida b2 = new Bebida(2, "Suco de Laranja", 7.00);
            Bebida b3 = new Bebida(3, "Suco de Pêssego", 7.00);
            Bebida b4 = new Bebida(4, "Suco de Morango", 7.50);
            Bebida b5 = new Bebida(5, "Milkshake de Nutella", 15.00);
            Bebida b6 = new Bebida(6, "Milkshake de Baunilha", 13.50);
            Bebida b7 = new Bebida(7, "Milkshake de Doce de Leite", 14.00);
            Bebida b8 = new Bebida(8, "Água mineral", 5.00);

            Console.Clear();
            Console.WriteLine("═══════════ 𝒞𝒶𝓇𝒹𝒶́𝓅𝒾ℴ 𝒹ℯ ℬℯ𝒷𝒾𝒹𝒶s𝓈 ═══════════");
            Console.WriteLine($"\n{b1.getCodigo()}. {b1.getDescricao()} - R$ {b1.getPrecoBase():F2}");
            Console.WriteLine($"{b2.getCodigo()}. {b2.getDescricao()} - R$ {b2.getPrecoBase():F2}");
            Console.WriteLine($"{b3.getCodigo()}. {b3.getDescricao()} - R$ {b3.getPrecoBase():F2}");
            Console.WriteLine($"{b4.getCodigo()}. {b4.getDescricao()} - R$ {b4.getPrecoBase():F2}");
            Console.WriteLine($"{b5.getCodigo()}. {b5.getDescricao()} - R$ {b5.getPrecoBase():F2}");
            Console.WriteLine($"{b6.getCodigo()}. {b6.getDescricao()} - R$ {b6.getPrecoBase():F2}");
            Console.WriteLine($"{b7.getCodigo()}. {b7.getDescricao()} - R$ {b7.getPrecoBase():F2}");
            Console.WriteLine($"{b8.getCodigo()}. {b8.getDescricao()} - R$ {b8.getPrecoBase():F2}");

            Console.Write("\nEscolha uma opção: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int escolha))
            {
                Console.WriteLine("Opção inválida.");
                return null;
            }

            switch (escolha)
            {
                case 1: return b1;
                case 2: return b2;
                case 3: return b3;
                case 4: return b4;
                case 5: return b5;
                case 6: return b6;
                case 7: return b7;
                case 8: return b8;
                default:
                    Console.WriteLine("Opção inválida.");
                    return null;
            }
        }
    }
}
