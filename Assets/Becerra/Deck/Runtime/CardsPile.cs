using System.Collections.Generic;

namespace Becerra.Deck
{
    using UnityEngine;

    public class CardsPile
    {
        private readonly List<ICard> cards;

        public CardsPile()
        {
            this.cards = new List<ICard>();
        }

        public IEnumerable<ICard> Cards => this.cards;

        public int CardsCount => this.cards.Count;

        public void Add(ICard card)
        {
            Insert(card, 0);
        }

        public void Remove(ICard card)
        {
            this.cards.Remove(card);
        }

        public void Insert(ICard card, int indexFromTop)
        {
            this.cards.Insert(indexFromTop, card);
        }

        public ICard Draw()
        {
            var card = Peek(0);

            if (card == null) return null;

            Remove(card);

            return card;
        }

        public ICard Peek(int indexFromTop)
        {
            if (this.cards.Count < 1) return null;

            return this.cards[indexFromTop];
        }

        public void Shuffle()
        {
            if (this.cards.Count < 2) return;

            var indexes = new List<int>(this.cards.Count);
            var cards = new List<ICard>();

            for (int i = 0; i < this.cards.Count; i++)
            {
                indexes.Add(i);
            }

            for (int i = 0; i < this.cards.Count; i++)
            {
                int random = Random.Range(0, indexes.Count);
                int index = indexes[random];

                cards.Add(this.cards[index]);

                indexes.RemoveAt(random);
            }

            for (int i = 0; i < this.cards.Count; i++)
            {
                this.cards[i] = cards[i];
            }
        }

        public ICard FindFirst(System.Predicate<ICard> filter)
        {
            return this.cards.Find(filter);
        }

        public IEnumerable<ICard> FindAll(System.Predicate<ICard> filter)
        {
            return this.cards.FindAll(filter);
        }
    }
}