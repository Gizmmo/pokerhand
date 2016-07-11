using System;
using System.Collections.Generic;
using PokerHand.Card;

namespace PokerHand.Hand.HandType
{
    public interface IHandType
    {
        bool IsValid { get; }
    }
}