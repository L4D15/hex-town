using Becerra.Deck;
using UnityEngine;

namespace Becerra.UI.Displayers
{
    public class CardDisplayer : MonoBehaviour
    {
        public ICard Card { get; private set; }

        public void SetData(ICard card)
        {
            this.Card = card;
        }

        #region Unity

        public void Reset()
        {
        }

        #endregion Unity
    }
}