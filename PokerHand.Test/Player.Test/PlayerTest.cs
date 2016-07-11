using NUnit.Framework;

namespace PokerHand.Test.Player.Test
{
    [TestFixture]
    public class PlayerTest
    {
        [Test]
        public void DoesCreatingAPlayerInitializeTheCurrentHandProperty()
        {
            //Arrange
            var name = "Travis";
            var hand = new[] {"AC", "2H", "7D", "JS", "JC"};
            var player = new PokerHand.Player.Player(name, hand);

            //Act
            var isCurrentHandNull = player.CurrentHand == null;

            //Assert
            Assert.That(isCurrentHandNull, Is.False);
        }

        [Test]
        public void DoesComparingTwoPlayersWhoHaveDifferentHandReturnTheProperWinnerInPositive()
        {
            //Arrange
            var nameOne = "Travis";
            var handOne = new[] {"AC", "2H", "7D", "JS", "JC"};

            var nameTwo = "Denny";
            var handTwo = new[] {"2S", "9H", "4C", "3D", "JH"};

            var playerOne = new PokerHand.Player.Player(nameOne, handOne);
            var playerTwo = new PokerHand.Player.Player(nameTwo, handTwo);

            //Act
            var playerOneIsWinner = playerOne.CompareTo(playerTwo);

            //Assert
            Assert.That(playerOneIsWinner, Is.GreaterThan(0));
        }

        [Test]
        public void DoesComparingTwoPlayersWhoHaveDifferentHandReturnTheProperWinnerInNegative()
        {
            //Arrange
            var nameOne = "Travis";
            var handOne = new[] {"AC", "2H", "7D", "JS", "JC"};

            var nameTwo = "Denny";
            var handTwo = new[] {"2S", "9H", "4C", "3D", "JH"};

            var playerOne = new PokerHand.Player.Player(nameOne, handOne);
            var playerTwo = new PokerHand.Player.Player(nameTwo, handTwo);

            //Act
            var playerTwoIsWinner = playerTwo.CompareTo(playerOne);

            //Assert
            Assert.That(playerTwoIsWinner, Is.LessThan(0));
        }

        [Test]
        public void DoesComparingTwoPlayersWhoTheSameHandReturnTheProperWinners()
        {
            //Arrange
            var nameOne = "Travis";
            var handOne = new[] {"AC", "2H", "7D", "JS", "JC"};

            var nameTwo = "Denny";
            var handTwo = new[] {"AS", "2D", "7C", "JD", "JH"};

            var playerOne = new PokerHand.Player.Player(nameOne, handOne);
            var playerTwo = new PokerHand.Player.Player(nameTwo, handTwo);

            //Act
            var playerOneIsWinner = playerOne.CompareTo(playerTwo);

            //Assert
            Assert.That(playerOneIsWinner, Is.EqualTo(0));
        }
    }
}