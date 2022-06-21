using Becerra.Currency;
using Becerra.Currency.Factories;
using Zenject;

namespace Becerra.Factories
{
    public class CurrencyFactory : ICurrencyFactory
    {
        private readonly DiContainer container;

        public CurrencyFactory(DiContainer container)
        {
            this.container = container;
        }

        public T Create<T>(CurrencyType type) where T : ICurrency
        {
            return this.container.Instantiate<T>(new object[] { type });
        }

        public ICurrency Create(CurrencyType type)
        {
            return Create<Currency.Currency>(type);
        }
    }
}