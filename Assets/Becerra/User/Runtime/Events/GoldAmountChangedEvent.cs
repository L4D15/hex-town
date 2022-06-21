using Unity.VisualScripting;

namespace Becerra.User.Events
{
    [UnitCategory("Events/User")]
    public class GoldAmountChangedEvent : EventUnit<int>
    {
        public const string EventName = "GoldAmountChanged";

        public ValueOutput Amount { get; private set; }

        protected override bool register => true;

        public override EventHook GetHook(GraphReference reference)
        {
            return new EventHook(EventName);
        }

        protected override void Definition()
        {
            base.Definition();

            this.Amount = ValueOutput<int>(nameof(this.Amount));
        }

        protected override void AssignArguments(Flow flow, int amount)
        {
            flow.SetValue(this.Amount, amount);
        }
    }
}
