using System.Collections.Generic;
using System.Linq;
using PokerHand.Card;

namespace PokerHand.Hand
{
    public class Hand : IHand
    {
        private readonly List<ICard> _cards = new List<ICard>();

        public int Count => _cards.Count;

        public void AddCard(ICard card)
        {
            _cards.Add(card);
            if (_cards.Count == 5)
                ScoreHand();
        }

        public PokerType CurrentHandType { get; private set; } = PokerType.None;

        public int CompareTo(IHand otherHand)
        {
            throw new System.NotImplementedException();
        }

        private void ScoreHand()
        {
            if (CheckForFlush())
            {
                CurrentHandType = PokerType.Flush;
                return;
            }

            if (CheckForThreeOfAKind())
            {
                CurrentHandType = PokerType.ThreeOfAKind;
                return;
            }

            if (CheckForOnePair())
            {
                CurrentHandType = PokerType.OnePair;
                return;
            }

            CurrentHandType = PokerType.HighCard;
        }


        private bool CheckForOnePair() => IsMatchesFound(2);

        private bool CheckForThreeOfAKind() => IsMatchesFound(3);

        private bool CheckForFlush() => _cards.All(card => card.Suit == _cards[0].Suit);

        private bool IsMatchesFound(int amountOfMatchesNeeded)
        {
            foreach (var card in _cards)
            {
                var matches = 0;
                foreach (var cardToCompare in _cards.Where(cardToCompare => card != cardToCompare))
                {
                    if (card.Rank == cardToCompare.Rank)
                        matches++;

                    if (matches == amountOfMatchesNeeded)
                        return true;
                }
            }

            return false;
        }
    }
}