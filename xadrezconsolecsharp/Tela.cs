using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace xadrez
{
    internal class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + "  ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    imprimirPeca(tab.Peca(i, j));
                }
                Console.WriteLine();               
            }
            Console.WriteLine();
            Console.WriteLine("   a b c d e f g h");
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundooriginal = Console.BackgroundColor;
            ConsoleColor fundoalterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoalterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundooriginal;
                    }
                    imprimirPeca(tab.Peca(i, j));
                    Console.BackgroundColor = fundooriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundooriginal;
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        private static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }            
        }
    }
}
