using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrezconsolecsharp.Tabuleiro.Enums;

namespace xadrezconsolecsharp.Tabuleiro
{
    internal class Peca
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
    }
}
