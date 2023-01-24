using System;
using System.Collections.Generic;

namespace ChooseGamesALL
{
    public class TicTacToe
    {
        public TicTacToe()
        {
            Boolean player_is_x = true;
            int turn_count = 0;
            string what_to_put = "X";
            List<string> board = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            Console.WriteLine("Let's play Tic Tac Toe! Player 1 goes first. Do you prefer to be X or O?");
            string user_xoro = Console.ReadLine();

            if (user_xoro == "X")
            {
                player_is_x = true;
            }
            else if (user_xoro == "O")
            {
                player_is_x = false;
            }


            for (bool num_turns = true; num_turns;)
            {
                if (player_is_x == true)
                {
                    what_to_put = "X";

                }
                else
                {
                    what_to_put = "O";
                }

                //Console.WriteLine(string.Join(string.Join("", board)));
                if (turn_count < 9)
                {
                    Console.WriteLine($"Player go. It's {what_to_put}'s turn. Enter the number where you want to go: \n");
                }
                //Console.WriteLine(turn_count);
                Console.WriteLine($"| {board[0]} | {board[1]} | {board[2]} |");
                Console.WriteLine($"| {board[3]} | {board[4]} | {board[5]} |");
                Console.WriteLine($"| {board[6]} | {board[7]} | {board[8]} |");

                if (turn_count == 9)
                {
                    break;
                }

                string user_placement = Console.ReadLine();
                int string_user = Int32.Parse(user_placement)-1;

                board[string_user] = what_to_put;

                if ((board[0] == board[1] && board[1] == board[2])//upper row
                 || (board[3] == board[4] && board[4] == board[5])//middle row
                 || (board[6] == board[7] && board[7] == board[8])//bottom row
                 || (board[0] == board[3] && board[3] == board[6])//left column
                 || (board[1] == board[4] && board[4] == board[7])//center column
                 || (board[2] == board[5] && board[5] == board[8])//right column
                 || (board[2] == board[4] && board[4] == board[6])//negative slope diagonal 
                 || (board[0] == board[4] && board[4] == board[8])//positive slope diagonal 
                   )
                {
                    
                    if (turn_count % 2 == 0)
                    {
                    Console.WriteLine("Congrats! Player 2 wins!");

                    }
                    else
                    {
                    Console.WriteLine("Congrats! Player 1 wins!");

                    }
                    break;

                }

                if (turn_count == 8)
                {
                    Console.WriteLine("It's a tie! \n");
                   
                }

          
                player_is_x = !player_is_x;
                if (turn_count < 8)
                {
                    Console.WriteLine("Other players turn");
                }
                turn_count++;



            }

        }

        }
    }
