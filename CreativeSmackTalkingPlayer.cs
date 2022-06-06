using System;
using System.Collections.Generic;

namespace ShootingDice
{
    // A SmackTalkingPlayer who randomly selects a taunt from a list to say to the other player
    public class CreativeSmackTalkingPlayer : Player
    {
        public static List<string> _tauntList = new List<string>{
            "HAHAH!",
            "You lose!",
            "My mom plays better"
        };

        public static string RandomTaunt(){
            int randomNumber = new Random().Next(_tauntList.Count);
            return _tauntList[randomNumber];
        }

        public string SelectedTaunt 
        {
            get {
                return RandomTaunt();
            }
        }

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
            Console.WriteLine(SelectedTaunt);
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