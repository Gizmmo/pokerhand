using System.Collections.Generic;
using System.Linq;
using PokerHand.Card;

namespace PokerHand.Hand.HandType
{
    /// <summary>
    /// Used for any handtypes that require 2 or more of the same rank to score.  In this example, that will be OnePair and ThreeOfAKind.
    /// </summary>
    public abstract class MatchCard : RankCard
    {
        #region Properties

        /// <summary>
        /// The rank of the matching cards.  Used for comparison before other cards.
        /// </summary>
        public CardRank MatchingCardRank { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cards">The list of cards for this hand</param>
        /// <param name="amountOfCardMatchesNeeded">The amount of cards need to make a succeful match.  Ex. One Pair would require 2 of the same card.</param>
        protected MatchCard(List<ICard> cards, int amountOfCardMatchesNeeded) : base(cards)
        {
            if (FindMatch(cards, amountOfCardMatchesNeeded))
                IsValid = true;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Compares this MatchCard type to another and finds the if this one is of higher or lower value.
        /// </summary>
        /// <param name="otherMatch">The other Match card to compare against.</param>
        /// <returns>Negative if this Match is of less value, positive if higher, and 0 if they are the same.</returns>
        public int CompareTo(MatchCard otherMatch)
        {
            var basePairCheck = GetMatchingCardRankCompare(otherMatch);

            return basePairCheck == 0 ? CompareCardRanks(otherMatch.CardRanks) : basePairCheck;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Checks to see if it can find a match of the same cards.
        /// </summary>
        /// <param name="cards">The cards to check for a rank match.</param>
        /// <param name="amountOfMatchesNeeded">The amount of matches needed to meet the criteria of the match. (2 for pair, 3 for three of a kind)</param>
        /// <returns>true if the amount of matches were found of a single card rank.</returns>
        protected bool FindMatch(List<ICard> cards, int amountOfMatchesNeeded)
        {
            foreach (var card in cards)
            {
                var matches = 1; //1 since the first counts as 1.

                // For every card in the cards list that isn't itself...
                foreach (var cardToCompare in cards.Where(cardToCompare => card != cardToCompare))
                {
                    // If the rank matches another card
                    if (card.Rank == cardToCompare.Rank)
                        // ...We increase matches by 1.
                        matches++;

                    // If the amount of matches need was reached...
                    if (matches == amountOfMatchesNeeded)
                    {
                        // ...Store the card rank...
                        MatchingCardRank = card.Rank;

                        // ...And return true to show a rank was found the needed amount of times.
                        return true;
                    }
                }
            }

            //Not enough matches were found, thus we do not have enough to be true.
            return false;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Checks to see if the matching pair on this object is higher.  This will find out whose matching
        /// card rank is higher.  ex(1 vs 3 is -2 meaning this match card is 2 less then the other).
        /// </summary>
        /// <param name="otherPair">the other card to compare against.</param>
        /// <returns>Negative if this card is less value, positive if more, and 0 if the same.</returns>
        private int GetMatchingCardRankCompare(MatchCard otherPair) => MatchingCardRank - otherPair.MatchingCardRank;

        #endregion
    }
}