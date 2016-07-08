using NUnit.Framework;
using PokerHand.Card;

namespace PokerHand.Test.Card.Test
{
    [TestFixture]
    public class CardTest
    {
        private PokerHand.Card.Card _card;

        [SetUp]
        public void Init()
        {
            _card = new PokerHand.Card.Card("2H");
        }

        [Test]
        [TestCase("AH", CardRank.Ace)]
        [TestCase("2H", CardRank.Two)]
        [TestCase("3H", CardRank.Three)]
        [TestCase("4S", CardRank.Four)]
        [TestCase("5S", CardRank.Five)]
        [TestCase("6S", CardRank.Six)]
        [TestCase("7C", CardRank.Seven)]
        [TestCase("8C", CardRank.Eight)]
        [TestCase("9C", CardRank.Nine)]
        [TestCase("10D", CardRank.Ten)]
        [TestCase("JD", CardRank.Jack)]
        [TestCase("QD", CardRank.Queen)]
        [TestCase("KH", CardRank.King)]
        public void DoesPassingInitalValueToACardSetTheCorrectCardRank(string cardValue, CardRank expectedRank)
        {
            _card = new PokerHand.Card.Card(cardValue);
            Assert.That(_card.Rank, Is.EqualTo(expectedRank));
        }

        [Test]
        public void DoesPassingANonRankValueThrowAnIllegalRankException()
        {
            Assert.Throws<IllegalRankException>(CreateIllegalRankCard);
        }

        private void CreateIllegalRankCard()
        {
            _card = new PokerHand.Card.Card("11C");
        }

        [Test]
        [TestCase("AH", CardSuit.Hearts)]
        [TestCase("2H", CardSuit.Hearts)]
        [TestCase("3H", CardSuit.Hearts)]
        [TestCase("4S", CardSuit.Spades)]
        [TestCase("5S", CardSuit.Spades)]
        [TestCase("6S", CardSuit.Spades)]
        [TestCase("7C", CardSuit.Clubs)]
        [TestCase("8C", CardSuit.Clubs)]
        [TestCase("9C", CardSuit.Clubs)]
        [TestCase("10D", CardSuit.Diamonds)]
        [TestCase("JD", CardSuit.Diamonds)]
        [TestCase("QD", CardSuit.Diamonds)]
        [TestCase("KH", CardSuit.Hearts)]
        public void DoesPassingInitalValueToACardSetTheCorrectCardSuit(string cardValue, CardSuit expectedSuit)
        {
            _card = new PokerHand.Card.Card(cardValue);
            Assert.That(_card.Suit, Is.EqualTo(expectedSuit));
        }

        [Test]
        public void DoesPassingANonSuitValueThrowAnIllegalSuitException()
        {
            Assert.Throws<IllegalSuitException>(CreateIllegalSuitCard);
        }

        private void CreateIllegalSuitCard()
        {
            _card = new PokerHand.Card.Card("AA");
        }

        [Test]
        public void DoesIsSameSuitReturnTrueIfACardWithTheSameSuitIsPassed()
        {
            _card = new PokerHand.Card.Card("2H");
            var secondCard = new PokerHand.Card.Card("JH");
            var cardsHaveTheSameValue = _card.IsSameSuit(secondCard);
            Assert.That(cardsHaveTheSameValue, Is.True);
        }

        [Test]
        public void DoesIsSameSuitReturnFalseIfACardWithoutTheSameSuitIsPassed()
        {
            _card = new PokerHand.Card.Card("2H");
            var secondCard = new PokerHand.Card.Card("JC");
            var cardsHaveTheSameValue = _card.IsSameSuit(secondCard);
            Assert.That(cardsHaveTheSameValue, Is.False);
        }

        [Test]
        public void DoesIsSameColorReturnFalseIfACardWithoutTheSameColorIsPassed()
        {
            _card = new PokerHand.Card.Card("2H");
            var secondCard = new PokerHand.Card.Card("JC");
            var cardsHaveTheSameValue = _card.IsSameColor(secondCard);
            Assert.That(cardsHaveTheSameValue, Is.False);
        }

        [Test]
        public void DoesIsSameColorReturnTrueIfACardWithTheSameColorIsPassed()
        {
            _card = new PokerHand.Card.Card("2H");
            var secondCard = new PokerHand.Card.Card("JH");
            var cardsHaveTheSameValue = _card.IsSameColor(secondCard);
            Assert.That(cardsHaveTheSameValue, Is.True);
        }

        [Test]
        [TestCase("2H", "3C")]
        [TestCase("3S", "4D")]
        [TestCase("AH", "2D")]
        [TestCase("10C", "JD")]
        [TestCase("QH", "KC")]
        public void DoesIsOneGreaterReturnTrueIfTheCardPassedIsGreaterThenTheBaseCard(string baseCardValue, string secondCardValue)
        {
            _card = new PokerHand.Card.Card(baseCardValue);
            var cardTwo = new PokerHand.Card.Card(secondCardValue);
            var isCardTwoGreaterThenCardOne = _card.IsOneGreater(cardTwo);
            Assert.That(isCardTwoGreaterThenCardOne, Is.True);
        }

        [Test]
        [TestCase("KH", "3C")]
        [TestCase("3S", "5D")]
        [TestCase("AH", "KD")]
        [TestCase("KC", "AD")]
        [TestCase("5H", "9C")]
        public void DoesIsOneGreaterReturnFalseIfRankIsNotGreaterThenOne(string baseCardValue, string secondCardValue)
        {
            _card = new PokerHand.Card.Card(baseCardValue);
            var cardTwo = new PokerHand.Card.Card(secondCardValue);
            var isCardTwoGreaterThenCardOne = _card.IsOneGreater(cardTwo);
            Assert.That(isCardTwoGreaterThenCardOne, Is.False);
        }
    }
}