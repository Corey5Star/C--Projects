using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slots
{
    class Program
    {

        static string s1 = "qwerty";
        static string s2 = "uiopas";
        static string s3 = "dfghjk";
        static string v = "134567";
        static int totalpayout = 0;
        static int payout = 0;
        static Random r = new Random();

        static void Main(string[] args)
        {
            RunSlot();

        }

        static void RunSlot()
        {

            int count = 0;
            bool notwin = true;
            string slot1 = randSlot1();
            string slot2 = randSlot2();
            string slot3 = randSlot3();
            while (notwin == true)
            {
                slot1 = randSlot1();
                slot2 = randSlot2();
                slot3 = randSlot3();
                int v1 = Convert.ToInt32(slot1);
                int v2 = Convert.ToInt32(slot2);
                int v3 = Convert.ToInt32(slot3);
                if (slot1 + slot2 + slot3 == "777")
                {
                    notwin = false;
                    Console.WriteLine("You won! 777" + Environment.NewLine + "And it only took " + count + " tries!");
                    totalpayout = totalpayout + 50000;
                    Console.WriteLine("The Casino has been paid: " + (count * 5) + " Dollars for you to win " + totalpayout + " and has profited: " + (count * 5 - totalpayout));
                }
                else
                {
                   
                    if (v1 > 6)
                    {
                        payout = 50;
                    }
                    else if (v1 > 3 && v2 < 5)
                    {
                        payout = 5;
                        
                    }
                    else if (v1 > 1 || v2 < 3)
                    {
                        payout = 0;
                    }
                    else
                    {
                        payout = 0;
                    }
                    totalpayout = totalpayout + payout;
                    Console.WriteLine("You got: " + slot1 + slot2 + slot3 + " and won " + (payout + 50));
                    count++;
                }
            }
            string c = Console.ReadLine();

        }


        static void asciiArt()
        {

        }

        static string randSlot1()
        {
            string rand = randSeed();
            int R = Convert.ToInt32(rand);
            int l = r.Next(s1.Length);
            char c = v[l];
            if (c.ToString() == "7" && R > 5)
            {
                Console.WriteLine(c);
                return c.ToString();
            }
            else
            {
                while (c.ToString() == "7")
                {
                    l = r.Next(s1.Length);
                    c = v[l];
                }
                Console.WriteLine(c);
                return c.ToString();
            }
        }

        static string randSlot2()
        {
            string rand = randSeed();
            int R = Convert.ToInt32(rand);
            int l = r.Next(s1.Length);
            char c = v[l];
            if (c.ToString() == "7" && R > 5)
            {
                Console.WriteLine(c);
                return c.ToString();
            }
            else
            {
                while (c.ToString() == "7")
                {
                    l = r.Next(s1.Length);
                    c = v[l];
                }
                Console.WriteLine(c);
                return c.ToString();
            }
        }

        static string randSlot3()
        {
            string rand = randSeed();
            int R = Convert.ToInt32(rand);
            int l = r.Next(s1.Length);
            char c = v[l];
            if (c.ToString() == "7" && R > 5)
            {
                Console.WriteLine(c);
                return c.ToString();
            }
            else
            {
                while (c.ToString() == "7")
                {
                    l = r.Next(s1.Length);
                    c = v[l];
                }
                Console.WriteLine(c);
                return c.ToString();
            }
        }

        static string randSeed()
        {
            int l = r.Next(7);
            return l.ToString();
        }
    }
}