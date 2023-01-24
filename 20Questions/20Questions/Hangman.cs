using System;
using System.Collections.Generic;
using System.Linq;

namespace _20Questions
{
    public class Hangman_c
    {
        public Hangman_c(string right_answer)
        {
        //setup and one time things


            //formatting answer
            right_answer = right_answer.ToLower();
            right_answer.ToLower();

            //variables and lists
            int turns_wrong = 0;
            List<string> used = new List<string> { };//all entered letters go here
            List<string> rights = new List<string> { " " };//all right answer
            List<string> words_rights = new List<string> { " " };//all right answer
            List<string> rights_display = new List<string> {};//list for formatting 'rights' for show
            List<string> words_in_right = new List<string> { };//another list
            List<string> char_in_right = new List<string> { };//another list
            List<string> right_words_list = new List<string> { };//another list 



            rights_display.Add(" "); //allows for spaces not to be factored

            Console.WriteLine($"Let's play Hangman! There are {right_answer.Length} letters");

            //startup for hangman, lines will change based on answers
            string line1 = " -----------";
            string line2 = "   |       |";
            string line3 = "           |";
            string line4 = "           |";
            string line5 = "           |";
            string line6 = "           |";
            string line7 = "------------";

        //game loop
            for (bool num_turns = true; num_turns;)
            {
                //too many wrong turns and it breaks the loop
                if ((8 - turns_wrong) == 0)
                {
                    break;
                }

                //prints board, guesses, and letters
                Console.WriteLine(line1 + "\n" + line2 + "\n" + line3 + "\n" + line4 + "\n" + line5 + "\n" + line6 + "\n" + line7 + "\n");
                Console.WriteLine($"Correct guesses:{String.Join(" ", rights_display)}");
                Console.WriteLine($"Used Letters: {String.Join(",", used)}"+"\n");

                //user guess
                Console.WriteLine("Guess a letter");
                string user_guess = Console.ReadLine();
                user_guess = user_guess.ToLower();




                if (user_guess.Length > 1)
                {


                    right_words_list = right_answer.Split(" ").ToList();


                    //if user guess 
                    bool check = words_in_right.Contains(user_guess);




                    //if it contains and isn't aleady in it

                    Console.WriteLine($"user guess: {user_guess}");
                    //foreach (string a in right_words_list)
                    //{
                    //    Console.WriteLine($"right answer word list:{a}");

                    //    if (user_guess == a)
                    //    {
                    //        Console.WriteLine("MOOOOOOO");

                    //    }

                    //}


                    for (int rightanswer = 0; rightanswer < words_in_right.Count; rightanswer++)
                    {
                        if (words_rights.Contains(char_in_right[rightanswer]) == false)
                        {
                            rights_display[rightanswer] = "_";
                        }
                    }


                    if (!right_words_list.Contains(user_guess) && !(check == false))
                    {
                        right_words_list.Add(user_guess);
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
                        words_rights.Add(user_guess);

                    }

                    rights_display = right_words_list;


                }
                else
                {

                    //converts each character in the right anwswer to a list to check if user guess is in it
                    foreach (char a in right_answer)
                    {
                        string b = Convert.ToString(a);
                        char_in_right.Add(b);
                    }
                    //if user guess 
                    bool check = char_in_right.Contains(user_guess);


                    //if it contains and isn't aleady in it
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
                        Console.WriteLine("\n" + $"Sorry, {user_guess} is not a word in the magic word!");
                    }
                    //add to right if right 
                    else
                    {
                        Console.WriteLine("\n" + $"{user_guess} is a word in the magic word!");
                        words_rights.Add(user_guess);

                    }

                    //List<string> Right_for_words = new List<string> { };//another list 


                    //if (user_guess.Length < 1 && !char_in_right.Contains(user_guess) && !(check == false))
                    //{
                    //    foreach (string let_in_word in Right_for_words)
                    //    {
                    //        Right_for_words.Add(let_in_word);
                    //    }





                    for (int rightanswer = 0; rightanswer < char_in_right.Count; rightanswer++)
                    {
                        if (rights.Contains(char_in_right[rightanswer]) == false)
                        {
                            rights_display[rightanswer] = "_";
                        }
                    }

                rights_display = char_in_right;

                }//end for else statement (which is for single letter guesses)

                Console.WriteLine("Letters: " + string.Join(" ", rights_display));
                Console.WriteLine("Used Letters: " + string.Join(" ", used));

                //for changing hangman lines
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
                string join_right = string.Join("v", rights_display);
                                if (join_right == right_answer)
                                {
                                    Console.WriteLine($"You Won! The word was {right_answer}. The Board was:");
                                    break;
                                }

                //Console.WriteLine($"join_right: {join_right}; right_answer {right_answer}");



Console.WriteLine("\n" + "-----New Line-----" + "\n");

                List<string> rights_display_test = new List<string> { };//another list
                rights_display_test = rights_display;
                string test = String.Join("_", rights_display_test);
                Console.WriteLine(test);
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

