namespace Becerra.Deck
{
    using Sirenix.OdinInspector;
    using UnityEngine;

    [CreateAssetMenu(fileName = "Deck Template", menuName = "Becerra/Data/Deck Template")]
    public class DeckTemplate : ScriptableObject
    {
        [System.Serializable]
        public struct Entry
        {
            [AssetList(Path = "Data/Cards")]
            public CardData CardData;

            [Range(1, 4)]
            public int Amount;
        }

        public Entry[] Entries;

        public Deck GenerateDeck()
        {
            var deck = new Deck();

            foreach (var entry in this.Entries)
            {
                for (int i = 0; i < entry.Amount; i++)
                {
                    string id = $"{entry.CardData.ID}_{i}";
                    var card = new Card(id, entry.CardData);

                    deck.DrawPile.Add(card);
                }
            }

            return deck;
        }
    }
}