using xadrez;

internal class Program
{
    private static void Main(string[] args)
    {
        PartidaDeXadrez partida = new PartidaDeXadrez();
        Tela.imprimirTabuleiro(partida.tab);
    }
}