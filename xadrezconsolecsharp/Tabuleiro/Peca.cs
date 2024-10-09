using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xadrez
{
    internal abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; set; }
        public int qntMovimentos { get; set; }
        public Tabuleiro Tabuleiro { get; set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            Posicao = null; //posicao inicia nula pois é dever do metodo colocarPeca colocar uma peça em dada posicao
            Tabuleiro = tabuleiro;
            Cor = cor;
            qntMovimentos = 0;
        }
        
        public void incrementarMovimentos()
        {
            qntMovimentos++;
        }

        public void decrementarMovimentos()
        {
            qntMovimentos--;
        }

        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for(int i = 0; i < Tabuleiro.linhas; i++)
            {
                for(int j = 0; j < Tabuleiro.colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool podeMoverPara(Posicao pos)
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }

        public abstract bool[,] movimentosPossiveis(); //matriz de movimentos possiveis, é abstrato pois a classe peca é muito genérica
    }
}
