using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;


namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {

            //set up board



            int size = 10;

            List<string> board_1 = new List<string> { };
            List<string> board_2 = new List<string> { };
            List<string> em_board_1 = new List<string> { };
            List<string> em_board_2 = new List<string> { };
            List<string> check_for_let = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };


            //add terms into list
            for (int indi_squares = 0; indi_squares < Math.Pow(size, 2); indi_squares++)
            {
                //string indi_temp = (indi_squares + 1).ToString();
                int mod = indi_squares % 10;
                int tens = (indi_squares - (indi_squares % 10)) / 10;
                string indi_temp = check_for_let[tens] + (indi_squares % 10).ToString();
                board_1.Add(indi_temp);
                board_2.Add(indi_temp);
                em_board_1.Add("-");
                em_board_2.Add("-");

            }

            get_ship_pos g1 = new get_ship_pos(5, board_1);
            get_ship_pos g2 = new get_ship_pos(4, board_1);
            get_ship_pos g3 = new get_ship_pos(3, board_1);
            get_ship_pos g4 = new get_ship_pos(3, board_1);
            get_ship_pos g5 = new get_ship_pos(2, board_1);


            get_ship_pos g6 = new get_ship_pos(5, board_2);
            get_ship_pos g7 = new get_ship_pos(4, board_2);
            get_ship_pos g8 = new get_ship_pos(3, board_2);
            get_ship_pos g9 = new get_ship_pos(3, board_2);
            get_ship_pos g10 = new get_ship_pos(2, board_2);

            bool turn = true; //false = player 2;



            //game_loop
            for (bool num_turns = true; num_turns;)
            {
                int u_count_1 = 0;
                int u_count_2 = 0;

                //player 2 wins
                foreach (string a in board_1)
                {
                    if (a == "U")
                    {
                        u_count_1++;
                    }


                }
                if (u_count_1 == 0)
                {
                    Console.WriteLine("Player 2 wins");
                    break;
                }

                //player 1 wins
                foreach (string a in board_2)
                {
                    if (a == "U")
                    {
                        u_count_2++;
                    }


                }
                if (u_count_2 == 0)
                {
                    Console.WriteLine("Player 2 wins");
                    break;
                }



                //format full list 1
                List<string> board_w_form_1 = new List<string> { " | " };
                to_form f1 = new to_form(board_1, board_w_form_1, size);
                //Console.WriteLine(String.Join("", board_w_form_1));

                //format empty list 1
                List<string> em_board_w_form_1 = new List<string> { " | " };
                to_form e1 = new to_form(em_board_1, em_board_w_form_1, size);
                //Console.WriteLine(String.Join("", em_board_w_form_1));

                //format full list 2
                List<string> board_w_form_2 = new List<string> { " | " };
                to_form f2 = new to_form(board_2, board_w_form_2, size);
                //Console.WriteLine(String.Join("", board_w_form_2));

                //format empty list 2
                List<string> em_board_w_form_2 = new List<string> { " | " };
                to_form e2 = new to_form(em_board_2, em_board_w_form_2, size);
                //Console.WriteLine(String.Join("", em_board_w_form_2));


            if (turn == false)
                {
                    Console.WriteLine($"Player 2's turn. Your enemy's board:");
                    Console.WriteLine(String.Join("", em_board_w_form_2));
                    Console.WriteLine($"Player 2's turn. Your board:");
                    Console.WriteLine(String.Join("", board_w_form_2));

                    Console.WriteLine($"Enter the place you want to guess (example: A1)");
                    string test_string = Console.ReadLine();
                    int value = 0;
                    List<string> test_split = new List<string> { };
                    foreach (char a in test_string)
                    {
                        string b = a.ToString();
                        test_split.Add(b);
                    }
                    if (test_split[0] == "A")
                    {

                    }
                    else if (test_split[0] == "B")
                    {
                        value += 10;
                    }
                    else if (test_split[0] == "C")
                    {
                        value += 20;
                    }
                    else if (test_split[0] == "D")
                    {
                        value += 30;
                    }
                    else if (test_split[0] == "E")
                    {
                        value += 40;
                    }
                    else if (test_split[0] == "F")
                    {
                        value += 50;
                    }
                    else if (test_split[0] == "G")
                    {
                        value += 60;
                    }
                    else if (test_split[0] == "H")
                    {
                        value += 70;
                    }
                    else if (test_split[0] == "I")
                    {
                        value += 80;
                    }
                    else if (test_split[0] == "J")
                    {
                        value += 90;
                    }
                    //Console.WriteLine(test_split[0]);
                    int val_add = Int32.Parse(test_split[1]);
                    value += val_add;
                    //Console.WriteLine($"test string: {test_string} value: {value}");



                    //Console.WriteLine($"input: {test_string}. Value = {value}. Where on person's board{board_1[value]}");
                    //Console.WriteLine($"board_2[value]: {board_2[value]}");
                    //Console.WriteLine($"mod of {value} is {mod_test}");

                    //Console.WriteLine($"should be {board_1[x]} ={board_w_form_1[x + (x/10+1)]}");

                    string[] words = board_w_form_1[value + (value / 10 + 1)].Split(' ');
                    Console.WriteLine(words[0]);
                if (words[0] == "U")
                    {
                        em_board_2[value] = "H";
                        board_1[value] = "H";

                        Console.WriteLine($"{test_string} was a hit!");


                    }
                    else
                    {
                        em_board_2[value] = "M";
                        Console.WriteLine($"{test_string} was a miss!");
                        board_1[value] = "M";


                    }






                }
                else if (turn == true)
                {
                    Console.WriteLine($"Player 1's turn. Your enemy's board:");
                    Console.WriteLine(String.Join("", em_board_w_form_1));
                    Console.WriteLine($"Player 1's turn. Your board:");
                    Console.WriteLine(String.Join("", board_w_form_1));

                    Console.WriteLine($"Enter the place you want to guess (example: A1)");
                    string test_string = Console.ReadLine();
                    int value = 0;
                    List<string> test_split = new List<string> { };
                    foreach (char a in test_string)
                    {
                        string b = a.ToString();
                        test_split.Add(b);
                    }
                    if (test_split[0] == "A")
                    {

                    }
                    else if (test_split[0] == "B")
                    {
                        value += 10;
                    }
                    else if (test_split[0] == "C")
                    {
                        value += 20;
                    }
                    else if (test_split[0] == "D")
                    {
                        value += 30;
                    }
                    else if (test_split[0] == "E")
                    {
                        value += 40;
                    }
                    else if (test_split[0] == "F")
                    {
                        value += 50;
                    }
                    else if (test_split[0] == "G")
                    {
                        value += 60;
                    }
                    else if (test_split[0] == "H")
                    {
                        value += 70;
                    }
                    else if (test_split[0] == "I")
                    {
                        value += 80;
                    }
                    else if (test_split[0] == "J")
                    {
                        value += 90;
                    }
                    //Console.WriteLine(test_split[0]);
                    int val_add = Int32.Parse(test_split[1]);
                    value += val_add;

                    Console.WriteLine($"input: {test_string}. Value = {value}. Where on person's board{board_2[value]}");



                    //Console.WriteLine($"test string: {test_string} value: {value}");
                    Console.WriteLine($"board_2[value]: {board_2[value]}");
                string[] words = board_w_form_1[value + (value / 10 + 1)].Split(' ');
                Console.WriteLine(words[0]);
                if (words[0] == "U")
                    {
                        em_board_1[value] = "H";
                        Console.WriteLine($"{test_string} was a hit!");
                        board_2[value] = "H";



                    }
                    else
                    {
                        em_board_1[value] = "M";
                        Console.WriteLine($"{test_string} was a miss!");
                        board_2[value] = "M";


                    }


                }

                //turn = !turn;




            }
        }
    }

    public class get_ship_pos
    {
        public get_ship_pos(int len, List<string> board)
        {

            Random orientation = new Random();

            int h_o_v = orientation.Next(0, 2);//0 = horizontal 1 = vertical
                                               //int h_o_v = 1;

            Random line_x_r = new Random();
            Random line_y_r = new Random();


            int line_x = line_x_r.Next(0, 11 - len);
            int line_y = line_y_r.Next(0, 10);

            bool check = false;

            for (int peg_test_for_same = 0; peg_test_for_same < len; peg_test_for_same++)
            {
                if ((board[line_y * 10 + line_x + peg_test_for_same] == "U" && h_o_v == 0) || (board[line_y + (line_x + peg_test_for_same) * 10] == "U" && h_o_v == 1))//horizontal
                {
                    get_ship_pos g = new get_ship_pos(len, board);
                    break;

                }
                else
                {
                    if (peg_test_for_same == len - 1)
                    {
                        check = true;
                    }

                }

            }

            if (check == true)
            {
                for (int peg = 0; peg < len; peg++)
                {
                    if (h_o_v == 0)//horizontal
                    {
                        //string text = len.ToString() + "U";
                        board[line_y * 10 + line_x + peg] = "U";
                    }
                    else if (h_o_v == 1)//vertical
                    {
                        //string text = len.ToString() + "U";
                        board[line_y + (line_x + peg) * 10] = "U";

                    }

                }
            }






        }
    }

    public class to_form
    {
        public to_form(List<string> em_board_2, List<string> em_board_w_form_2, int size)
        {
            int string_count_3 = 0;
            foreach (string b in em_board_2)
            {
                //Console.WriteLine(b);
                String maxString = em_board_2.OrderByDescending(x => x.Length).First();
                //Console.WriteLine($"maxString: {maxString}");
                //Console.WriteLine($"difference between {maxString.Length} and {b.Length} is: {maxString.Length - b.Length}");
                string add_space = string.Join(" ", new string[maxString.Length - b.Length + 1]);
                //Console.WriteLine($"space length: {add_space.Length}");

                string input = b + add_space + " | ";
                //Console.WriteLine(input);
                em_board_w_form_2.Add(input);

                string_count_3++;
                //Console.WriteLine(string_count);
                //int temp_b = Int32.Parse(b);
                if ((string_count_3) % size == 0 && string_count_3 != 0 && string_count_3 != 100)
                {
                    em_board_w_form_2.Add("\n | ");

                }


            }
        }
    }

    public class input_to_value
    {
        public input_to_value(string test_string, int value)
        {

            //get value of input
            //string test_string = "J8";
            List<string> test_split = new List<string> { };
            foreach (char a in test_string)
            {
                string b = a.ToString();
                test_split.Add(b);
            }
            if (test_split[0] == "A")
            {

            }
            else if (test_split[0] == "B")
            {
                value += 10;
            }
            else if (test_split[0] == "C")
            {
                value += 20;
            }
            else if (test_split[0] == "D")
            {
                value += 30;
            }
            else if (test_split[0] == "E")
            {
                value += 40;
            }
            else if (test_split[0] == "F")
            {
                value += 50;
            }
            else if (test_split[0] == "G")
            {
                value += 60;
            }
            else if (test_split[0] == "H")
            {
                value += 70;
            }
            else if (test_split[0] == "I")
            {
                value += 80;
            }
            else if (test_split[0] == "J")
            {
                value += 90;
            }
            //Console.WriteLine(test_split[0]);
            int val_add = Int32.Parse(test_split[1]);
            value += val_add;


        }

    }
}