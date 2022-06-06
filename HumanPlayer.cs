using System;

namespace ShootingDice
{
    // TODO: Complete this class

    // A player the prompts the user to enter a number for a roll
    public class HumanPlayer : Player
    {
        public override void Play(Player other)
        {
            // Call roll for "this" object and for the "other" object
            Console.WriteLine("Please enter a roll value: ");
            int myRoll = int.Parse(Console.ReadLine());
            int otherRoll = 0;
            if(other.GetType() == typeof(OneHigherPlayer))
            {
                
                otherRoll = myRoll +1;
            }
            else
            {
                
                otherRoll = other.Roll();
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