using System.Collections.Generic;
using PokerHand.Card;

namespace PokerHand.Hand.HandType
{
    public class OnePair : MatchCard
    {
        #region Const Attributes

        //The amount of matches needed for a OnePair.
        private const int AmountOfCardMatchesNeeded = 2;

        #endregion

        #region Constructors

        /// <summary>
        /// One pair constructor.
        /// </summary>
        /// <param name="cards">The list of cards for this hand type.</param>
        public OnePair(List<ICard> cards) : base(cards, AmountOfCardMatchesNeeded)
        {
        }

        #endregion
    }
}