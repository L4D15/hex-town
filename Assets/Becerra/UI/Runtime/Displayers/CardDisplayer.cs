using Becerra.Deck;
using Unity.VisualScripting;
using UnityEngine;

namespace Becerra.UI.Displayers
{
    [RequireComponent(typeof(StateMachine))]
    public class CardDisplayer : MonoBehaviour
    {
        public State State { get; private set; }
        public ICard Card { get; private set; }

        public void SetData(ICard card)
        {
            this.Card = card;

            // Set state variables
            var variables = Variables.Object(this);

            variables.Set("UniqueID", card.UniqueID);
            variables.Set("CardData", card.SharedData);
            variables.Set("Card", card);
        }

        #region Unity

        public void Reset()
        {
            this.State = this.gameObject.GetComponent<State>();
        }

        #endregion Unity
    }
}