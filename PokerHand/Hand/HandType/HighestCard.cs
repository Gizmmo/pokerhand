using System.Collections.Generic;
using PokerHand.Card;

namespace PokerHand.Hand.HandType
{
    public class HighestCard : RankCard
    {
        #region Constructors

        /// <summary>
        /// Highest card constructor
        /// </summary>
        /// <param name="cards">A list of cards</param>
        public HighestCard(List<ICard> cards) : base(cards)
        {
            IsValid = true;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Compares this highest card object to another past, and returns the value of the comparison.
        /// </summary>
        /// <param name="other">The other object to check.</param>
        /// <returns>Negative if this object is of less value, positive if more, and zero if the same.</returns>
        public int CompareTo(HighestCard other) => CompareCardRanks(other.CardRanks);

        #endregion
    }
}