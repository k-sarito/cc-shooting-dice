using System;

namespace ShootingDice
{
    // TODO: Complete this class

    // Override the Play method to make a Player who always roles one higher than the other player
    public class OneHigherPlayer : Player
    {
        public override void Play(Player other)
        {
            // Call roll for "this" object and for the "other" object
            int otherRoll = 0;
            int myRoll = 0;
            if(other.GetType() == typeof(HumanPlayer))
            {
                
                Console.WriteLine("Please enter a roll value: ");
                otherRoll = int.Parse(Console.ReadLine());
                myRoll = otherRoll + 1;

            }
            else
            {
                otherRoll = other.Roll();
                myRoll = otherRoll + 1;
            }



            Console.WriteLine($"{Name} rolls a {myRoll}");
            Console.WriteLine($"{other.Name} rolls a {otherRoll}");
            if(other.GetType() == typeof(SmackTalkingPlayer))
            {
                Console.WriteLine($"{((SmackTalkingPlayer)other).Taunt}");
            }
            else if(other.GetType() == typeof(CreativeSmackTalkingPlayer))
            {
                
                Console.WriteLine((other as CreativeSmackTalkingPlayer).SelectedTaunt);
            }
            if (myRoll > otherRoll)
            {
                Console.WriteLine($"{Name} Wins!");
            }
            else if (myRoll < otherRoll)
            {
                Console.WriteLine($"{other.Name} Wins!");
            }
            else
            {
                // if the rolls are equal it's a tie
                Console.WriteLine("It's a tie");
            }
        }
    }
}
