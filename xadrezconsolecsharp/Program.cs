using xadrezconsolecsharp.Tabuleiro;
using xadrezconsolecsharp.Tabuleiro.Enums;
using xadrezconsolecsharp.Xadrez;

internal class Program
{
    private static void Main(string[] args)
    {
        Tabuleiro tab = new Tabuleiro(8, 8);

        PosicaoXadrez pos = new PosicaoXadrez('c', 1);
        Console.WriteLine(pos);
        Console.WriteLine(pos.toPosicao());
    }
}