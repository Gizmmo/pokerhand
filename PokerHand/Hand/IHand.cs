using PokerHand.Card;

namespace PokerHand.Hand
{
    public enum HandType
    {
        HighCard,
        OnePair,
        ThreeOfAKind,
        Flush
    }

    public interface IHand
    {
        HandType CurrentHand { get; }
        int Count { get; }
        void AddCard(ICard card);
    }
}