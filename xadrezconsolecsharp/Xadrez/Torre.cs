using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xadrez
{
    internal class Torre : Peca 
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor) { }

        private bool podeMover(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p == null || p.Cor != Cor;
        }
        
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.linhas, Tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            //acima 
            pos.definirValores(Posicao.linha - 1, Posicao.coluna);
            while(Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if(Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.linha = pos.linha - 1;
            }

            //abaixo
            pos.definirValores(Posicao.linha + 1, Posicao.coluna);
            while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.linha = pos.linha + 1;
            }

            //direita
            pos.definirValores(Posicao.linha, Posicao.coluna + 1);
            while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.linha = pos.coluna + 1;
            }

            //esquerda 
            pos.definirValores(Posicao.linha, Posicao.coluna - 1);
            while (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.linha = pos.coluna - 1;
            }

            return mat;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
