using System;
using System.Collections.Generic;
using PokerHand.Card;
using PokerHand.Hand.HandType;

namespace PokerHand.Hand
{
    public class Hand : IHand
    {
        #region Private Attributes

        //The cards added to this hand.
        private readonly List<ICard> _cards = new List<ICard>();

        #endregion

        #region Properties

        /// <summary>
        /// The hand type of this hand (i.e. flush, three of a kind, one pair, high value).
        /// </summary>
        public IHandType HandType { get; private set; }

        /// <summary>
        /// The amount of cards added to this hand
        /// </summary>
        public int Count => _cards.Count;

        #endregion

        #region Public Methods

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
        /// Compares two hands and returns numerically if this hand is more value, higher numbers
        /// meaning this hand is of higher value
        /// </summary>
        /// <param name="otherHand">The other hand to compare this hand too</param>
        /// <returns>Negitive number if this hand is of lower value, positive if higher, and 0 if same</returns>
        public int CompareTo(IHand otherHand)
        {
            //If the types dont match, get the scores for different hand types, if they do, score them against each other.
            return HandType.GetType() != otherHand.HandType.GetType()
                ? FindBetterDifferentHandType(otherHand.HandType)
                : FindBetterSameHandType(otherHand.HandType);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Finds the Hand type this hand has.
        /// </summary>
        /// <returns></returns>
        private IHandType GetHandType()
        {
            var flush = new Flush(_cards);

            //Can the cards handed successfully make a flush
            if (flush.IsValid)
                return flush;

            var three = new ThreeOfAKind(_cards);

            //Can the cards added successfully make a three of a kind
            if (three.IsValid)
                return three;

            var pair = new OnePair(_cards);

            //Can the cards added successfully make a one pair
            if (pair.IsValid)
                return pair;

            //If none else, get the highest card type.
            return new HighestCard(_cards);
        }


        /// <summary>
        /// Finds the better hand if they both share a type.
        /// </summary>
        /// <param name="otherHandType">The other hand to compare too.</param>
        /// <returns>Negative if this hand is less value, positive if its more value, and 0 if same.</returns>
        private int FindBetterSameHandType(IHandType otherHandType)
        {
            var getType = HandType.GetType();

            //If type is flush, cast both objects and compare.
            if (getType == typeof (Flush))
                return ((Flush) HandType).CompareTo((Flush) otherHandType);

            //If type is a ThreeOfAKind, cast both objects and compare.
            if (getType == typeof (ThreeOfAKind))
                return ((ThreeOfAKind) HandType).CompareTo((ThreeOfAKind) otherHandType);

            //If type is a OnePair, cast both objects and compare.
            if (getType == typeof (OnePair))
                return ((OnePair) HandType).CompareTo((OnePair) otherHandType);

            //If none of the others, simply cast both objects as HighCard and compare.
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
            if (getType == typeof (Flush))
                return 3;
            if (getType == typeof (ThreeOfAKind))
                return 2;
            if (getType == typeof (OnePair))
                return 1;

            return 0;
        }

        #endregion
    }
}