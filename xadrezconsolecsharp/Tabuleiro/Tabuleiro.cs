﻿    
namespace xadrez
    {
        internal class Tabuleiro
        {
            public int linhas { get; set; }
            public int colunas { get; set; }

            private Peca[,] pecas;

            public Tabuleiro(int linhas, int colunas)
            {
                this.linhas = linhas;
                this.colunas = colunas;
                pecas = new Peca[linhas, colunas];
            }

            public Peca Peca(int linha, int coluna)
            {
                return pecas[linha, coluna];
            }

            public Peca Peca(Posicao pos)
            {
                return pecas[pos.linha, pos.coluna];
            }

            public void colocarPeca(Peca peca, Posicao pos)
            {
                pecas[pos.linha, pos.coluna] = peca;
                peca.Posicao = pos;
            }

            public bool posicaoValida(Posicao pos)
            {
                if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
                {
                    return false;
                }
                return true;
            }

            public void validarPosicao(Posicao pos)
            {
                if (!posicaoValida(pos))
                {
                    throw new TabuleiroException("Posiçao inválida!");
                }
            }

            public bool existePeca(Posicao pos)
            {
                validarPosicao(pos);
                return Peca(pos) != null;
            }

            public Peca retirarPeca(Posicao pos)
            {
                if (Peca(pos) == null)
                {
                    return null;
                }
                Peca aux = Peca(pos);
                aux.Posicao = null;
                pecas[pos.linha, pos.coluna] = null;
                return aux;
            }        
        }
    }


