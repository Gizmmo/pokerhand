using System.Collections.Generic;
using PokerHand.Card;

namespace PokerHand.Hand.HandType
{
    public class ThreeOfAKind : MatchCard
    {
        private const int AmountOfCardMatchesNeeded = 3;

        public ThreeOfAKind(List<ICard> cards) : base(cards, AmountOfCardMatchesNeeded)
        {
        }
    }
}