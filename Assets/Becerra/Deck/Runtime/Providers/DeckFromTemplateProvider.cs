namespace Becerra.Deck.Providers
{
    using UnityEngine;

    public class DeckFromTemplateProvider : MonoBehaviour, IDeckProvider
    {
        public DeckTemplate DeckTemplate;

        public Deck GetDeck()
        {
            var deck = this.DeckTemplate.GenerateDeck();

            deck.Shuffle();

            return deck;
        }
    }
}