using System;
using System.Collections.Generic;
using System.Linq;
using PokerHand.Card;

namespace PokerHand.Game
{
    public class Game : IGame
    {
        #region private Attributes

        private List<Player.Player> _players = new List<Player.Player>();

        #endregion

        #region Public Methods

        /// <summary>
        /// Runs the game until it is exited.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                OutputOptions();
                PerformChosenAction(GetInput());
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Performs the action associated with the imput number passed
        /// </summary>
        /// <param name="inputNumber">The input number to use to choose an action</param>
        private void PerformChosenAction(int inputNumber)
        {
            switch (inputNumber)
            {
                case 1:
                    GetNewPlayer();
                    break;
                case 2:
                    FindWinners();
                    break;
                case 3:
                    ClearPlayers();
                    break;
                case 4:
                    Exit();
                    break;
                default:
                    InvalidInput();
                    break;
            }
        }

        /// <summary>
        /// Clears the players list to start the game over
        /// </summary>
        private void ClearPlayers()
        {
            _players.Clear();
        }

        /// <summary>
        /// Outputs that an invalid option was chosen.
        /// </summary>
        private void InvalidInput()
        {
            Console.WriteLine("An invalid option was chosen, please try again.\n");
        }

        /// <summary>
        /// Exits the application
        /// </summary>
        private void Exit()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Outputs any winners to the console.
        /// </summary>
        private void FindWinners()
        {
            // If the players is at 0...
            if (_players.Count == 0)
            {
                // ...Log topthe user that there are no players...
                Console.WriteLine("No players are currently in the game.  Please add players first...\n");
                //... And go back to the main menu.
                return;
            }

            Console.WriteLine("And the winners are...");

            var winnersList = new List<Player.Player>();
            foreach (var player in _players)
                CheckForWinner(player, winnersList);

            //For each winner, print out ther name to show they won!
            winnersList.ForEach(player => Console.WriteLine(player.Name));
            EnterEmptyLine();
        }

        /// <summary>
        /// Checks to see if the passed player is a winner based on the other winners
        /// </summary>
        /// <param name="player">The player to check is a winner</param>
        /// <param name="winnersList">The list of already existing winners</param>
        private void CheckForWinner(Player.Player player, List<Player.Player> winnersList)
        {
            //if the winners list is empty...
            if (winnersList.Count == 0)
            {
                // ...Add the first player to the list...
                winnersList.Add(player);

                //...And exit from checking any further
                return;
            }

            var compareVal = player.CompareTo(winnersList[0]);

            // IF compareVal is greater then 0. the new player is of more value then the ones
            // in the winner list...
            if (compareVal > 0)
            {
                // ...Clear the winner list...
                winnersList.Clear();

                // ...And add that player to the list as the only current winner
                winnersList.Add(player);
            }
            //If the compare is 0, that means that they are the same value hand
            else if (compareVal == 0)
                //So add that new winner to the winner list.
                winnersList.Add(player);
        }

        /// <summary>
        /// Enters an empty line into the console.
        /// </summary>
        private void EnterEmptyLine()
        {
            Console.WriteLine("");
        }

        /// <summary>
        /// Gets a new player and if its correct, stores it into the players list.
        /// </summary>
        private void GetNewPlayer()
        {
            Console.WriteLine("Enter a Players name and cards:");
            var input = Console.ReadLine();
            EnterEmptyLine();

            //If input is null...
            if (input == null)
            {
                // ...then log an error to the user...
                InvalidNewPlayer();
                // ...And go back to the main menu.
                return;
            }

            // Split up the input by commas and trim any excess white space
            var csValues = input.Split(',').Select(p => p.Trim()).ToArray();

            // If the length of the array is not 6, input was put in incorrectly
            if (csValues.Length != 6)
            {
                // ...Log an error to the user...
                InvalidNewPlayer();
                // ...And go back to the main menu.
                return;
            }

            // Take the first element of the array out.
            var cardVals = csValues.Skip(1).ToArray();

            //Try to add the player to the player List.
            try
            {
                _players.Add(new Player.Player(csValues[0], cardVals));
            }
            catch (IllegalRankException e)
            {
                Console.WriteLine("An Illegal rank was added when entering card values.  This player was not added.\n");
            }
            catch (IllegalSuitException e)
            {
                Console.WriteLine("An Illegal suit was added when entering card values.  This player was not added.\n");
            }
        }

        /// <summary>
        /// Outputs an invalid player error to the console
        /// </summary>
        private void InvalidNewPlayer()
        {
            Console.WriteLine("An invalid player was entered\n");
        }

        /// <summary>
        /// Gets the input from the user and returns it as an int.
        /// </summary>
        /// <returns>An input number the user wrote, or -1 if the input was incorrect</returns>
        private int GetInput()
        {
            var input = Console.ReadLine();
            int choiceNum;

            if (!int.TryParse(input, out choiceNum))
                choiceNum = -1;

            EnterEmptyLine();

            return choiceNum;
        }

        /// <summary>
        /// Outputs the options the user has in the main menu.
        /// </summary>
        private void OutputOptions()
        {
            Console.WriteLine("Please choose one of the options\n1.Enter A Player Name\n2.Find out the winner(s)\n3.Restart\n4.Exit\n");
        }

        #endregion
    }
}