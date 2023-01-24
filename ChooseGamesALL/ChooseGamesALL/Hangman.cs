using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;

namespace ChooseGamesALL
{
    public class Hangman
    {
        public Hangman(string right_answer)
        {


    //out of loop for both

            right_answer = right_answer.ToLower();
            int turns_wrong = 0;
            right_answer.ToLower();

            List<string> used = new List<string> { };

            List<string> rights = new List<string> { " " };
            List<string> rights_display = new List<string> { };
            rights_display.Add(" ");

            int char_count = 0;
            int word_count = 1; //amount of spaces (which is how I calculate words + 1
            foreach (char a in right_answer)
            {
                if (a == ' ')
                {
                    word_count += 1;
                }
                else
                {
                    char_count += 1;
                }
            }

            Console.WriteLine($"Let's play Hangman! There are {char_count} characters(minus spaces) in {word_count} words");

            string line1 = " -----------";
            string line2 = "   |       |";
            string line3 = "           |";
            string line4 = "           |";
            string line5 = "           |";
            string line6 = "           |";
            string line7 = "------------";

            //set up other lists and ask user input

            for (bool num_turns = true; num_turns;)
            {
                if ((8 - turns_wrong) == 0)
                {
                    break;
                }

                Console.WriteLine(line1 + "\n" + line2 + "\n" + line3 + "\n" + line4 + "\n" + line5 + "\n" + line6 + "\n" + line7 + "\n");


                List<string> char_in_right = new List<string> { };
                rights_display = char_in_right;

                //if user guess is greater than 1
                List<string> char_in_right_FH = new List<string> { };

                List<string> vowel_list = new List<string> { };
                List<string> const_list = new List<string> { };

                foreach (char a in right_answer)
                {
                    string b = Convert.ToString(a);
                    char_in_right_FH.Add(b);
                }


                foreach (string a in char_in_right_FH)
                {
                    if (!rights.Contains(a))
                    {

                        if (a == "a" || a == "i" || a == "o" || a == "u" || a == "y")
                        {
                            vowel_list.Add(a);
                        }
                        else
                        {
                            const_list.Add(a);
                        }
                    }
                }

                Console.WriteLine("Guess a letter. If you want a clue for a vowel, write help.");
                string user_guess = Console.ReadLine();
                user_guess = user_guess.ToLower();


                if (user_guess == "help")
                {

                    Console.WriteLine("Do you want a constanant (write c), a vowel (v), or no hint (type anything else). ");
                    string help_ask = Console.ReadLine();

                    if (help_ask == "v")
                    {
                        Random rnd = new Random();

                        int help_answer = rnd.Next(0, vowel_list.Count);
                        Console.WriteLine($"Your vowel hint is: {vowel_list[help_answer]}");
                        turns_wrong += 1;
                    } else if (help_ask == "c")
                    {
                        Random rnd = new Random();
                        int help_answer = rnd.Next(0, const_list.Count);
                        Console.WriteLine($"Your vowel hint is: {const_list[help_answer]}");
                        turns_wrong += 1;

                    }


                }
                if (user_guess.Length > 1 && user_guess != "help")
                {
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
                        foreach (char a in user_guess)
                        {
                            string a_2 = a.ToString();
                            rights.Add(a_2);
                        }
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

                    
                    List<string> spacing_for_words = new List<string> { };
                    foreach (string c in rights_display)
                    {
                        foreach (char b in c)
                        {
                            string b_2 = b.ToString();
                            rights.Add(b_2);
                            spacing_for_words.Add(b_2);
                            //spacing_for_words.Add(" ");
                        }
                        spacing_for_words.Add(" ");


                    }

                    Console.WriteLine("Correct Guesses: " + string.Join(" ", spacing_for_words));
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
                    //Console.WriteLine($"joined together: {join_right}");
                    //Console.WriteLine($"right answer   : {right_answer}");
                    if (join_right == right_answer)
                    {
                        Console.WriteLine($"You Won! The word was {right_answer}. The Board was:");
                        break;
                    }

                    //Console.WriteLine($"join_right: {join_right}; right_answer {right_answer}");



                    Console.WriteLine("\n" + "-----New Line-----" + "\n");

                }
                //if user input is 1 character
                else if (user_guess.Length == 1 && user_guess != "help")
                {
                    foreach (char a in right_answer)
                    {
                        string b = Convert.ToString(a);
                        char_in_right.Add(b);
                    }


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
                            rights_display[rightanswer] = "_";
                        }
                    }

                    //head


                    Console.WriteLine($"Correct Guesses: {String.Join(" ", rights_display)}");
                    Console.WriteLine($"Used Letters: {String.Join(",", used)}" + "\n");

                    //test if won
                    string join_right = string.Join("", rights_display);
                    if (join_right == right_answer)
                    {
                        Console.WriteLine($"You Won! The word was {right_answer}. The Board was:");
                        break;
                    }

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

                    //Console.WriteLine($"join_right: {join_right}; right_answer {right_answer}");



                    Console.WriteLine("\n" + "-----New Line-----" + "\n");


                }


                //string test_CIR = string.Join(",", rights);
                //Console.WriteLine($"test for terms in CIR: {test_CIR}");


            }





            //bottom text -- should be universal
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