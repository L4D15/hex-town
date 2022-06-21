namespace Becerra.Input.CustomEvents
{
    using Unity.VisualScripting;
    using UnityEngine;

    [UnitTitle("On Drag")]
    [UnitCategory("Events/Input/Touch")]
    public class OnDragEvent : EventUnit<Vector2>
    {
        public const string EventName = "OnDrag";

        protected override bool register => true;

        [DoNotSerialize]
        public ValueOutput WorldDelta { get; private set; }

        public override EventHook GetHook(GraphReference reference)
        {
            return new EventHook(EventName);
        }

        protected override void Definition()
        {
            base.Definition();

            this.WorldDelta = ValueOutput<Vector2>(nameof(this.WorldDelta));
        }

        protected override void AssignArguments(Flow flow, Vector2 worldDelta)
        {
            flow.SetValue(this.WorldDelta, worldDelta);
        }
    }
}