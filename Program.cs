using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praticando_02
{
    class Program
    {
        //Metodo do tabuleiro
        static void Tabuleiro(char[,] velha)
        {
            Console.WriteLine("            C");
            Console.WriteLine("        1   2   3");
            Console.Write("     1");
            Console.WriteLine("\t" + velha[0, 0] + " | " + velha[0, 1] + " | " + velha[0, 2]);
            Console.WriteLine("       -----------");
            Console.Write("   L 2");
            Console.WriteLine("\t" + velha[1, 0] + " | " + velha[1, 1] + " | " + velha[1, 2]);
            Console.WriteLine("       -----------");
            Console.Write("     3");
            Console.WriteLine("\t" + velha[2, 0] + " | " + velha[2, 1] + " | " + velha[2, 2]);
        }

        //Metodo para mostrar numero de rodadas
        static void numeroRodadas(int rodadas)
        {
            int rodadaAux = 0;
            rodadaAux = rodadas - 1;
            if(rodadaAux > 0)
            {
                Console.WriteLine("\nRodadas restantes: " + rodadaAux);
            }
            else
            {
                Console.WriteLine("\n!!! ULTIMA RODADA !!!");
            }

        }

        //Metodo para mostrar o placar do jogo 
        static void Placar(string NomeP1, int pointP1, string NomeP2, int pointP2)
        {
            Console.WriteLine(NomeP1 + " " + pointP1 + " X " + pointP2 + " " + NomeP2 + "\n");
        }
        static void Main(string[] args)
        {
            int rodadas = 0, pontoP1 = 0, pontoP2 = 0;

            Console.WriteLine("Quantas rodadas quer jogar ?");
            rodadas = Convert.ToInt32(Console.ReadLine());

            //Pegando nome dos jogadores
            string player1, player2;
            Console.Write("Nome do Player 1: ");
            player1 = Console.ReadLine();
            Console.Write("Nome do Player 2: ");
            player2 = Console.ReadLine();

            while (rodadas > 0)
            {
                //iniciando a matriz vazia
                char[,] velha = new char[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        velha[i, j] = ' ';
                    }
                }

                char symbol = 'X';

                //Console.Clear();

                //Sorteando quem vai jogar primeiro
                Random rand = new Random();
                int firstPlayer = rand.Next(1, 6);
                if (firstPlayer == 1 || firstPlayer == 3 || firstPlayer == 5)
                {
                    Console.WriteLine("O primeiro a jogar será: " + player1 + " com: " + symbol);
                    Console.WriteLine("Aperte enter para iniciar...");
                    Console.ReadLine();
                }
                else if (firstPlayer == 2 || firstPlayer == 4 || firstPlayer == 6)
                {
                    Console.WriteLine("O primerio a jogar será: " + player2 + " com: " + symbol);
                    Console.WriteLine("Aperte enter para iniciar...");
                    Console.ReadLine();
                }

                //Numero de turnos
                int turno = 1;
                while (turno < 10)
                {
                    Console.Clear();

                    Tabuleiro(velha);

                    numeroRodadas(rodadas);

                    Console.WriteLine("Turno: " + turno);

                    //Troca de simbolo
                    if (turno % 2 != 0)
                    {
                        symbol = 'X';
                    }
                    else
                    {
                        symbol = 'O';
                    }

                    //Troca de jogadores 
                    if ((symbol == 'X') && (firstPlayer == 1 || firstPlayer == 3 || firstPlayer == 5))
                    {
                        Console.WriteLine("Sua vez: " + player1);
                    }
                    else if ((symbol == 'X') && (firstPlayer == 2 || firstPlayer == 4 || firstPlayer == 6))
                    {
                        Console.WriteLine("Sua vez: " + player2);
                    }
                    else if ((symbol == 'O') && (firstPlayer == 1 || firstPlayer == 3 || firstPlayer == 5))
                    {
                        Console.WriteLine("Sua vez: " + player2);
                    }
                    else if ((symbol == 'O') && (firstPlayer == 2 || firstPlayer == 4 || firstPlayer == 6))
                    {
                        Console.WriteLine("Sua vez: " + player1);
                    }

                    //Marcando onde vai ser adicionado o simbolo
                    int line, column;
                    Console.WriteLine("Em qual linha quer marcar: " + symbol);
                    line = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Em qual coluna quer marcar: " + symbol);
                    column = Convert.ToInt32(Console.ReadLine());

                    //Erro de linhas, colunas e lugar ocupado
                    if (line < 1 || column < 1 || line > 3 || column > 3)
                    {
                        Console.WriteLine("!!! JOGADA INVÁLIDA !!!");
                        Console.WriteLine("Aperte enter para seguir...");
                        Console.ReadLine();
                    }
                    else if (velha[line - 1, column - 1] != ' ')
                    {
                        Console.WriteLine("!!! LUGAR OCUPADO !!!");
                        Console.WriteLine("Aperte enter para seguir...");
                        Console.ReadLine();
                    }
                    else
                    { //Marcando o simbolo no tabuleiro
                        velha[line - 1, column - 1] = symbol;
                        turno++;
                    }

                    if (velha[0, 0] == 'X' && velha[0, 1] == 'X' && velha[0, 2] == 'X' ||
                        velha[1, 0] == 'X' && velha[1, 1] == 'X' && velha[1, 2] == 'X' ||
                        velha[2, 0] == 'X' && velha[2, 1] == 'X' && velha[2, 2] == 'X' ||
                        velha[0, 0] == 'X' && velha[1, 0] == 'X' && velha[2, 0] == 'X' ||
                        velha[0, 1] == 'X' && velha[1, 1] == 'X' && velha[2, 1] == 'X' ||
                        velha[0, 2] == 'X' && velha[1, 2] == 'X' && velha[2, 2] == 'X' ||
                        velha[0, 0] == 'X' && velha[1, 1] == 'X' && velha[2, 2] == 'X' ||
                        velha[0, 2] == 'X' && velha[1, 1] == 'X' && velha[2, 0] == 'X')
                    {
                        turno = 11;
                        Console.Clear();

                        Tabuleiro(velha);

                        Console.WriteLine("\n!!! JOGO FINALIZADO !!!");
                        if (firstPlayer == 1 || firstPlayer == 3 || firstPlayer == 5)
                        {
                            Console.WriteLine(player1 + " VENCEU!!!");
                            pontoP1++;
                        }
                        else if (firstPlayer == 2 || firstPlayer == 4 || firstPlayer == 6)
                        {
                            Console.WriteLine(player2 + " VENCEU!!!");
                            pontoP2++;
                        }
                    }
                    else if (velha[0, 0] == 'O' && velha[0, 1] == 'O' && velha[0, 2] == 'O' ||
                             velha[1, 0] == 'O' && velha[1, 1] == 'O' && velha[1, 2] == 'O' ||
                             velha[2, 0] == 'O' && velha[2, 1] == 'O' && velha[2, 2] == 'O' ||
                             velha[0, 0] == 'O' && velha[1, 0] == 'O' && velha[2, 0] == 'O' ||
                             velha[0, 1] == 'O' && velha[1, 1] == 'O' && velha[2, 1] == 'O' ||
                             velha[0, 2] == 'O' && velha[1, 2] == 'O' && velha[2, 2] == 'O' ||
                             velha[0, 0] == 'O' && velha[1, 1] == 'O' && velha[2, 2] == 'O' ||
                             velha[0, 2] == 'O' && velha[1, 1] == 'O' && velha[2, 0] == 'O')
                    {
                        turno = 11;
                        Console.Clear();

                        Tabuleiro(velha);

                        Console.WriteLine("\n!!! JOGO FINALIZADO !!!");
                        if (firstPlayer == 1 || firstPlayer == 3 || firstPlayer == 5)
                        {
                            Console.WriteLine(player2 + " VENCEU!!!");
                            pontoP2++;
                        }
                        else if (firstPlayer == 2 || firstPlayer == 4 || firstPlayer == 5)
                        {
                            Console.WriteLine(player1 + " VENCEU!!!");
                            pontoP1++;
                        }
                    }
                    else if (turno == 10)
                    {
                        Console.Clear();
                        Tabuleiro(velha);

                        Console.WriteLine("\n!!! JOGO FINALIZOU EMPATADO !!!");
                        Console.WriteLine("Nenhum jogador pontuou!!!");
                    }
                }

                //Pontuação
                Console.WriteLine("\n!!! PONTUAÇÃO !!!");
                Placar(player1, pontoP1, player2, pontoP2);
                Console.ReadLine();

                rodadas--;

                Console.Clear();
                
                //nova rodada
                if (rodadas > 0)
                {
                    Console.WriteLine("\t!!! Iniciando nova rodada !!!");
                    Console.ReadLine();
                }
            }
                //Final do jogo
                if ((rodadas == 0) && (pontoP1 == pontoP2))
                {
                    Console.WriteLine("!!! OS JOGADORES EMPATARAM NAS PONTUAÇÕES !!!");
                    Placar(player1, pontoP1, player2, pontoP2);
                }
                else
                {
                    Console.WriteLine("!!! PONTUAÇÃO FINAL !!!");
                    Placar(player1, pontoP1, player2, pontoP2);
                }
            
            
            Console.ReadLine();
        }
    }
}
