using Becerra.Currency;

namespace Becerra.Deck
{
    [System.Serializable]
    public struct CardCost
    {
        public CurrencyType Currency;

        public int Amount;
    }
}