using Becerra.Currency;

namespace Becerra.User.Services
{
    public interface IUserCurrenciesService
    {
        ICurrency GetCurrency(CurrencyType type);
    }
}