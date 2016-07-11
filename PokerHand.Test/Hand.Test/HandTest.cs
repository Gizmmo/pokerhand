using NUnit.Framework;

namespace PokerHand.Test.Hand.Test
{
    [TestFixture]
    public class HandTest
    {
        private PokerHand.Hand.Hand _hand;

        [SetUp]
        public void Init()
        {
            _hand = new PokerHand.Hand.Hand();
        }

        [Test]
        public void DoesAddCardIncreaseTheCountOfHandByOne()
        {
            //Arrange
            var preAddSize = _hand.Count;

            //Act
            _hand.AddCard(new PokerHand.Card.Card("2H"));

            //Assert
            Assert.That(_hand.Count == preAddSize + 1);
        }

        private PokerHand.Hand.Hand CreateLowerOnePairHand()
        {
            var hand = new PokerHand.Hand.Hand();
            hand.AddCard(new PokerHand.Card.Card("2C"));
            hand.AddCard(new PokerHand.Card.Card("2D"));
            hand.AddCard(new PokerHand.Card.Card("3C"));
            hand.AddCard(new PokerHand.Card.Card("4H"));
            hand.AddCard(new PokerHand.Card.Card("7S"));
            return hand;
        }

        private PokerHand.Hand.Hand CreateHigherOnePairHand()
        {
            var hand = new PokerHand.Hand.Hand();
            hand.AddCard(new PokerHand.Card.Card("6C"));
            hand.AddCard(new PokerHand.Card.Card("6D"));
            hand.AddCard(new PokerHand.Card.Card("9C"));
            hand.AddCard(new PokerHand.Card.Card("5H"));
            hand.AddCard(new PokerHand.Card.Card("JS"));
            return hand;
        }

        private PokerHand.Hand.Hand CreateThreeOfAKind()
        {
            var hand = new PokerHand.Hand.Hand();
            hand.AddCard(new PokerHand.Card.Card("6C"));
            hand.AddCard(new PokerHand.Card.Card("6D"));
            hand.AddCard(new PokerHand.Card.Card("6S"));
            hand.AddCard(new PokerHand.Card.Card("5H"));
            hand.AddCard(new PokerHand.Card.Card("JS"));
            return hand;
        }

        private PokerHand.Hand.Hand CreateFlush()
        {
            var hand = new PokerHand.Hand.Hand();
            hand.AddCard(new PokerHand.Card.Card("6C"));
            hand.AddCard(new PokerHand.Card.Card("7C"));
            hand.AddCard(new PokerHand.Card.Card("9C"));
            hand.AddCard(new PokerHand.Card.Card("KC"));
            hand.AddCard(new PokerHand.Card.Card("JC"));
            return hand;
        }

        private PokerHand.Hand.Hand CreateHighValue()
        {
            var hand = new PokerHand.Hand.Hand();
            hand.AddCard(new PokerHand.Card.Card("6C"));
            hand.AddCard(new PokerHand.Card.Card("7C"));
            hand.AddCard(new PokerHand.Card.Card("9D"));
            hand.AddCard(new PokerHand.Card.Card("KH"));
            hand.AddCard(new PokerHand.Card.Card("JS"));
            return hand;
        }

        [Test]
        public void DoesComparingTwoOfTheSameHandTypeFromTheHigherHandReturnTheCorrectHigherValue()
        {
            //Arrange
            var lowerPairHand = CreateLowerOnePairHand();
            var higherPairHand = CreateHigherOnePairHand();

            //Act
            var higherPairComparedToLowerPair = higherPairHand.CompareTo(lowerPairHand);

            //Assert   
            Assert.That(higherPairComparedToLowerPair, Is.GreaterThan(0));
        }

        [Test]
        public void DoesComparingTwoOfTheSameHandTypeFromTheLowerHandReturnTheCorrectLowerValue()
        {
            //Arrange
            var lowerPairHand = CreateLowerOnePairHand();
            var higherPairHand = CreateHigherOnePairHand();

            //Act
            var lowerPairComparedToLowerPair = lowerPairHand.CompareTo(higherPairHand);

            //Assert   
            Assert.That(lowerPairComparedToLowerPair, Is.LessThan(0));
        }

        [Test]
        public void DoesComparingTheSameHandsResultInAZero()
        {
            //Arrange
            var lowerPairHand = CreateLowerOnePairHand();

            //Act
            var lowerPairComparedToLowerPair = lowerPairHand.CompareTo(lowerPairHand);

            //Assert   
            Assert.That(lowerPairComparedToLowerPair, Is.EqualTo(0));
        }


        [Test]
        public void DoesComparingAFlushToAThreeOfAKindReturnTheFlushAsTheWinner()
        {
            //Arrange
            var flush = CreateFlush();
            var three = CreateThreeOfAKind();

            //Act
            var higherPairComparedToLowerPair = flush.CompareTo(three);

            //Assert   
            Assert.That(higherPairComparedToLowerPair, Is.GreaterThan(0));
        }

        [Test]
        public void DoesComparingAFlushToAOnePairReturnTheFlushAsTheWinner()
        {
            //Arrange
            var flush = CreateFlush();
            var pair = CreateHigherOnePairHand();

            //Act
            var higherPairComparedToLowerPair = flush.CompareTo(pair);

            //Assert   
            Assert.That(higherPairComparedToLowerPair, Is.GreaterThan(0));
        }

        [Test]
        public void DoesComparingAFlushToAHighValueReturnTheFlushAsTheWinner()
        {
            //Arrange
            var flush = CreateFlush();
            var high = CreateHighValue();

            //Act
            var higherPairComparedToLowerPair = flush.CompareTo(high);

            //Assert   
            Assert.That(higherPairComparedToLowerPair, Is.GreaterThan(0));
        }

        [Test]
        public void DoesComparingAThreeOfAKindToAOnePairReturnTheThreeAsTheWinner()
        {
            //Arrange
            var three = CreateThreeOfAKind();
            var pair = CreateLowerOnePairHand();

            //Act
            var lowerPairComparedToHigher = pair.CompareTo(three);

            //Assert   
            Assert.That(lowerPairComparedToHigher, Is.LessThan(0));
        }

        [Test]
        public void DoesComparingAThreeOfAKindToAHighValReturnTheThreeAsTheWinner() {
            //Arrange
            var three = CreateThreeOfAKind();
            var high = CreateHighValue();

            //Act
            var lowerPairComparedToHigher = high.CompareTo(three);

            //Assert   
            Assert.That(lowerPairComparedToHigher, Is.LessThan(0));
        }

        [Test]
        public void DoesComparingAOnePairToAHighValReturnTheThreeAsTheWinner() {
            //Arrange
            var pair = CreateHigherOnePairHand();
            var high = CreateHighValue();

            //Act
            var lowerPairComparedToHigher = high.CompareTo(pair);

            //Assert   
            Assert.That(lowerPairComparedToHigher, Is.LessThan(0));
        }
    }
}