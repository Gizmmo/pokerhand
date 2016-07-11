using System.Collections.Generic;
using System.Linq;
using PokerHand.Card;

namespace PokerHand.Hand.HandType
{
    public class Flush : RankCard
    {
        #region Constructors

        /// <summary>
        /// Flush constructor
        /// </summary>
        /// <param name="cards">A list of cards to use to check for a flush.</param>
        public Flush(List<ICard> cards) : base(cards)
        {
            if (IsAllSuitsMatching(cards))
                IsValid = true;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Compares this flush object with another passed, and returns an int of if it
        /// is of higher value.
        /// </summary>
        /// <param name="other">the other flush object to compare against</param>
        /// <returns>Negative if this flush is of less value, postive if greater, and 0 if the same.</returns>
        public int CompareTo(Flush other) => CompareCardRanks(other.CardRanks);

        #endregion

        #region Private Methods

        /// <summary>
        /// Checks to see if all the suits of the cards are of the same type.
        /// </summary>
        /// <param name="cards">The cards to check the suits of.</param>
        /// <returns>true if all suits match, false otherwise.</returns>
        private bool IsAllSuitsMatching(List<ICard> cards) => cards.All(card => card.Suit == cards[0].Suit);

        #endregion
    }
}