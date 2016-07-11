using System.Collections.Generic;
using NUnit.Framework;
using PokerHand.Card;
using PokerHand.Hand.HandType;

namespace PokerHand.Test.Hand.Test.HandType.Test
{
    [TestFixture]
    public class ThreeOfAKindTest
    {
        private List<ICard> _cards;
        private ThreeOfAKind _pair;

        private void SetUpValidThreeOfAKindCards() {
            _cards = new List<ICard>
            {
                new PokerHand.Card.Card("6C"),
                new PokerHand.Card.Card("6S"),
                new PokerHand.Card.Card("6H"),
                new PokerHand.Card.Card("4D"),
                new PokerHand.Card.Card("5S")
            };
        }

        private void SetUpInvalidThreeOfAKindCards() {
            _cards = new List<ICard>
            {
                new PokerHand.Card.Card("6C"),
                new PokerHand.Card.Card("6H"),
                new PokerHand.Card.Card("3S"),
                new PokerHand.Card.Card("4C"),
                new PokerHand.Card.Card("5S")
            };
        }

        private void SetUpPair() {
            _pair = new ThreeOfAKind(_cards);
        }

        [Test]
        public void DoesCheckingIsValidOnValidThreeOfAKindReturnTrue() {
            //Arrange
            SetUpValidThreeOfAKindCards();

            //Act
            SetUpPair();

            //Assert
            Assert.That(_pair.IsValid, Is.True);
        }

        [Test]
        public void DoesCheckingIsValidOnInvalidThreeOfAKindReturnFalse() {
            //Arrange
            SetUpInvalidThreeOfAKindCards();

            //Act
            SetUpPair();

            //Assert
            Assert.That(_pair.IsValid, Is.False);
        }

        private List<ICard> LowerValueThreeOfAKind() {
            return new List<ICard>
            {
                new PokerHand.Card.Card("6C"),
                new PokerHand.Card.Card("6D"),
                new PokerHand.Card.Card("6S"),
                new PokerHand.Card.Card("4H"),
                new PokerHand.Card.Card("5C")
            };
        }

        private List<ICard> HigherValueMatchingThreeOfAKind() {
            return new List<ICard>
            {
                new PokerHand.Card.Card("JC"),
                new PokerHand.Card.Card("JD"),
                new PokerHand.Card.Card("JS"),
                new PokerHand.Card.Card("4H"),
                new PokerHand.Card.Card("KC")
            };
        }

        private List<ICard> HigherValueThreeOfAKind() {
            return new List<ICard>
            {
                new PokerHand.Card.Card("JS"),
                new PokerHand.Card.Card("JH"),
                new PokerHand.Card.Card("JS"),
                new PokerHand.Card.Card("8S"),
                new PokerHand.Card.Card("5S")
            };
        }

        [Test]
        public void DoesTheSmallerThreeOfAKindInComparisonReturnNegative() {
            //Arrange
            var cardsOne = LowerValueThreeOfAKind();
            var cardsTwo = HigherValueThreeOfAKind();

            //Act
            var pairOne = new ThreeOfAKind(cardsOne);
            var pairTwo = new ThreeOfAKind(cardsTwo);

            //Assert
            Assert.That(pairOne.CompareTo(pairTwo), Is.LessThan(0));
        }

        [Test]
        public void DoesTheLargerThreeOfAKindInComparisonReturnPositive() {
            //Arrange
            var cardsTwo = LowerValueThreeOfAKind();
            var cardsOne = HigherValueThreeOfAKind();

            //Act
            var pairOne = new ThreeOfAKind(cardsOne);
            var pairTwo = new ThreeOfAKind(cardsTwo);

            //Assert
            Assert.That(pairOne.CompareTo(pairTwo), Is.GreaterThan(0));
        }

        [Test]
        public void DoesEqualThreeOfAKindsWithSameOtherCardsReturnAZero() {
            //Arrange
            var cardsTwo = LowerValueThreeOfAKind();
            var cardsOne = LowerValueThreeOfAKind();

            //Act
            var pairOne = new ThreeOfAKind(cardsOne);
            var pairTwo = new ThreeOfAKind(cardsTwo);

            //Assert
            Assert.That(pairOne.CompareTo(pairTwo), Is.EqualTo(0));
        }

        [Test]
        public void DoesEqualThreeOfAKindsWithDifferentCardsReturnPositive() {
            //Arrange
            var cardsOne = HigherValueMatchingThreeOfAKind();
            var cardsTwo = HigherValueThreeOfAKind();

            //Act
            var pairOne = new ThreeOfAKind(cardsOne);
            var pairTwo = new ThreeOfAKind(cardsTwo);

            //Assert
            Assert.That(pairOne.CompareTo(pairTwo), Is.GreaterThan(0));
        }

        [Test]
        public void DoesEqualThreeOfAKindsWithDifferentCardsReturnNegative() {
            //Arrange
            var cardsTwo = HigherValueMatchingThreeOfAKind();
            var cardsOne = HigherValueThreeOfAKind();

            //Act
            var pairOne = new ThreeOfAKind(cardsOne);
            var pairTwo = new ThreeOfAKind(cardsTwo);

            //Assert
            Assert.That(pairOne.CompareTo(pairTwo), Is.LessThan(0));
        }
    }
}