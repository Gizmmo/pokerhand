using System.Collections.Generic;
using PokerHand.Card;

namespace PokerHand.Hand.HandType
{
    public class OnePair : MatchCard
    {
        private const int AmountOfCardMatchesNeeded = 2;

        public OnePair(List<ICard> cards) : base(cards, AmountOfCardMatchesNeeded)
        {
        }
    }
}