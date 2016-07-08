namespace PokerHand.Card
{
    public class Card
    {
        public Card(string cardValue)
        {
            
        }

        public enum CardSuit
        {
            Hearts,
            Diamonds,
            Clubs,
            Spades
        }

        public enum CardRank
        {
            One,
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
            King,
            Ace
        }

        public CardSuit Suit { get; private set; }

        public CardRank Rank { get; private set; }

        private void ParseRank(string rank)
        {
            switch (rank)
            {
                case "1":
                    Rank = CardRank.One;
                    break;
                case "2":
                    Rank = CardRank.Two;
                    break;
                case "3":
                    Rank = CardRank.Three;
                    break;
                case "4":
                    Rank = CardRank.Four;
                    break;
                case "5":
                    Rank = CardRank.Five;
                    break;
                case "6":
                    Rank = CardRank.Six;
                    break;
                case "7":
                    Rank = CardRank.Seven;
                    break;
                case "8":
                    Rank = CardRank.Eight;
                    break;
                case "9":
                    Rank = CardRank.Nine;
                    break;
                case "10":
                    Rank = CardRank.Ten;
                    break;
                case "J":
                    Rank = CardRank.Jack;
                    break;
                case "Q":
                    Rank = CardRank.Queen;
                    break;
                case "K":
                    Rank = CardRank.King;
                    break;
                case "A":
                    Rank = CardRank.Ace;
                    break;
            }
        }

        private void ParseSuit(string suit)
        {
            switch (suit)
            {
                case "C":
                    Suit = CardSuit.Clubs;
                    break;
                case "D":
                    Suit = CardSuit.Diamonds;
                    break;
                case "H":
                    Suit = CardSuit.Hearts;
                    break;
                case "S":
                    Suit = CardSuit.Spades;
                    break;
            }
        }
    }
}