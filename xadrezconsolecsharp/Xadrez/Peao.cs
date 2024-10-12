using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace xadrez
{
    internal class Peao : Peca
    {
        private PartidaDeXadrez partida;

        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existeInimigo(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p != null && p.Cor != this.Cor;
        }

        private bool livre(Posicao pos)
        {
            return Tabuleiro.Peca(pos) == null;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.linhas, Tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            if (Cor == Cor.Branca)
            {
                pos.definirValores(Posicao.linha - 1, Posicao.coluna);
                if (Tabuleiro.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(Posicao.linha - 2, Posicao.coluna);
                if (Tabuleiro.posicaoValida(pos) && livre(pos) && qntMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(Posicao.linha - 1, Posicao.coluna - 1);
                if (Tabuleiro.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(Posicao.linha - 1, Posicao.coluna + 1);
                if (Tabuleiro.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                //jogada especial en passant
                if(Posicao.linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.linha, Posicao.coluna - 1);
                    if(Tabuleiro.posicaoValida(esquerda) && existeInimigo(esquerda) && Tabuleiro.Peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        mat[esquerda.linha - 1, esquerda.coluna] = true;
                    }
                    Posicao direita = new Posicao(Posicao.linha, Posicao.coluna + 1);
                    if (Tabuleiro.posicaoValida(direita) && existeInimigo(direita) && Tabuleiro.Peca(direita) == partida.vulneravelEnPassant)
                    {
                        mat[direita.linha - 1, direita.coluna] = true;
                    }
                }

            }
            else
            {
                pos.definirValores(Posicao.linha + 1, Posicao.coluna);
                if (Tabuleiro.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(Posicao.linha + 2, Posicao.coluna);
                if (Tabuleiro.posicaoValida(pos) && livre(pos) && qntMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(Posicao.linha + 1, Posicao.coluna - 1);
                if (Tabuleiro.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(Posicao.linha + 1, Posicao.coluna + 1);
                if (Tabuleiro.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                
                //jogada especial en passant
                if (Posicao.linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.linha, Posicao.coluna - 1);
                    if (Tabuleiro.posicaoValida(esquerda) && existeInimigo(esquerda) && Tabuleiro.Peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        mat[esquerda.linha + 1, esquerda.coluna] = true;
                    }
                    Posicao direita = new Posicao(Posicao.linha, Posicao.coluna + 1);
                    if (Tabuleiro.posicaoValida(direita) && existeInimigo(direita) && Tabuleiro.Peca(direita) == partida.vulneravelEnPassant)
                    {
                        mat[direita.linha + 1, direita.coluna] = true;
                    }
                }
            }
            return mat;
        }
    }
}
