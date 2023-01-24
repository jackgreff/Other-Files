using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;

namespace ChooseGamesALL
{
     public class War
    {
        public War()
        {


            //setup; adding cards to sets

            List<int> Player2_set = new List<int> { };

        List<int> countset = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
        List<int> StartingCardSet = new List<int> { };
        StartingCardSet = countset;

            Console.WriteLine(countset.Count);

            Random rnd = new Random();
            List<int> Player1_set = new List<int> { };

            Console.WriteLine("Welcome to War! Shuffling Deck...");

            for (int addcard = 0; addcard < 52; addcard++)
            {
                int cardtoset = rnd.Next(0, StartingCardSet.Count);

                if (addcard <= 25)
                {
                    //Console.WriteLine($"added the {addcard} to Player1_set");
                    Player1_set.Add(StartingCardSet[cardtoset]);
                }
                else if (addcard > 25)
                {
                    //Console.WriteLine($"added the {addcard} to Player2_set");

                    Player2_set.Add(StartingCardSet[cardtoset]);


                }

                StartingCardSet.Remove(StartingCardSet[cardtoset]);

                //}

                //Console.WriteLine($"Player 1:   count: {Player1_set.Count}   Combined: {string.Join(",", Player1_set)}\n");
                //Console.WriteLine($"Player 2:   count: {Player2_set.Count}   Combined: {string.Join(",", Player2_set)}\n");
            }

            Console.WriteLine("We Are Ready to Play!");
            //Console.WriteLine($"Write GO each round to start a new round.");


            for (bool num_turns = true; num_turns;)
            {
                string confirm_go = Console.ReadLine();
                //Console.WriteLine($"confirm_go 1 = {confirm_go}");
                confirm_go = confirm_go.ToLower();
                //Console.WriteLine($"confirm_go 2 = {confirm_go}");

                if (confirm_go == "go")
                {

                    if (Player1_set.Count > 0 || Player2_set.Count > 0)
                    {
                        Console.WriteLine($"{Player1_set.Count},{Player2_set.Count}");
                        Card c = new Card(Player1_set, Player2_set);
                    }
                    else if (Player1_set.Count == 0)
                    {
                        Console.WriteLine("Player 2 wins!");
                        break;
                    }
                    else if (Player2_set.Count == 0)
                    {
                        Console.WriteLine("Player 1 wins!");
                        break;
                    }
                }


            }

        }

        public class Card
        {
            public Card(List<int> s1, List<int> s2)
            {

                Console.WriteLine("-----            -----");
                Console.WriteLine($"| {s1[0]} |   versus:  | {s2[0]} |");
                Console.WriteLine("-----            -----");


                if (s1[0] > s2[0])
                {
                    Console.WriteLine($"Player 1 Wins. {s1[0]} is greater than {s2[0]}.");

                    int buffer = s1[0];
                    s1.Add(buffer);//   ]
                    s1.Remove(s1[0]);//] puts the card in the back. Buffer needed so it doesn't go to the first value


                    s1.Add(s2[0]);//   ]
                    s2.Remove(s2[0]);//]puts loser behind winning card

                    Console.WriteLine($" \n \n Player 1 has {s1.Count} cards \n Player 2 has {s2.Count} cards");
                }
                else if (s1[0] < s2[0])
                {
                    Console.WriteLine($"Player 2 Wins. {s2[0]} is greater than {s1[0]}.");

                    int buffer = s2[0];
                    s2.Add(buffer);//   ]
                    s2.Remove(s2[0]);//] puts winner card in the back


                    s2.Add(s1[0]);//   ]
                    s1.Remove(s1[0]);//]puts loser behind winning card

                    Console.WriteLine($" \n \n Player 1 has {s1.Count} cards \n Player 2 has {s2.Count} cards");

                }
                else
                {
                    int cardtakeout = 4;


                    if (s1.Count < 4 || s2.Count < 4)
                    {
                        if (s1.Count < s2.Count)
                        {
                            cardtakeout = s1.Count - 1;//minus one since zero is the first term in list, 1 is in count
                        }
                        else if (s1.Count > s2.Count)
                        {
                            cardtakeout = s2.Count - 1;//minus one for same reason above
                        }
                    }

                    Console.WriteLine($"You tied. You both had a {s1[0]} You each put {cardtakeout - 2} cards down. Let's see who wins the tie, and the winner gets all 8 cards.");

                    Console.WriteLine("-----            -----");
                    Console.WriteLine($"| {s1[cardtakeout]} |   versus:  | {s2[cardtakeout]} |");
                    Console.WriteLine("-----            -----");



                    if (s1[cardtakeout] > s2[cardtakeout])
                    {
                        Console.WriteLine($"Player 1 won this round with a {s1[cardtakeout]} over Player 2's {s2[cardtakeout]}");
                        //puts first four cards in winning deck to the back of the deck



                        for (int card = 0; card < cardtakeout; card++)
                        {
                            //buffer so it doesnt replace first one
                            int buffer = s1[card];
                            s1.Add(buffer);
                            //after putting in back, remove from front
                            s1.Remove(s1[card]);
                            //winning set gets others cards
                            s1.Add(s2[card]);
                            //remove losing card from set
                            s2.Remove(s2[card]);


                        }



                        Console.WriteLine($" \n \n Player 1 has {s1.Count} cards \n Player 2 has {s2.Count} cards");

                    }
                    else if (s1[cardtakeout] < s2[cardtakeout])
                    {
                        //puts first four cards in winning deck to the back of the deck
                        Console.WriteLine($"Player 2 won this round with a {s1[cardtakeout]} over Player 1's {s2[cardtakeout]}");

                        for (int card = 0; card < cardtakeout; card++)
                        {
                            //buffer so it doesnt replace first one
                            int buffer = s2[card];
                            s2.Add(buffer);
                            //after putting in back, remove from front
                            s2.Remove(s2[card]);
                            //winning set gets others cards
                            s2.Add(s1[card]);
                            //remove losing card from set
                            s1.Remove(s1[card]);


                        }


                        Console.WriteLine($" \n \n Player 1 has {s1.Count} cards \n Player 2 has {s2.Count} cards");


                    }
                    else if (s1[cardtakeout] == s2[cardtakeout])
                    {
                        //puts first four cards in winning deck to the back of the deck
                        Console.WriteLine($"Player 1 and Player 2 both had a {s1[cardtakeout]} again. Nothing happens. \n Player 1 has {s1.Count} cards \n Player 2 has {s2.Count} cards");//might want to put the card class in the class here so it repeats or create a new one.

                        for (int card = 0; card < cardtakeout; card++)
                        {
                            //shuffles both of them to the back
                            int buffers1 = s1[card];
                            s1.Add(buffers1);
                            s1.Remove(s1[card]);

                            int buffers2 = s2[card];
                            s2.Add(buffers2);
                            s1.Remove(s2[card]);



                        }


                        Console.WriteLine($" \n \n Player 1 has {s1.Count} cards \n Player 2 has {s2.Count} cards");

                    }
                }

                Console.WriteLine($"Player 1:   count: {s1.Count}   Combined: {string.Join(",", s1)}\n");
                Console.WriteLine($"Player 2:   count: {s2.Count}   Combined: {string.Join(",", s2)}\n");
            }
        }
    }
}

