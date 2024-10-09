using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int Turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xeque { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            Turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarMovimentos();
            Peca PecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if(PecaCapturada != null)
            {
                capturadas.Add(PecaCapturada);
            }
            return PecaCapturada;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.retirarPeca(destino);
            p.decrementarMovimentos();
            if(pecaCapturada != null)
            {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarPeca(p, origem);
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executaMovimento(origem, destino);

            if (estaEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada); 
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            if (estaEmXeque(adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            Turno++;
            mudaJogador();
        }

        public void validarPosicaoOrigem(Posicao pos)
        {
            if(tab.Peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if(jogadorAtual != tab.Peca(pos).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!tab.Peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não existe movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tab.Peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posiçaõ de destino inválida!");
            }
        }

        public void mudaJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if(x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        private Cor adversaria(Cor cor)
        {
            if(cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca rei(Cor cor)
        {
            foreach(Peca x in pecasEmJogo(cor))
            {
                if(x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool estaEmXeque(Cor cor)
        {
            Peca R = rei(cor);
            if(R == null)
            {
                throw new TabuleiroException("Não existe rei da cor " + cor + " no tabuleiro!");  
            }
            foreach(Peca x in pecasEmJogo(adversaria(cor)))
            {
                bool[,] mat = x.movimentosPossiveis();
                if (mat[R.Posicao.linha, R.Posicao.coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }
        
        private void colocarPecas()
        {
            colocarNovaPeca('a', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('a', 2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('b', 1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('b', 2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('c', 1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('c', 2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Dama(tab, Cor.Branca));
            colocarNovaPeca('d', 2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('e', 1, new Rei(tab, Cor.Branca));
            colocarNovaPeca('e', 2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('f', 1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('f', 2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('g', 1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('g', 2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('h', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('h', 2, new Peao(tab, Cor.Branca));

            colocarNovaPeca('a', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('a', 8, new Peao(tab, Cor.Preta));
            colocarNovaPeca('b', 7, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('b', 8, new Peao(tab, Cor.Preta));
            colocarNovaPeca('c', 7, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('c', 8, new Peao(tab, Cor.Preta));
            colocarNovaPeca('d', 7, new Dama(tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Peao(tab, Cor.Preta));
            colocarNovaPeca('e', 7, new Rei(tab, Cor.Preta));
            colocarNovaPeca('e', 8, new Peao(tab, Cor.Preta));
            colocarNovaPeca('f', 7, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('f', 8, new Peao(tab, Cor.Preta));
            colocarNovaPeca('g', 7, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('g', 8, new Peao(tab, Cor.Preta));
            colocarNovaPeca('h', 7, new Torre(tab, Cor.Preta));
            colocarNovaPeca('h', 8, new Peao(tab, Cor.Preta));
        }

    }
}
