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
    }
}