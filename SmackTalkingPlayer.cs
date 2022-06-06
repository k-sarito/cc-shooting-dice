using System;
using System.Collections.Generic;


namespace ShootingDice
{
    // TODO: Complete this class

    // A Player who shouts a taunt every time they roll dice
    public class SmackTalkingPlayer : Player
    {
        public string Taunt { get; } = "U suck";
        
        public override void Play(Player other)
        {
            // Call roll for "this" object and for the "other" object
            int myRoll = 0;
            int otherRoll = 0;
            if(other.GetType() == typeof(OneHigherPlayer))
            {
                myRoll = Roll();
                otherRoll = myRoll +1;
            }
            else if (other.GetType() == typeof(HumanPlayer))
            {
                myRoll = Roll();
                Console.WriteLine("Please enter a roll value: ");
                otherRoll = int.Parse(Console.ReadLine());

            }
            else
            {
                myRoll = Roll();
                otherRoll = other.Roll();
            }

            Console.WriteLine($"{Name} rolls a {myRoll}");
            Console.WriteLine(Taunt);
            Console.WriteLine($"{other.Name} rolls a {otherRoll}");
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