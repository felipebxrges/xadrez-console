using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xadrez
{
    internal class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor) { }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.linhas, Tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);
            
            return mat;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
