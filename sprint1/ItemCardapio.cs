using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace sprint1
{
    public abstract class ItemCardapio
    { 
        protected int codigo;
        protected string descricao;
        protected double precoBase;

        // Constructor 
        public ItemCardapio(int codigo, string descricao, double precoBase)
        {
            this.codigo = codigo;
            this.descricao = descricao;
            this.precoBase = precoBase;
        }

        // Metódos
        public int getCodigo() { return codigo; }
        public string getDescricao() { return descricao; }
        public double getPrecoBase() { return precoBase; }
    }
}
