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

        public bool IsSameSuit(Card secondCard)
        {
            return secondCard.Suit == Suit;
        }

        public bool IsSameColor(Card secondCard)
        {
            //If this card has hearts or diamonds as a suit...
            if (Suit == CardSuit.Hearts || Suit == CardSuit.Diamonds)
                //... if the second card does as well, reutrn true, otherwise false.
                return secondCard.Suit == CardSuit.Hearts || secondCard.Suit == CardSuit.Diamonds;

            //If this card is not diamonds or hearts, it is spades or clubs, so check the other card for the same.
            return secondCard.Suit == CardSuit.Spades || secondCard.Suit == CardSuit.Clubs;
        }

        public bool IsOneGreater(Card cardTwo)
        {
            //Get the int values of the enums, and check if the second is the first+1.
            return (int) Rank + 1 == (int) cardTwo.Rank;
        }
    }

    public class IllegalRankException : Exception
    {
    }

    public class IllegalSuitException : Exception
    {
    }
}