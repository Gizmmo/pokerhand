using System;

namespace PokerHand.Card
{
    public class Card : ICard
    {
        public Card(string cardValue)
        {
            Rank = ParseRank(cardValue.Substring(0, cardValue.Length - 1));
            Suit = ParseSuit(cardValue[cardValue.Length - 1]);
        }

        public CardSuit Suit { get; }

        public CardRank Rank { get; }

        private CardRank ParseRank(string rank)
        {
            switch (rank)
            {
                case "A":
                    return CardRank.Ace;
                case "2":
                    return CardRank.Two;
                case "3":
                    return CardRank.Three;
                case "4":
                    return CardRank.Four;
                case "5":
                    return CardRank.Five;
                case "6":
                    return CardRank.Six;
                case "7":
                    return CardRank.Seven;
                case "8":
                    return CardRank.Eight;
                case "9":
                    return CardRank.Nine;
                case "10":
                    return CardRank.Ten;
                case "J":
                    return CardRank.Jack;
                case "Q":
                    return CardRank.Queen;
                case "K":
                    return CardRank.King;
            }

            throw new IllegalRankException();
        }

        private CardSuit ParseSuit(char suit)
        {
            switch (suit)
            {
                case 'C':
                    return CardSuit.Clubs;
                case 'D':
                    return CardSuit.Diamonds;
                case 'H':
                    return CardSuit.Hearts;
                case 'S':
                    return CardSuit.Spades;
            }
            throw new IllegalSuitException();
        }
    }

    public class IllegalRankException : Exception
    {
    }

    public class IllegalSuitException : Exception
    {
    }
}