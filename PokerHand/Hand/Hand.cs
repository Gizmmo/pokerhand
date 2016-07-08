using System.Collections.Generic;
using PokerHand.Card;

namespace PokerHand.Hand
{
    public class Hand : IHand
    {
        private List<ICard> _cards = new List<ICard>();

        public HandType CurrentHand { get; private set; }
        public int Count { get { return _cards.Count; } }

        public void AddCard(ICard card)
        {
            _cards.Add(card);
            if (_cards.Count == 5)
                ScoreHand();
        }

        private void ScoreHand()
        {
            if (CheckForFlush())
                return;

            if (CheckForThreeOfAKind())
                return;
            
            if (CheckForOnePair())
                return;

            CheckForHighCard();
        }

        private void CheckForHighCard()
        {
            throw new System.NotImplementedException();
        }

        private bool CheckForOnePair()
        {
            throw new System.NotImplementedException();
        }

        private bool CheckForThreeOfAKind()
        {
            throw new System.NotImplementedException();
        }

        private bool CheckForFlush()
        {
            throw new System.NotImplementedException();
        }
    }
}