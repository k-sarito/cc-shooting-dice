using System;


namespace ShootingDice
{
    public class Player
    {
        public string Name { get; set; }
        public int DiceSize { get; set; } = 6;

        public virtual int Roll()
        {
            // Return a random number between 1 and DiceSize
            return new Random().Next(DiceSize) + 1;
        }

        public virtual void Play(Player other)
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