using System;
using System.Collections.Generic;
using PokerHand.Card;
using PokerHand.Hand.HandType;

namespace PokerHand.Hand
{
    public class Hand : IHand
    {
        //The cards added to this hand.
        private readonly List<ICard> _cards = new List<ICard>();

        /// <summary>
        /// The hand type of this hand (i.e. flush, three of a kind, one pair, high value).
        /// </summary>
        public IHandType HandType { get; private set; }

        /// <summary>
        /// The amount of cards added to this hand
        /// </summary>
        public int Count => _cards.Count;

        /// <summary>
        /// Adds a card to the hand of this player
        /// </summary>
        /// <param name="card">The card to add to this hand</param>
        public void AddCard(ICard card)
        {
            _cards.Add(card);
            if (Count == 5)
                HandType = GetHandType();
        }

        /// <summary>
        /// Finds the Hand type this hand has.
        /// </summary>
        /// <returns></returns>
        private IHandType GetHandType()
        {
            var flush = new Flush(_cards);

            //Can the cards handed can make a flush
            if (flush.IsValid)
                return flush;

            var three = new ThreeOfAKind(_cards);

            //Can the cards added can make a three of a kind
            if (three.IsValid)
                return three;

            var pair = new OnePair(_cards);

            //Can the cards added make a one pair
            if (pair.IsValid)
                return pair;

            //if none else, get the highest card type.
            return new HighestCard(_cards);
        }

        /// <summary>
        /// Compares two hands and returns numerically if this hand is more value, higher numbers
        /// meaning this hand is of higher value
        /// </summary>
        /// <param name="otherHand">The other hand to compare this hand too</param>
        /// <returns>Negitive number if this hand is of lower value, positive if higher, and 0 if same</returns>
        public int CompareTo(IHand otherHand)
        {
            return HandType.GetType() != otherHand.HandType.GetType()
                ? FindBetterDifferentHandType(otherHand.HandType)
                : FindBetterSameHandType(otherHand.HandType);
        }

        /// <summary>
        /// Finds the better hand if they both share a type.
        /// </summary>
        /// <param name="otherHandType">The other hand to compare too.</param>
        /// <returns>Negative if this hand is less value, positive if its more value, and 0 if same.</returns>
        private int FindBetterSameHandType(IHandType otherHandType)
        {
            var getType = HandType.GetType();

            if (getType == typeof(Flush))
                return ((Flush) HandType).CompareTo((Flush) otherHandType);

            if (getType == typeof(ThreeOfAKind))
                return ((ThreeOfAKind) HandType).CompareTo((ThreeOfAKind) otherHandType);

            if (getType == typeof(OnePair))
                return ((OnePair) HandType).CompareTo((OnePair) otherHandType);

            return ((HighestCard) HandType).CompareTo((HighestCard) otherHandType);
        }

        /// <summary>
        /// Finds the better different hand type of the two.
        /// </summary>
        /// <param name="otherHandType">The other hand type to compare with.</param>
        /// <returns>Negative if this hand is of less value, positive if more, 0 otherwise.</returns>
        private int FindBetterDifferentHandType(IHandType otherHandType)
        {
            var thisObjecRank = GetHandTypeNumberRank(HandType.GetType());
            var otherObjectRank = GetHandTypeNumberRank(otherHandType.GetType());

            return thisObjecRank - otherObjectRank;
        }

        /// <summary>
        /// Gets a numeric rank for the handtypes to compares which hand is better.
        /// </summary>
        /// <param name="getType">The type to rank</param>
        /// <returns>A numeric value for the handtype, higher being more value.</returns>
        private int GetHandTypeNumberRank(Type getType)
        {
            if (getType == typeof(Flush))
                return 3;
            if (getType == typeof(ThreeOfAKind))
                return 2;
            if (getType == typeof(OnePair))
                return 1;

            return 0;
        }
    }
}