namespace Becerra.Input.CustomEvents
{
    using Unity.VisualScripting;
    using UnityEngine;

    [UnitTitle("On Tap")]
    [UnitCategory("Events/Input/Touch")]
    public class OnTapEvent : EventUnit<Vector2>
    {
        /// <summary>
        /// Name of the event triggered in the script.
        /// </summary>
        public const string EventName = "OnTap";

        /// <summary>
        /// Position of the touch in screen space.
        /// </summary>
        [DoNotSerialize]
        public ValueOutput ScreenPosition { get; private set; }

        /// <summary>
        /// Not sure what this does :-(
        /// </summary>
        protected override bool register => true;

        /// <summary>
        /// Hook this unit to trigger when the event name is triggered through the events bus.
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>
        public override EventHook GetHook(GraphReference reference)
        {
            return new EventHook(EventName);
        }

        /// <summary>
        /// Defines the ports and behaviour of this unit.
        /// </summary>
        protected override void Definition()
        {
            base.Definition();

            this.ScreenPosition = ValueOutput<Vector2>(nameof(this.ScreenPosition));
        }

        /// <summary>
        /// Assigns the values coming along with the event to the ports of the unit.
        /// </summary>
        /// <param name="flow"></param>
        /// <param name="screenPosition"></param>
        protected override void AssignArguments(Flow flow, Vector2 screenPosition)
        {
            flow.SetValue(this.ScreenPosition, screenPosition);
        }
    }
}