using System;
using System.Collections.Generic;
using System.Linq;

namespace _20Questions
{
    public class HangmanW
    {
        public HangmanW(string right_answer)
        {
            right_answer = right_answer.ToLower();
            int turns_wrong = 0;
            right_answer.ToLower();

            List<string> used = new List<string> { };

            List<string> rights = new List<string> { " " };
            List<string> rights_display = new List<string> { };
            rights_display.Add(" ");

            Console.WriteLine($"Let's play Hangman! There are {right_answer.Length} letters");

            string line1 = " -----------";
            string line2 = "   |       |";
            string line3 = "           |";
            string line4 = "           |";
            string line5 = "           |";
            string line6 = "           |";
            string line7 = "------------";


            for (bool num_turns = true; num_turns;)
            {
                if ((8 - turns_wrong) == 0)
                {
                    break;
                }

                Console.WriteLine(line1 + "\n" + line2 + "\n" + line3 + "\n" + line4 + "\n" + line5 + "\n" + line6 + "\n" + line7 + "\n");
                Console.WriteLine($"Correct guesses:{String.Join(" ", rights_display)}");
                Console.WriteLine($"Used Letters: {String.Join(",", used)}" + "\n");

                List<string> char_in_right = new List<string> { };
                rights_display = char_in_right;

                Console.WriteLine("Guess a letter");
                string user_guess = Console.ReadLine();
                user_guess = user_guess.ToLower();


                char_in_right = right_answer.Split(" ").ToList();


                bool check = char_in_right.Contains(user_guess);

                if (!char_in_right.Contains(user_guess) && !(check == false))
                {
                    char_in_right.Add(user_guess);
                }
                if (!used.Contains(user_guess))
                {
                    used.Add(user_guess);
                }
                //add a body part if wrong
                if (check == false)
                {
                    turns_wrong++;
                    Console.WriteLine("\n" + $"Sorry, {user_guess} is not in the magic word!");
                }
                //add to right if right 
                else
                {
                    Console.WriteLine("\n" + $"{user_guess} is in the magic word!");
                    rights.Add(user_guess);

                }

                rights_display = char_in_right;

                for (int rightanswer = 0; rightanswer < char_in_right.Count; rightanswer++)
                {
                    if (rights.Contains(char_in_right[rightanswer]) == false)
                    {
                        rights_display[rightanswer] = string.Join("_", new string[rights_display[rightanswer].Length + 1]); ;
                    }
                }
                Console.WriteLine("Letters: " + string.Join(" ", rights_display));

                //head
                if (turns_wrong == 1)
                {
                    line3 = "  (        |";
                }
                else if (turns_wrong > 1)
                {
                    line3 = "  ( )      |";
                }
                if (turns_wrong > 2)
                {
                    line4 = "   |       |";
                }
                //body
                if (turns_wrong == 4)
                {
                    line5 = "  |=|      |";
                }
                else if (turns_wrong == 5)
                {
                    line5 = "--|=|      |";
                }
                else if (turns_wrong > 5)
                {
                    line5 = "--|=|--    |";
                }
                //legs
                if (turns_wrong == 7)
                {
                    line6 = "  |        |";
                }
                else if (turns_wrong > 7)
                {
                    line6 = "  | |      |";
                }


                //test if won
                //Console.WriteLine(rights_display.)
                string join_right = string.Join(" ", rights_display);
                Console.WriteLine($"joined together: {join_right}");
                Console.WriteLine($"right answer   : {right_answer}");
                if (join_right == right_answer)
                {
                    Console.WriteLine($"You Won! The word was {right_answer}. The Board was:");
                    break;
                }

                //Console.WriteLine($"join_right: {join_right}; right_answer {right_answer}");



                Console.WriteLine("\n" + "-----New Line-----" + "\n");


            }

            //to reprint if reaches maximum
            Console.WriteLine(line1 + "\n" + line2 + "\n" + line3 + "\n" + line4 + "\n" + line5 + "\n" + line6 + "\n" + line7 + "\n");

            //if lose
            if (turns_wrong == 8)
            {
                Console.WriteLine("You Lose!");

            }

        }


    }
}

