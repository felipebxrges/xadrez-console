using xadrez;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            PartidaDeXadrez partida = new PartidaDeXadrez();

            while (!partida.terminada)
            {
                Console.Clear();
                Tela.imprimirTabuleiro(partida.tab);

                Console.WriteLine();
                Console.Write("Digite a posição de origem: ");
                Posicao origem = Tela.lerPosicaoXadrez().toPosicao();

                bool[,] posicoesPossiveis = partida.tab.Peca(origem).movimentosPossiveis();
                
                Console.Clear();
                Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                Console.Write("Digite a posição de destino: ");
                Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                partida.executaMovimento(origem, destino);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}