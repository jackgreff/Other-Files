using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;

namespace ChooseGamesALL
{
    public class TicTacToeChange
    {
        public TicTacToeChange(int size)
        {
            Boolean player_is_x = true;
            int turn_count = 0;
            string what_to_put = "X";


            List<string> board = new List<string> { };

            for (int indi_squares = 0; indi_squares < Math.Pow(size, 2); indi_squares++)
            {
                string indi_temp = (indi_squares + 1).ToString();
                board.Add(indi_temp);
            }

            //Console.WriteLine(turn_count);

            //set which player is x and o
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
                if (turn_count < Math.Pow(size, 2))
                {
                    Console.WriteLine($"Player go. It's {what_to_put}'s turn. Enter the number where you want to go: \n");
                }
                //Console.WriteLine(turn_count);
                List<string> board_w_form = new List<string> { " | " };
                //board_w_form = board;

                int string_count = 0;

                foreach (string b in board)
                {
                    //Console.WriteLine(b);
                    String maxString = board.OrderByDescending(x => x.Length).First();
                    //Console.WriteLine($"maxString: {maxString}");
                    //Console.WriteLine($"difference between {maxString.Length} and {b.Length} is: {maxString.Length - b.Length}");
                    string add_space = string.Join(" ", new string[maxString.Length - b.Length + 1]);
                    //Console.WriteLine($"space length: {add_space.Length}");

                    string input = b + add_space + " | ";
                    //Console.WriteLine(input);
                    board_w_form.Add(input);

                    string_count++;
                    Console.WriteLine(string_count);
                    //int temp_b = Int32.Parse(b);
                    if ((string_count) % size == 0 && string_count != 0)
                    {
                        board_w_form.Add("\n | ");

                    }
                }
                Console.WriteLine(String.Join("", board_w_form));


                //Console.WriteLine($"| {board[0]} | {board[1]} | {board[2]} |");
                //Console.WriteLine($"| {board[3]} | {board[4]} | {board[5]} |");
                //Console.WriteLine($"| {board[6]} | {board[7]} | {board[8]} |");

                if (turn_count == 9)
                {
                    break;
                }

                string user_placement = Console.ReadLine();
                int string_user = Int32.Parse(user_placement) - 1;

                board[string_user] = what_to_put;
                player_is_x = !player_is_x;

                //for rows
                for (int i = 1; i < size; i++)//i is meant to represent each row
                {
                    List<string> temp_list_for_check = new List<string> {};

                    for (int indi_squares = 0 + size * (i - 1); indi_squares < size * i; indi_squares++)
                    {

                        if (indi_squares % size == 0)
                        {
                            temp_list_for_check.Add(board[indi_squares]);//adds the first term. 
                        }
                        else//adds any terms that are not the first term to the list
                        {
                            if (!temp_list_for_check.Contains(board[indi_squares]))
                            {//if list does not have the term
                                temp_list_for_check.Add(board[indi_squares]);
                            }
                        }

                        Console.WriteLine($"row = {i}, column = {indi_squares}, number of ");


                    }


                    if (temp_list_for_check.Count == 1)
                    {
                        Console.WriteLine("Congrats. You win!");
                    }
                }

                //for each column
                for (int i = 1; i < size; i++)//i is meant to represent each row
                {
                    List<string> temp_list_for_check = new List<string> { };
                    //for (int indi_squares = 0 + size * (i - 1); indi_squares < size * i; indi_squares++)

                    for (int indi_squares = 0; indi_squares < size; indi_squares++)
                    {
                        int indi_temp = indi_squares * size + i;

                        if (indi_squares == 0)
                        {
                            temp_list_for_check.Add(board[indi_temp]);//adds the first term. 
                        }
                        else//adds any terms that are not the first term to the list
                        {
                            if (!temp_list_for_check.Contains(board[indi_temp]))
                            {//if list does not have the term
                                temp_list_for_check.Add(board[indi_temp]);
                            }
                        }

                    }

                    if (temp_list_for_check.Count == 1)
                    {
                        Console.WriteLine("Congrats. You win!");
                    }
                }

                //for diagnols top left to bottom right
                for (int i = 1; i < i; i++)//i is meant to represent each row
                {

                    List<string> temp_list_for_check = new List<string> { };
                    //for (int indi_squares = 0 + size * (i - 1); indi_squares < size * i; indi_squares++)

                    for (int indi_squares = 0; indi_squares < size; indi_squares++)
                    {
                        int indi_temp = 1 + indi_squares * (size + 1);

                        if (indi_squares == 0)
                        {
                            temp_list_for_check.Add(board[indi_temp]);//adds the first term. 
                        }
                        else//adds any terms that are not the first term to the list
                        {
                            if (!temp_list_for_check.Contains(board[indi_temp]))
                            {//if list does not have the term
                                temp_list_for_check.Add(board[indi_temp]);
                            }
                        }

                    }

                    if (temp_list_for_check.Count == 1)
                    {
                        Console.WriteLine("Congrats. You win!");
                    }
                }

                //for diagnols bottom left to top right
                for (int i = 1; i < i; i++)//i is meant to represent each row
                {

                    List<string> temp_list_for_check = new List<string> { };
                    //for (int indi_squares = 0 + size * (i - 1); indi_squares < size * i; indi_squares++)

                    for (int indi_squares = 0; indi_squares < size; indi_squares++)
                    {
                        int indi_temp = 4 + (indi_squares) * (size - 1);

                        if (indi_squares == 0)
                        {
                            temp_list_for_check.Add(board[indi_temp]);//adds the first term. 
                        }
                        else//adds any terms that are not the first term to the list
                        {
                            if (!temp_list_for_check.Contains(board[indi_temp]))
                            {//if list does not have the term
                                temp_list_for_check.Add(board[indi_temp]);
                            }
                        }

                    }

                    if (temp_list_for_check.Count == 1)
                    {
                        Console.WriteLine("Congrats. You win!");
                    }
                }



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
