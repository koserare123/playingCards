using System;
using System.Linq;

namespace PlayingCards
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialOption;
            string playOption = "1";
            string[] shuffledCards;
            int cardCount = 0;
            //Initializing the playing cards
            // CX - Club Cards
            // HX - Heart Cards
            // DX - Diamond Cards
            // SX - Spade Cards
            string[] playCards = {"CA","C2","C3","C4","C5","C6","C7","C8","C9","C10","CJ","CQ","CK",
                                  "HA","H2","H3","H4","H5","H6","H7","H8","H9","H10","HJ","HQ","HK",
                                  "DA","D2","D3","D4","D5","D6","D7","D8","D9","D10","DJ","DQ","DK",
                                  "SA","S2","S3","S4","S5","S6","S7","S8","S9","S10","SJ","SQ","SK" };
            Console.WriteLine("Welcome to Cards Game....!!!!!!");
            Console.WriteLine("Press any key to start the game or 4 to exit....!!!!!!");
            initialOption = Console.ReadLine();
            //Shuffle the initial set of cards
            Console.WriteLine("Shuffling the cards...............");
            Console.WriteLine("..................................");
            Random rnd = new Random();
            shuffledCards = playCards.OrderBy(x => rnd.Next()).ToArray();
            //reshuffledCards = shuffledCards;
            Console.WriteLine("Shuffling completed");
            while (playOption != "4")
            {
                Console.WriteLine("Choose any of the below option:::");
                Console.WriteLine("1. Play a Card ");
                Console.WriteLine("2. Shuffle the Deck ");
                Console.WriteLine("3. Restart the Game ");
                Console.WriteLine("4. Exit the Game ");
                playOption = Console.ReadLine();
                if (playOption == "1")
                {

                    Console.WriteLine("Here is your " + Convert.ToString(cardCount + 1) + " card ");
                    Console.WriteLine(shuffledCards[cardCount]);
                    int lastCardNumber = shuffledCards.Length;
                    for (int i = 0; i < shuffledCards.Length - 1; i++)
                    {
                        if (shuffledCards[i] != "DD")
                        {
                            shuffledCards[i] = shuffledCards[i + 1];
                            lastCardNumber = i;
                        }

                    }
                    shuffledCards[lastCardNumber - 1] = "DD";
                    cardCount = cardCount + 1;
                }
                if (playOption == "2")
                {
                    //Code for reshuffling the remaining cards
                    //Reamining cards are stored in a separate array
                    string[] reshuffledCards = shuffledCards.Take(shuffledCards.Length - cardCount).Select(i => i.ToString()).ToArray();
                    Console.WriteLine("Shuffling the remaining " + Convert.ToString(shuffledCards.Length - cardCount) + " cards.......");
                    Console.WriteLine("....................................");
                    Console.WriteLine("Remaining " + Convert.ToString(reshuffledCards.Length) + " shuffle completed");
                    //Cards are shuffled and the original array is overwritten
                    Random rnd1 = new Random(); 
                    shuffledCards = reshuffledCards.OrderBy(x => rnd1.Next()).ToArray(); ;
                }
                if (playOption == "3")
                {
                    Console.WriteLine("Restarting the Game.......");
                    Console.WriteLine("...........................");
                    cardCount = 0;
                    Random rnd2 = new Random();
                    shuffledCards = playCards.OrderBy(x => rnd2.Next()).ToArray();
                    Console.WriteLine("Shuffling Completed");
                }
                else
                {
                    Console.WriteLine("Please enter a valid option ");
                }
            }
        }
    }
}
