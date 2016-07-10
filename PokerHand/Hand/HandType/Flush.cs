using System.Collections.Generic;
using System.Linq;
using PokerHand.Card;

namespace PokerHand.Hand.HandType
{
    public class Flush : IHandType
    {
        private readonly CardRank[] _ranks = new CardRank[5];

        public bool CheckForType(List<ICard> cards)
        {
            var found = CheckSuit(cards);
            if (found)
                AddRanks(cards);
            return found;
        }

        private void AddRanks(List<ICard> cards)
        {
            var i = 0;
//            cards.ForEach(card => _ranks[i++] = card.Rank );
            foreach (var card in cards)
            {
                _ranks[i] = card.Rank;
                i++;
            }
        }

        private bool CheckSuit(List<ICard> cards)
        {
            var suit = cards[0].Suit;
            return cards.All(card => card.Suit == suit);
        }

        private CardRank GetHighestRank(List<ICard> cards)
        {
            var topCard = cards[0];
            foreach (var card in cards)
            {
                if (topCard.Rank < card.Rank)
                    topCard = card;
            }
            return topCard.Rank;
        }

        public int CompareTo(IHandType other)
            => other.GetType() != typeof(Flush) ? 0 : FindHigherValueHand((Flush) other);

        private int FindHigherValueHand(Flush other)
        {
        }

        public bool IsValid(List<ICard> cards)
        {
            throw new System.NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}