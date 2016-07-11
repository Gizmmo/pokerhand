using System.Collections.Generic;
using PokerHand.Card;

namespace PokerHand.Hand.HandType
{
    public class HighestCard : RankCard
    {
        public HighestCard(List<ICard> cards) : base(cards)
        {
            IsValid = true;
        }

        public int CompareTo(HighestCard other) => CompareCardRanks(other.CardRanks);
    }
}