using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xadrez
{
    internal class Rei : Peca
    {
        private PartidaDeXadrez partida;
        
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor) 
        {
            this.partida = partida;
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p == null || p.Cor != this.Cor;
        }

        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.qntMovimentos == 0;
        }
        
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.linhas, Tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.definirValores(Posicao.linha - 1, Posicao.coluna);
            if(Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //ne
            pos.definirValores(Posicao.linha - 1, Posicao.coluna + 1);
            if (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //direita
            pos.definirValores(Posicao.linha, Posicao.coluna + 1);
            if (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //se
            pos.definirValores(Posicao.linha + 1, Posicao.coluna + 1);
            if (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //abaixo
            pos.definirValores(Posicao.linha + 1, Posicao.coluna);
            if (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //so
            pos.definirValores(Posicao.linha + 1, Posicao.coluna - 1);
            if (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //esquerda
            pos.definirValores(Posicao.linha, Posicao.coluna - 1);
            if (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //no
            pos.definirValores(Posicao.linha - 1, Posicao.coluna - 1);
            if (Tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // jogada especial roque
            if(qntMovimentos==0 && !partida.xeque)
            {
                //roque pequeno
                Posicao posT1 = new Posicao(Posicao.linha, Posicao.coluna + 3);
                if (testeTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(Posicao.linha, Posicao.coluna + 1);
                    Posicao p2 = new Posicao(Posicao.linha, Posicao.coluna + 2);
                    if(Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null)
                    {
                        mat[Posicao.linha, Posicao.coluna + 2] = true;
                    }
                }
                //roque grande
                Posicao posT2 = new Posicao(Posicao.linha, Posicao.coluna - 4);
                if (testeTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(Posicao.linha, Posicao.coluna - 1);
                    Posicao p2 = new Posicao(Posicao.linha, Posicao.coluna - 2);
                    Posicao p3 = new Posicao(Posicao.linha, Posicao.coluna - 3);
                    if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null && Tabuleiro.Peca(p3) == null)
                    {
                        mat[Posicao.linha, Posicao.coluna - 2] = true;
                    }
                }
            }


            return mat;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
