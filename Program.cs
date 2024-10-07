using System;
using System.IO;

class Jogo_da_Velha
{
    static char[,] partida = new char[3,3];
    static int jogadorAtual = 1;
    static int jogada = 0;
    static bool fimDeJogo = false;

    static void Main(string[] args)
    {
        while(!fimDeJogo)
        {
            Console.Clear();
            ExibirTabuleiro();
            Jogada();
            fimDeJogo = VerificarVencedor();
        }
    }

    static void ExibirTabuleiro()
    {
        Console.WriteLine("Jogador 1: X e Jogador 2: O");
        Console.WriteLine();
        Console.WriteLine("{0} | {1} | {2}", partida[0,0], partida[0,1], partida[0,2]);
        Console.WriteLine("---|---|---");
        Console.WriteLine("{0} | {1} | {2}", partida[1,0], partida[1,1], partida[1,2]);
        Console.WriteLine("---|---|---");
        Console.WriteLine("{0} | {1} | {2}", partida[2,0], partida[2,1], partida[2,2]);
        Console.WriteLine();
    }

    static void Jogada()
    {
        Console.WriteLine("Jogador {0}, escolha sua posição: ", jogadorAtual);
        int linha;
        int coluna;

        while
        (
            !int.TryParse(Console.ReadLine(), out linha) &
            !int.TryParse(Console.ReadLine(), out coluna) ||
            linha > 2 || linha < 0 || coluna > 2 || coluna < 0 ||
            partida[linha,coluna] == 'X' || partida[linha,coluna] == 'O' 
        )
        {
            Console.WriteLine("Entrada Inválida. Escolha uma posição válida:");
        }

        partida[linha,coluna] = jogadorAtual == 1 ? 'X' : 'O';
        jogadorAtual = jogadorAtual == 1 ? 2 : 1;
        jogada++;
    }

    static bool VerificarVencedor()
    {
        char[] opcoes = {'X', 'O'};

        foreach(char opcao in opcoes)
        {
            if
            (
                // Horizontais
                (partida[0,0] == opcao && partida[0,1] == opcao && partida[0,2] == opcao ) ||
                (partida[1,0] ==  opcao && partida[1,1] == opcao && partida[1,2] == opcao) ||
                (partida[2,0] == opcao && partida[2,1] == opcao && partida[2,2] == opcao)  ||
                // Verticais
                (partida[0,0] == opcao && partida[1,0] == opcao && partida[2,0] == opcao)  ||
                (partida[0,1] == opcao && partida[1,1] == opcao && partida[2,1] == opcao)  ||
                (partida[0,2] == opcao && partida[1,2] == opcao && partida[2,2] == opcao)||
                // Diagonais
                (partida[0,0] == opcao && partida[1,1] == opcao && partida[2,2] == opcao)  ||
                (partida[0,2] == opcao && partida[1,1] == opcao && partida[2,0] == opcao)
            )
            {
                Console.Clear();
                ExibirTabuleiro();
                Console.WriteLine("Jogador {0} venceu", opcao =='X' ? 1 : 2);
                return true;
            }
        }

        if(jogada == 9)
        {
            Console.Clear();
            ExibirTabuleiro();
            Console.WriteLine("O jogo terminou em empate!");
            return true;
        }
        
        return false;
    }
}