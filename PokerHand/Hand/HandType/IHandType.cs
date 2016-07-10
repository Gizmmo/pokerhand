using System;
using System.Collections.Generic;
using PokerHand.Card;

namespace PokerHand.Hand.HandType
{
    public interface IHandType : IComparable<IHandType>
    {
        bool IsValid(List<ICard> cards);
    }
}