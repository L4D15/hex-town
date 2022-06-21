namespace Becerra.Deck
{
    using Becerra.Currency;
    using Unity.VisualScripting;

    [System.Serializable]
    [Inspectable]
    public struct CardCost
    {
        [Inspectable]
        public CurrencyType Currency;

        [Inspectable]
        public int Amount;
    }
}