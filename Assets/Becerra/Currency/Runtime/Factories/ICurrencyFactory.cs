namespace Becerra.Currency.Factories
{
    public interface ICurrencyFactory
    {
        ICurrency Create(CurrencyType type);
    }
}