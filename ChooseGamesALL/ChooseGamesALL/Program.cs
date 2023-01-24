using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;

namespace ChooseGamesALL
{
    class Program
    {
        static void Main(string[] args)
        {

            for (Boolean a = true; a; a = !a)
            {
                Console.WriteLine("Let's play a game! Do you want to play Battleship (write 1),");
                Console.WriteLine("Hangman (2), 20 Questions (3), or Tic Tac Toe (4), or War (5).");
                Console.WriteLine("NOTE: If you want the default option later, write anything else.");


                string choose = Console.ReadLine();
                int choose_n = Int32.Parse(choose);

                if (choose_n == 1)
                {
                    Console.WriteLine("You chose battleship! Do you want to play single player (write YES) or multiplayer (NO)?");
                    string p1 = Console.ReadLine();
                    Battleship b = new Battleship(p1);
                }
                else if (choose_n == 2)
                {
                    Console.WriteLine("You chose Hangman! Do you want to pick a word (write PICK) or have a random word (out of 2), which is the default)?");
                    string pick = Console.ReadLine();
                    List<string> words = new List<string>() { "tree", "book", "pencil", "notebook", "phone", "baseball", "typewriter", "meat", "charger", "backpack", "America", "cow", "football", "apple", "banana", "cake", "pants", "shirt", "card", "mathematics", "highlighter", "shoes", "adidas", "drawer", "notebook" };
                    string word = "WORD";
                    if (pick == "PICK")
                    {
                        Console.WriteLine("Which word would you like to use?");
                        word = Console.ReadLine();
                    }
                    else
                    {
                        Random rnd = new Random();
                        word = words[rnd.Next(0, words.Count)];

                    }

                    Hangman h = new Hangman(word);
                }
                else if (choose_n == 3)
                {
                    Console.WriteLine("You chose 20 Questions! Do you want a random number (write PICK) or specific one(default)?");
                    string pick = Console.ReadLine();

                    int word = 30;
                    if (pick == "PICK")
                    {
                        Console.WriteLine("Which word would you like to use?");
                        string word_t = Console.ReadLine();
                        word = Int32.Parse(word_t);
                    }
                    else
                    {
                        Console.WriteLine("What do you want the range to be?");
                        Console.WriteLine("Lowerbound (including this number):");
                        string lower_t = Console.ReadLine();
                        int lower = Int32.Parse(lower_t);
                        Console.WriteLine("Higherbound (NOT including this number):");
                        string higher_t = Console.ReadLine();
                        int higher = Int32.Parse(higher_t);
                        Random rnd = new Random();
                        word = rnd.Next(higher, lower);

                    }
                    _20Questions q = new _20Questions(30);
                }
                else if (choose_n == 4)
                {
                    TicTacToe t = new TicTacToe();
                }
                else if (choose_n == 5)
                {
                    War w = new War();
                }
                else if (choose_n == 6)
                {
                    TicTacToeChange T = new TicTacToeChange(5);

                }

                Console.WriteLine("If you want to stop, write STOP. Otherwise write anything else");
                string stop = Console.ReadLine();

                if (stop == "STOP")
                {
                    break;
                }


            }
        }
    }
}
