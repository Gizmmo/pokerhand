using System.Collections.Generic;
using PokerHand.Card;

namespace PokerHand.Hand.HandType
{
    public class ThreeOfAKind : MatchCard
    {
        #region Constant Attributes

        //The amount of cards needed to be a three of a kind (i.e. 3)
        private const int AmountOfCardMatchesNeeded = 3;

        #endregion

        #region Constructors

        /// <summary>
        /// Three of a kind constructor
        /// </summary>
        /// <param name="cards">The cards for this hand</param>
        public ThreeOfAKind(List<ICard> cards) : base(cards, AmountOfCardMatchesNeeded)
        {
        }

        #endregion
    }
}