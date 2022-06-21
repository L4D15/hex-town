namespace Becerra.UI.Displayers
{
    using UnityEngine;
    using Becerra.Deck;
    using Becerra.Deck.Providers;

    public class DeckDisplayer : MonoBehaviour
    {
        public Deck Deck { get; private set; }

        public void Start()
        {
            var provider = GetComponent<IDeckProvider>();

            this.Deck = provider.GetDeck();
        }
    }
}