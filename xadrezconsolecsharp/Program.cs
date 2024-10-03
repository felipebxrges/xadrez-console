using xadrezconsolecsharp.Tabuleiro;
using xadrezconsolecsharp.Tabuleiro.Enums;

internal class Program
{
    private static void Main(string[] args)
    {
        Tabuleiro tab = new Tabuleiro(8, 8);
            
       //teste da impressão das peças
        Peca p = new Peca(tab, Cor.Preta);
        tab.colocarPeca(p, new Posicao(0, 0));
        Peca m = new Peca(tab, Cor.Branca);
        tab.colocarPeca(m, new Posicao(7, 0));
        Tela.imprimirTabuleiro(tab);
    }
}