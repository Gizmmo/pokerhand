using PokerHand.Hand;

namespace PokerHand.Player
{
    public interface IPlayer
    {
        /// <summary>
        /// The name of the player
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The current hand of the player that will have cards added to it.
        /// </summary>
        IHand CurrentHand { get; }
    }
}