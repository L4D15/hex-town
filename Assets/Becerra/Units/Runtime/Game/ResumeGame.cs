using Becerra.Game.Output;
using Unity.VisualScripting;
using Zenject;

namespace Becerra.Units.Game
{
    [UnitCategory("Game")]
    public class ResumeGame : InjectableUnit
    {
        [DoNotSerialize, PortLabelHidden]
        public ControlInput InputTrigger;

        [DoNotSerialize, PortLabelHidden]
        public ControlOutput OutputTrigger;

        [Inject] private IGameService gameService;

        protected override void Definition()
        {
            this.InputTrigger = ControlInput(nameof(this.InputTrigger), OnEnter);
            this.OutputTrigger = ControlOutput(nameof(this.OutputTrigger));

            Succession(this.InputTrigger, this.OutputTrigger);
        }

        private ControlOutput OnEnter(Flow flow)
        {
            this.gameService.Resume();

            return this.OutputTrigger;
        }
    }
}
