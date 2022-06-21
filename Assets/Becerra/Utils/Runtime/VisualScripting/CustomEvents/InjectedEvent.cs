using Unity.VisualScripting;

namespace Becerra.Utils.VisualScripting.CustomEvents
{
    [UnitTitle("On Injected")]
    [UnitCategory("Events")]
    public class InjectedEvent : EventUnit<bool>
    {
        public const string EventName = "Injected";

        [DoNotSerialize]
        public ValueOutput Result { get; private set; }

        protected override bool register => true;

        public override EventHook GetHook(GraphReference reference)
        {
            return new EventHook(EventName);
        }

        protected override void Definition()
        {
            base.Definition();

            this.Result = ValueOutput<bool>(nameof(this.Result));
        }

        protected override void AssignArguments(Flow flow, bool isInjected)
        {
            flow.SetValue(this.Result, isInjected);
        }
    }
}
