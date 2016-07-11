using System;
using System.Collections.Generic;
using PokerHand.Card;

namespace PokerHand.Hand.HandType
{
    public abstract class RankCard : IHandType
    {
        public bool IsValid { get; protected set; }
        private const int TotalCards = 5;
        public CardRank[] CardRanks { get; protected set; }

        protected RankCard(List<ICard> cards)
        {
            CardRanks = new CardRank[TotalCards];
            AddRanks(cards);
        }

        protected int CompareCardRanks(CardRank[] otherHandCardRanks)
        {
            for (var i = CardRanks.Length - 1; i >= 0; i--)
            {
                var compareValue = CardRanks[i] - otherHandCardRanks[i];

                if (compareValue != 0)
                    return compareValue;
            }

            Console.WriteLine(CardRanks.Length);

            return 0;
        }

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