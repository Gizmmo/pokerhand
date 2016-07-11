using System;
using PokerHand.Hand;

namespace PokerHand.Player
{
    public class Player : IPlayer
    {

        public string Name { get; }

        public IHand CurrentHand { get; }

        /// <summary>
        /// Constructor for player class
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <param name="cards">A string for the cards in the format of 10C, JD, 2S, etc.</param>
        public Player(string name, string[] cards)
        {
            Name = name;
            CurrentHand = new Hand.Hand();
            Array.ForEach(cards, card => CurrentHand.AddCard(new Card.Card(card)));
        }

        /// <summary>
        /// Compares two players hands, and returns which hand is bigger.
        /// </summary>
        /// <param name="otherPlayer">The other player to compare hands with</param>
        /// <returns>Negative if this players hand is less value, positve if more, and 0 if the same</returns>
        public int CompareTo(Player otherPlayer) => CurrentHand.CompareTo(otherPlayer.CurrentHand);
    }
}