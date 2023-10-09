using System;
using System.Drawing;


namespace Projeto1
{
    public sealed class Cliente    
    {      
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set;}

        public Cliente(int id, string nome, string endereco)
        {
            EstruturaCliente(id, nome, endereco);
            Id = id;
            Nome = nome;
            Endereco = endereco;
        }
        private void EstruturaCliente(int id, string nome, string endereco)
        {
            if (id < 0)
            {
                throw new InvalidOperationException("O id esta invalido");
            }
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(endereco)) 
            {
                throw new InvalidOperationException("O endereço ou nome nao podem estar vazios");
            }
        }

    }

   
}
