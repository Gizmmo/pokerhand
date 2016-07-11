using System;
using System.Collections.Generic;
using System.Linq;
using PokerHand.Card;

namespace PokerHand.Hand.HandType
{
    public class Flush : RankCard
    {
        public Flush(List<ICard> cards) : base(cards)
        {
            if (IsAllSuitsMatching(cards))
            {
                IsValid = true;
            }
        }

        private bool IsAllSuitsMatching(List<ICard> cards) => cards.All(card => card.Suit == cards[0].Suit);


        public int CompareTo(Flush other) => CompareCardRanks(other.CardRanks);
    }
}