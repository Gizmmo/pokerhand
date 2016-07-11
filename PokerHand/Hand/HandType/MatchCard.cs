using System.Collections.Generic;
using System.Linq;
using PokerHand.Card;

namespace PokerHand.Hand.HandType
{
    public abstract class MatchCard : RankCard
    {
        private const int TotalCards = 5;

        public CardRank MatchingCardRank { get; private set; }


        protected MatchCard(List<ICard> cards, int amountOfCardMatchesNeeded) : base(cards)
        {
            if (FindMatch(cards, amountOfCardMatchesNeeded))
            {
                IsValid = true;
            }
        }

        protected bool FindMatch(List<ICard> cards, int amountOfMatchesNeeded)
        {
            foreach (var card in cards)
            {
                var matches = 1; //1 since the first counts as 1.
                foreach (var cardToCompare in cards.Where(cardToCompare => card != cardToCompare))
                {
                    if (card.Rank == cardToCompare.Rank)
                        matches++;

                    if (matches == amountOfMatchesNeeded)
                    {
                        MatchingCardRank = card.Rank;
                        return true;
                    }
                }
            }

            return false;
        }

        public int CompareTo(MatchCard otherPair)
        {
            var basePairCheck = GetMatchingCardRankCompare(otherPair);

            return basePairCheck == 0 ? CompareCardRanks(otherPair.CardRanks) : basePairCheck;
        }

        private int GetMatchingCardRankCompare(MatchCard otherPair) => MatchingCardRank - otherPair.MatchingCardRank;
    }
}