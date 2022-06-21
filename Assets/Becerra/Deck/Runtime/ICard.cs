namespace Becerra.Deck
{
    /// <summary>
    /// Represents a card in the game.
    /// </summary>
    public interface ICard
    {
        /// <summary>
        /// Unique identifier for this card instance.
        /// </summary>
        string UniqueID { get; }

        /// <summary>
        /// Gets the shared ID for all cards if the same type.
        /// </summary>
        string CardDataID { get; }

        /// <summary>
        /// Gets the shared data for all cards of this type.
        /// </summary>
        CardData SharedData { get; }
    }
}