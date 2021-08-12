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
        static void Main(string[] args)
        {
            int opcao = 1;
            // bool newPlayers = true;

            while (opcao == 1)
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

                //Pegando nome dos jogadores
                string player1, player2;
                char symbol = 'X';
               // if (newPlayers == true)
              //  {
                    Console.Write("Nome do Player 1: ");
                    player1 = Console.ReadLine();
                    Console.Write("Nome do Player 2: ");
                    player2 = Console.ReadLine();
               // }
               
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
                        }
                        else if (firstPlayer == 2 || firstPlayer == 4 || firstPlayer == 6)
                        {
                            Console.WriteLine(player2 + " VENCEU!!!");
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
                        }
                        else if (firstPlayer == 2 || firstPlayer == 4 || firstPlayer == 5)
                        {
                            Console.WriteLine(player1 + " VENCEU!!!");
                        }
                    }
                    else if (turno == 10)
                    {
                        Console.Clear();
                        Tabuleiro(velha);

                        Console.WriteLine("\n!!! JOGO FINALIZOU EMPATADO !!!");
                    }
                }
                Console.WriteLine("Deseja jogar novamente? 1-SIM 2-NÃO");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
            
            Console.ReadLine();
        }
    }
}
