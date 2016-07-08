namespace PokerHand.Card
{
    public enum CardSuit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum CardRank
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public interface ICard
    {
        CardRank Rank { get; }
        CardSuit Suit { get; }
    }
}