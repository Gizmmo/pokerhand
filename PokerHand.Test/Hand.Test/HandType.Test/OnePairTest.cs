using System.Collections.Generic;
using NUnit.Framework;
using PokerHand.Card;
using PokerHand.Hand.HandType;

namespace PokerHand.Test.Hand.Test.HandType.Test
{
    [TestFixture]
    public class OnePairTest
    {
        private List<ICard> _cards;
        private OnePair _pair;

        private void SetUpValidOnePairCards()
        {
            _cards = new List<ICard>
            {
                new PokerHand.Card.Card("6C"),
                new PokerHand.Card.Card("6S"),
                new PokerHand.Card.Card("3H"),
                new PokerHand.Card.Card("4D"),
                new PokerHand.Card.Card("5S")
            };
        }

        private void SetUpInvalidOnePairCards()
        {
            _cards = new List<ICard>
            {
                new PokerHand.Card.Card("6C"),
                new PokerHand.Card.Card("2H"),
                new PokerHand.Card.Card("3S"),
                new PokerHand.Card.Card("4C"),
                new PokerHand.Card.Card("5S")
            };
        }

        private void SetUpPair()
        {
            _pair = new OnePair(_cards);
        }

        [Test]
        public void DoesCheckingIsValidOnValidOnePairReturnTrue()
        {
            //Arrange
            SetUpValidOnePairCards();

            //Act
            SetUpPair();

            //Assert
            Assert.That(_pair.IsValid, Is.True);
        }

        [Test]
        public void DoesCheckingIsValidOnInvalidOnePairReturnFalse()
        {
            //Arrange
            SetUpInvalidOnePairCards();

            //Act
            SetUpPair();

            //Assert
            Assert.That(_pair.IsValid, Is.False);
        }

        private List<ICard> LowerValueOnePair()
        {
            return new List<ICard>
            {
                new PokerHand.Card.Card("6C"),
                new PokerHand.Card.Card("6D"),
                new PokerHand.Card.Card("3D"),
                new PokerHand.Card.Card("4H"),
                new PokerHand.Card.Card("5C")
            };
        }

        private List<ICard> HigherValueMatchingOnePair()
        {
            return new List<ICard>
            {
                new PokerHand.Card.Card("JC"),
                new PokerHand.Card.Card("JD"),
                new PokerHand.Card.Card("3D"),
                new PokerHand.Card.Card("4H"),
                new PokerHand.Card.Card("KC")
            };
        }

        private List<ICard> HigherValueOnePair()
        {
            return new List<ICard>
            {
                new PokerHand.Card.Card("JS"),
                new PokerHand.Card.Card("JH"),
                new PokerHand.Card.Card("3S"),
                new PokerHand.Card.Card("8S"),
                new PokerHand.Card.Card("5S")
            };
        }

        [Test]
        public void DoesTheSmallerOnePairInComparisonReturnNegative()
        {
            //Arrange
            var pairOne = new OnePair(LowerValueOnePair());
            var pairTwo = new OnePair(HigherValueOnePair());

            //Act
            var compareVal = pairOne.CompareTo(pairTwo);

            //Assert
            Assert.That(compareVal, Is.LessThan(0));
        }

        [Test]
        public void DoesTheLargerOnePairInComparisonReturnPositive()
        {
            //Arrange
            var pairOne = new OnePair(HigherValueOnePair());
            var pairTwo = new OnePair(LowerValueOnePair());

            //Act
            var compareVal = pairOne.CompareTo(pairTwo);

            //Assert
            Assert.That(compareVal, Is.GreaterThan(0));
        }

        [Test]
        public void DoesEqualOnePairsWithSameOtherCardsReturnAZero()
        {
            //Arrange
            var pairOne = new OnePair(LowerValueOnePair());
            var pairTwo = new OnePair(LowerValueOnePair());

            //Act
            var compareVal = pairOne.CompareTo(pairTwo);

            //Assert
            Assert.That(compareVal, Is.EqualTo(0));
        }

        [Test]
        public void DoesEqualOnePairsWithDifferentCardsReturnPositive()
        {
            //Arrange
            var pairOne = new OnePair(HigherValueMatchingOnePair());
            var pairTwo = new OnePair(HigherValueOnePair());

            //Act
            var compareVal = pairOne.CompareTo(pairTwo);

            //Assert
            Assert.That(compareVal, Is.GreaterThan(0));
        }

        [Test]
        public void DoesEqualOnePairsWithDifferentCardsReturnNegative()
        {
            //Arrange
            var pairOne = new OnePair(HigherValueOnePair());
            var pairTwo = new OnePair(HigherValueMatchingOnePair());

            //Act
            var compareVal = pairOne.CompareTo(pairTwo);

            //Assert
            Assert.That(compareVal, Is.LessThan(0));
        }
    }
}