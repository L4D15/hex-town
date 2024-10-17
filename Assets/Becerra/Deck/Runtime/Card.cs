
namespace Becerra.Deck
{
    [System.Serializable]
    public class Card : ICard
    {
        public Card(string uniqueID, CardData data)
        {
            this.UniqueID = uniqueID;
            this.SharedData = data;
            this.CardDataID = data.ID;
        }

        public string UniqueID { get; }

        public string CardDataID { get; }

        public CardData SharedData { get; }
    }
}