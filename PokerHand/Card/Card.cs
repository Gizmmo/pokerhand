using System;

namespace PokerHand.Card
{
    public class Card : ICard
    {
        #region Constructors

        /// <summary>
        /// The Card constructor
        /// </summary>
        /// <param name="cardValue">A string card value to parse into an object.</param>
        public Card(string cardValue)
        {
            Rank = ParseRank(cardValue.Substring(0, cardValue.Length - 1));
            Suit = ParseSuit(cardValue[cardValue.Length - 1]);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The suit of the card
        /// </summary>
        public CardSuit Suit { get; }

        /// <summary>
        /// The rank of the card
        /// </summary>
        public CardRank Rank { get; }

        #endregion

        #region Private Methods

        /// <summary>
        /// Parses the rank of the card from a string passed
        /// </summary>
        /// <param name="rank">The string to parse the rank from</param>
        /// <returns>The enum CardRank of the passed string.</returns>
        private CardRank ParseRank(string rank)
        {
            rank = rank.ToUpper();
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

        /// <summary>
        /// Parses the suit from the passed character.
        /// </summary>
        /// <param name="suit">the character to parse the suit from</param>
        /// <returns>the CardSuit enum parsed from the character.</returns>
        private CardSuit ParseSuit(char suit)
        {
            suit = Char.ToUpper(suit);
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

    #endregion

    #region Exceptions

    /// <summary>
    /// Raised if an illegal rank was passed
    /// </summary>
    public class IllegalRankException : Exception
    {
        public IllegalRankException()
        {
        }

        public IllegalRankException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Raised if an illegal suit was passed.
    /// </summary>
    public class IllegalSuitException : Exception
    {
        public IllegalSuitException()
        {
        }

        public IllegalSuitException(string message) : base(message)
        {
        }
    }

    #endregion
}