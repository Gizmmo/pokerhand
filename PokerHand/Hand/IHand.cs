using PokerHand.Card;

namespace PokerHand.Hand
{
    public enum PokerType
    {
        None,
        Flush,
        ThreeOfAKind,
        OnePair,
        HighCard
        
    }

    public interface IHand
    {
        PokerType CurrentHandType { get; }
        int CompareTo(IHand otherHand);
        int Count { get; }
        void AddCard(ICard card);
    }
}