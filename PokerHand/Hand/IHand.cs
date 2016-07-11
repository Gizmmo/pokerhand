using PokerHand.Card;
using PokerHand.Hand.HandType;

namespace PokerHand.Hand
{

    public interface IHand
    {
        int CompareTo(IHand otherHand);
        int Count { get; }
        void AddCard(ICard card);
        IHandType HandType { get; }
    }
}