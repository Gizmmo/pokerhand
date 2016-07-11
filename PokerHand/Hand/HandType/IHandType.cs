using System;
using System.Collections.Generic;
using PokerHand.Card;

namespace PokerHand.Hand.HandType
{
    public interface IHandType
    {
        /// <summary>
        /// If true, this means this hand type has met its criteria to be of that type
        /// ex. OnePair has 2 of the same cards.
        /// </summary>
        bool IsValid { get; }
    }
}