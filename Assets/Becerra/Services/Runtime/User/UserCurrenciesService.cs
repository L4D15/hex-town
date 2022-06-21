using Becerra.Currency;
using Becerra.Currency.Factories;
using Becerra.User.Services;
using System.Collections.Generic;

namespace Becerra.Services.User
{
    public class UserCurrenciesService : IUserCurrenciesService
    {
        private readonly Dictionary<CurrencyType, ICurrency> currencies;
        private readonly ICurrencyFactory currencyFactory;

        public UserCurrenciesService(ICurrencyFactory currencyFactory)
        {
            this.currencyFactory = currencyFactory;
            this.currencies = new Dictionary<CurrencyType, ICurrency>();

            this.CreateCurrencies();
        }

        public ICurrency GetCurrency(CurrencyType type)
        {
            return this.currencies[type];
        }

        private void CreateCurrencies()
        {
            var types = System.Enum.GetValues(typeof(CurrencyType));

            foreach (CurrencyType type in types)
            {
                var currency = currencyFactory.Create(type);

                this.currencies.Add(type, currency);
            }
        }
    }
}