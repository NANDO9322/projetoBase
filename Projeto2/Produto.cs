using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2
{
    public sealed class Produto
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public string Fabricante { get; private set; }
        public int Valor { get; private set; }

        public Produto(int id, string descricao, string fabricante, int valor)
        {
            EstruturaProduto( id, valor);
            Id = id;
            Descricao = descricao;
            Fabricante = fabricante;
            Valor = valor;
        }
        private void EstruturaProduto(int id, int valor)
        {
            if(id<0)
            {
                throw new InvalidOperationException("O id esta invalido");
            }
            if (valor<0)
            {
                throw new InvalidOperationException("Não é possivel registrar valores negativos");
            }
        } 
    }
}
