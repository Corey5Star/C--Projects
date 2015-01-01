using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack_Project
{
    class Program
    {
        #region Deck Values
        static string deck = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
        static string values = "1111222233334444555566667777888899990000JJJJQQQQKKKK";
        static string suitvalues = "SHDCSHDCSHDCSHDCSHDCSHDCSHDCSHDCSHDCSHDCSHDCSHDCSHDC";
        static string Suit = "";
        #endregion

        #region Total
        static int total = 0;
        #endregion

        #region Face Values (Bool)
        static bool ace = false;
        static bool jack = false;
        static bool queen = false;
        static bool king = false;
        #endregion

        static void Main(string[] args)
        {
            Console.Title = "BlackJack";
            asciiArt();
            Thread.Sleep(5);
            Console.WriteLine("###############################################################################");
            Thread.Sleep(5);
            Console.WriteLine("Rules of the Game");
            Thread.Sleep(5);
            Console.WriteLine("------------------");
            Thread.Sleep(5);
            Console.WriteLine("Type hit to deal the next card.");
            Thread.Sleep(5);
            Console.WriteLine("Type new to deal the next set.");
            Thread.Sleep(5);
            Console.WriteLine("Type reset to reset the Deck.");
            Thread.Sleep(5);
            Console.WriteLine("###############################################################################");
            Thread.Sleep(5);
            Console.WriteLine("");
            Thread.Sleep(5);
            Console.WriteLine("Would you like to start a game? Type Y to start; Type anything else to close");
            Thread.Sleep(5);
            string s = Console.ReadLine();
            if (s.Contains("Y"))
            {
                Draw();
            }

        }

        static void Draw()
        {
            #region Randomization and Card Removal
            Random r = new Random();
            int l = r.Next(deck.Length);
            char c = values[l];
            char suit = suitvalues[l];
            string b = deck.Substring(l + 1);
            string a = deck.Remove(l);
            deck = a + b;
            b = values.Substring(l + 1);
            a = values.Remove(l);
            values = a + b;
            b = suitvalues.Substring(l + 1);
            a = suitvalues.Remove(l);
            suitvalues = a + b;
            int cv = 0;
            #endregion

            #region Card Values
            if (c.ToString() == "1")
            {
                ace = true;
                cv = 1;
            }
            else if (c.ToString() == "J")
            {
                jack = true;
                cv = 10;
            }
            else if (c.ToString() == "Q")
            {
                queen = true;
                cv = 10;
            }
            else if (c.ToString() == "K")
            {
                king = true;
                cv = 10;
            }
            else if (c.ToString() == "0")
            {
                cv = 10;
            }
            else
            {
                cv = Convert.ToInt32(c.ToString());
            }
            #endregion

            #region Suits
            if (suit.ToString() == "S")
            {
                Suit = "Spades";
            }
            else if (suit.ToString() == "H")
            {
                Suit = "Hearts";
            }
            else if (suit.ToString() == "D")
            {
                Suit = "Diamonds";
            }
            else if (suit.ToString() == "C")
            {
                Suit = "Clubs";
            }
            #endregion

            #region Writing the Lines
            if (ace)
            {
                Console.WriteLine("Ace" + " of " + Suit);
            }
            else if (jack)
            {
                Console.WriteLine("Jack" + " of " + Suit);
                jack = false;
            }
            else if (queen)
            {
                Console.WriteLine("Queen" + " of " + Suit);
                queen = false;
            }
            else if (king)
            {
                Console.WriteLine("King" + " of " + Suit);
                king = false;
            }
            else
            {
                Console.WriteLine(cv + " of " + Suit);
            }
            #endregion

            #region Addition and Scoring
            if (ace == true)
            {
                total = total + cv;
                if (total + 10 == 21 || total == 21)
                {
                    asciiArt();
                }
                else if (total + 10 < 21)
                {
                    Console.WriteLine("Score: " + total + " or " + (total + 10));
                }
                else if (total + 10 > 21 && total < 21)
                {
                    Console.WriteLine("Score: " + total);
                }
                else
                {
                    Console.WriteLine("You Bust");
                }
            }
            else
            {
                total = total + cv;
                if (total == 21)
                {
                    asciiArt();
                }
                else if (total > 21)
                {
                    Console.WriteLine("You Bust");
                }
                else
                {
                    Console.WriteLine("Score: " + total);
                }
            }
            #endregion

            #region Reading the Input

            string s = Console.ReadLine();

            if (s == "hit" || s == "reset" || s == "new")
            {
                if (s == "reset")
                {
                    resetDeck();
                }
                else if (s == "new")
                {
                    if (values == "")
                    {
                        Console.WriteLine("Deck is Empty.");
                        Console.ReadKey();
                    }
                    else
                    {
                        ace = false;
                        total = 0;
                        Draw();
                    }
                }
                else if (s == "hit" && cv <= 21)
                {
                    if (values == "")
                    {
                        Console.WriteLine("Deck is Empty.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Draw();
                    }
                }

            }
            #endregion
        }

        static void resetDeck()
        {

            deck = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
            values = "1111222233334444555566667777888899990000JJJJQQQQKKKK";
            suitvalues = "SHDCSHDCSHDCSHDCSHDCSHDCSHDCSHDCSHDCSHDCSHDCSHDCSHDC";
            Suit = "";
            total = 0;
            ace = false;
        }

        static void asciiArt()
        {
            Console.WriteLine("-------------------------------------------------------------------------------" + Environment.NewLine
            + "-----------------------------------BLACKJACK-----------------------------------"
            + Environment.NewLine);
            Console.WriteLine("???????????????????????????????????????*#######################################");
            Thread.Sleep(5);
            Console.WriteLine("?????????????????????????????????????? . ######################################");
            Thread.Sleep(5);
            Console.WriteLine("?????????????????????????????????????  %  #####################################");
            Thread.Sleep(5);
            Console.WriteLine("????????????????????????????????????  %*:  ####################################");
            Thread.Sleep(5);
            Console.WriteLine("???????????????????????????????????  %#*?:  ###################################");
            Thread.Sleep(5);
            Console.WriteLine("?????????????????????????????????  ,%##*??:.  #################################");
            Thread.Sleep(5);
            Console.WriteLine("???????????????????????????????  ,%##*?*#*??:.  ###############################");
            Thread.Sleep(5);
            Console.WriteLine("?????????????????????????????  ,%###*??*##*???:.  #############################");
            Thread.Sleep(5);
            Console.WriteLine("???????????????????????????  ,%####*???*###*????:.  ###########################");
            Thread.Sleep(5);
            Console.WriteLine("?????????????????????????  ,%####**????*####**????:.  #########################");
            Thread.Sleep(5);
            Console.WriteLine("???????????????????????  ,%#####**?????*#####**?????:.  #######################");
            Thread.Sleep(5);
            Console.WriteLine("??????????????????????  %######**??????*######**??????:  ######################");
            Thread.Sleep(5);
            Console.WriteLine("?????????????????????  %######**???????*#######**??????:  #####################");
            Thread.Sleep(5);
            Console.WriteLine("????????????????????  %######***???????*#######***??????:  ####################");
            Thread.Sleep(5);
            Console.WriteLine("????????????????????  %######***???????*#######***??????:  ####################");
            Thread.Sleep(5);
            Console.WriteLine("????????????????????  %######***???????*#######***??????:  ####################");
            Thread.Sleep(5);
            Console.WriteLine("?????????????????????  %######**??????***######**??????:  #####################");
            Thread.Sleep(5);
            Console.WriteLine("??????????????????????  '%######****:^%*:^%****??????:'  ######################");
            Thread.Sleep(5);
            Console.WriteLine("????????????????????????   '%####*:'  %*:  '%*????:'   ########################");
            Thread.Sleep(5);
            Console.WriteLine("??????????????????????????           %#*?:           ##########################");
            Thread.Sleep(5);
            Console.WriteLine("?????????????????????????????????  ,%##*??:.  #################################");
            Thread.Sleep(5);
            Console.WriteLine("???????????????????????????????  .%###***???:.  ###############################");
            Thread.Sleep(5);
            Console.WriteLine("??????????????????????????????                   ##############################");
            Thread.Sleep(5);
            Console.WriteLine("???????????????????????????????????????*#######################################");
            Console.WriteLine(Environment.NewLine + "-----------------------------------BLACKJACK-----------------------------------"
            + Environment.NewLine + "-------------------------------------------------------------------------------");
        }
    }
}