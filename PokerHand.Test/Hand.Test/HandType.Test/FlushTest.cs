using System;
using System.Collections.Generic;
using NUnit.Framework;
using PokerHand.Card;
using PokerHand.Hand.HandType;

namespace PokerHand.Test.Hand.Test.HandType.Test
{
    [TestFixture]
    public class FlushTest
    {
        private List<ICard> _cards;
        private Flush _flush;

        private void SetUpValidFlushCards()
        {
            _cards = new List<ICard>
            {
                new PokerHand.Card.Card("6C"),
                new PokerHand.Card.Card("2C"),
                new PokerHand.Card.Card("3C"),
                new PokerHand.Card.Card("4C"),
                new PokerHand.Card.Card("5C")
            };
        }

        private void SetUpInvalidFlushCards()
        {
            _cards = new List<ICard>
            {
                new PokerHand.Card.Card("6C"),
                new PokerHand.Card.Card("2C"),
                new PokerHand.Card.Card("3C"),
                new PokerHand.Card.Card("4C"),
                new PokerHand.Card.Card("5S")
            };
        }

        private void SetUpFlush()
        {
            _flush = new Flush(_cards);
        }

        [Test]
        public void DoesCheckingIsValidOnFlushReturnTrue()
        {
            //Arrange
            SetUpValidFlushCards();

            //Act
            SetUpFlush();

            //Assert
            Assert.That(_flush.IsValid, Is.True);
        }

        [Test]
        public void DoesCheckingIsValidOnNonFlushReturnFalse()
        {
            //Arrange
            SetUpInvalidFlushCards();

            //Act
            SetUpFlush();

            //Assert
            Assert.That(_flush.IsValid, Is.False);
        }

        private List<ICard> LowerValueFlush()
        {
            return new List<ICard>
            {
                new PokerHand.Card.Card("6C"),
                new PokerHand.Card.Card("2C"),
                new PokerHand.Card.Card("3C"),
                new PokerHand.Card.Card("4C"),
                new PokerHand.Card.Card("5C")
            };
        }

        private List<ICard> HigherValueFlush()
        {
            return new List<ICard>
            {
                new PokerHand.Card.Card("6S"),
                new PokerHand.Card.Card("2S"),
                new PokerHand.Card.Card("3S"),
                new PokerHand.Card.Card("8S"),
                new PokerHand.Card.Card("5S")
            };
        }

        [Test]
        public void DoesTheSmallerFlushInComparisonReturnNegative()
        {
            var cardsOne = LowerValueFlush();
            var cardsTwo = HigherValueFlush();

            var flushOne = new Flush(cardsOne);

            var flushTwo = new Flush(cardsTwo);

            Assert.That(flushOne.CompareTo(flushTwo), Is.LessThan(0));
        }

        [Test]
        public void DoesTheLargerFlushInComparisonReturnPositive()
        {
            var cardsTwo = LowerValueFlush();
            var cardsOne = HigherValueFlush();

            var flushOne = new Flush(cardsOne);

            var flushTwo = new Flush(cardsTwo);

            Assert.That(flushOne.CompareTo(flushTwo), Is.GreaterThan(0));
        }

        [Test]
        public void DoesEqualFlushesReturnAZero()
        {
            var cardsTwo = LowerValueFlush();
            var cardsOne = LowerValueFlush();

            var flushOne = new Flush(cardsOne);

            var flushTwo = new Flush(cardsTwo);

            Assert.That(flushOne.CompareTo(flushTwo), Is.EqualTo(0));
        }
    }
}