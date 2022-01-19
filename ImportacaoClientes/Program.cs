using System;

namespace ImportacaoClientes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // instancia o fluxo de controle
            var fluxo = new Fluxo();
            // chama o metodo que vai rodar a logica do componente
            fluxo.Start();
        }
    }
}
