using System;
using System.Collections.Generic;
using PokerHand.Card;

namespace PokerHand.Hand.HandType
{
    /// <summary>
    /// Used for all HandType classes in this project, this class has some basic comparison methods used by all handtypes.
    /// </summary>
    public abstract class RankCard : IHandType
    {
        private const int TotalCards = 5;

        public bool IsValid { get; protected set; }

        /// <summary>
        /// All the card ranks of the cards passed.  Used to compare who has the highest calue cards based purely on rank.
        /// </summary>
        public CardRank[] CardRanks { get; protected set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cards">The cards to get the rank of.</param>
        protected RankCard(List<ICard> cards)
        {
            CardRanks = new CardRank[TotalCards];
            AddRanks(cards);
        }

        /// <summary>
        /// Compres two card rank and returns a value of if this object has a higher card rank then another object.
        /// </summary>
        /// <param name="otherHandCardRanks">The other card ranks to compare against.</param>
        /// <returns>Positive if this rankcard has a higher ranking top card, negative if not, and 0 if they are the same.</returns>
        protected int CompareCardRanks(CardRank[] otherHandCardRanks)
        {
            for (var i = CardRanks.Length - 1; i >= 0; i--)
            {
                var compareValue = CardRanks[i] - otherHandCardRanks[i];

                if (compareValue != 0)
                    return compareValue;
            }
            return 0;
        }

        /// <summary>
        /// Adds all the cards passed into the CardRanks array for ranking later
        /// </summary>
        /// <param name="cards">The cards to add to the CardRanks array.</param>
        protected void AddRanks(IEnumerable<ICard> cards)
        {
            var i = 0;
            foreach (var card in cards)
            {
                CardRanks[i] = card.Rank;
                i++;
            }

            Array.Sort(CardRanks);
        }
    }
}