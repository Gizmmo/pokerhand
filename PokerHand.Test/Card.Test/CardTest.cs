using NUnit.Framework;

namespace PokerHand.Test.Card.Test
{
    [TestFixture]
    public class CardTest
    {
        private PokerHand.Card.Card _card;
        [SetUp]
        public void Init()
        {
            _card = new PokerHand.Card.Card();
        }

        [Test]
        public void DoesPassingALetterAndNumberValueToACardInConsturctorSetTheCorrectCardValues()
        {
            var card = new PokerHand.Card.Card();
            var testReturnsTrue = card.Test();
            Assert.That(testReturnsTrue, Is.True);
        }
    }
}