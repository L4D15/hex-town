using System.Collections.Generic;

namespace Becerra.Deck
{
    public class Deck
    {
        public Deck()
        {
            this.DrawPile = new CardsPile();
            this.DiscardPile = new CardsPile();
        }

        public CardsPile DrawPile { get; }
        public CardsPile DiscardPile { get; }

        public Card Draw()
        {
            if (this.DrawPile.CardsCount == 0)
            {
                ShuffleDiscardIntoDraw();
            }

            var card = this.DrawPile.Draw();

            return card as Card;
        }

        public void Discard(Card card)
        {
            this.DiscardPile.Add(card);
        }

        public void Shuffle()
        {
            this.DrawPile.Shuffle();
        }

        private void ShuffleDiscardIntoDraw()
        {
            var cards = new List<ICard>(this.DiscardPile.Cards);

            foreach (var card in cards)
            {
                this.DrawPile.Add(card);
                this.DiscardPile.Remove(card);
            }

            Shuffle();
        }
    }
}