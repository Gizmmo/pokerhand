using System.Collections.Generic;
using NUnit.Framework;
using PokerHand.Card;
using PokerHand.Hand.HandType;

namespace PokerHand.Test.Hand.Test.HandType.Test
{
    public class HighestCardTest
    {
        private List<ICard> _cards;
        private HighestCard _highestCard;

        private void SetUpValidHighestCardCards() {
            _cards = new List<ICard>
            {
                new PokerHand.Card.Card("6C"),
                new PokerHand.Card.Card("2C"),
                new PokerHand.Card.Card("3C"),
                new PokerHand.Card.Card("4C"),
                new PokerHand.Card.Card("5C")
            };
        }

        private void SetUpInvalidHighestCardCards() {
            _cards = new List<ICard>
            {
                new PokerHand.Card.Card("6C"),
                new PokerHand.Card.Card("2C"),
                new PokerHand.Card.Card("3C"),
                new PokerHand.Card.Card("4C"),
                new PokerHand.Card.Card("5S")
            };
        }

        private void SetUpHighestCard() {
            _highestCard = new HighestCard(_cards);
        }

        [Test]
        public void DoesCheckingIsValidOnHighestCardReturnTrue() {
            //Arrange
            SetUpValidHighestCardCards();

            //Act
            SetUpHighestCard();

            //Assert
            Assert.That(_highestCard.IsValid, Is.True);
        }

        private List<ICard> LowerValueHighestCard() {
            return new List<ICard>
            {
                new PokerHand.Card.Card("6C"),
                new PokerHand.Card.Card("2C"),
                new PokerHand.Card.Card("3C"),
                new PokerHand.Card.Card("4C"),
                new PokerHand.Card.Card("5C")
            };
        }

        private List<ICard> HigherValueHighestCard() {
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
        public void DoesTheSmallerHighestCardInComparisonReturnNegative() {
            var cardsOne = LowerValueHighestCard();
            var cardsTwo = HigherValueHighestCard();

            var highestCardOne = new HighestCard(cardsOne);

            var highestCardTwo = new HighestCard(cardsTwo);

            Assert.That(highestCardOne.CompareTo(highestCardTwo), Is.LessThan(0));
        }

        [Test]
        public void DoesTheLargerHighestCardInComparisonReturnPositive() {
            var cardsTwo = LowerValueHighestCard();
            var cardsOne = HigherValueHighestCard();

            var highestCardOne = new HighestCard(cardsOne);

            var highestCardTwo = new HighestCard(cardsTwo);

            Assert.That(highestCardOne.CompareTo(highestCardTwo), Is.GreaterThan(0));
        }

        [Test]
        public void DoesEqualHighestCardesReturnAZero() {
            var cardsTwo = LowerValueHighestCard();
            var cardsOne = LowerValueHighestCard();

            var highestCardOne = new HighestCard(cardsOne);

            var highestCardTwo = new HighestCard(cardsTwo);

            Assert.That(highestCardOne.CompareTo(highestCardTwo), Is.EqualTo(0));
        }
    }
}