using Becerra.Currency;
using Becerra.Currency.Events;
using Becerra.Events;
using Becerra.User;
using System.Collections.Generic;
using UnityEngine;

namespace Becerra.UnityAdapter.Events
{
    public class UserCurrenciesEventsListener : MonoBehaviour,
        IEventListener<CurrencyAmountChanged>,
        IEventListener<CurrencyCapacityChangedEvent>
    {
        public IUser User;

        public void SetUser(IUser user)
        {
            StopListenintToEvents(user);

            this.User = user;

            StartListeningToEvents(user);
        }

        private IEnumerable<CurrencyType> GetCurrencyTypes() => (IEnumerable<CurrencyType>)System.Enum.GetValues(typeof(CurrencyType));

        private void StartListeningToEvents(IUser user)
        {
            if (user == null) return;

            var currencyTypes = GetCurrencyTypes();

            foreach (var type in currencyTypes)
            {
                var currency = user.Currencies.GetCurrency(type);

                StartListeningToCurrencyEvents(currency);
            }
        }

        private void StopListenintToEvents(IUser user)
        {
            if (user == null) return;

            var currencyTypes = GetCurrencyTypes();

            foreach (var type in currencyTypes)
            {
                var currency = user.Currencies.GetCurrency(type);

                StopListeningToCurrencyEvents(currency);
            }
        }

        private void StartListeningToCurrencyEvents(ICurrency currency)
        {
            if (currency == null) return;

            currency.AmountChanged.AddListener(this);
            currency.CapacityChanged.AddListener(this);
        }

        private void StopListeningToCurrencyEvents(ICurrency currency)
        {
            if (currency == null) return;

            currency.AmountChanged.RemoveListener(this);
            currency.CapacityChanged.RemoveListener(this);
        }

        #region Events

        public void HandleEvent(CurrencyAmountChanged gameEvent)
        {
            switch (gameEvent.Currency.Type)
            {
                case CurrencyType.Gold:
                    {
                        // TODO: Update any relevant widgets
                        break;
                    }
            }
        }

        public void HandleEvent(CurrencyCapacityChangedEvent gameEvent)
        {
            switch (gameEvent.Currency.Type)
            {
                case CurrencyType.Gold:
                    {
                        break;
                    }
            }
        }

        #endregion Events
    }
}