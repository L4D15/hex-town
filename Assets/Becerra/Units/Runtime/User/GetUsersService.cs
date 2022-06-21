
using Becerra.User.Services;
using Unity.VisualScripting;
using Zenject;

namespace Becerra.Units.User
{
    [UnitCategory("Users")]
    public class GetUsersService : InjectableUnit
    {
        [DoNotSerialize, PortLabelHidden]
        public ControlInput Input;

        [DoNotSerialize, PortLabelHidden]
        public ControlOutput Output;

        public ValueOutput UsersService;

        [Inject] private IUsersService usersService;

        protected override void Definition()
        {
            this.Input = ControlInput(nameof(this.Input), OnEnter);
            this.Output = ControlOutput(nameof(this.Output));

            this.UsersService = ValueOutput<IUsersService>(nameof(this.UsersService), flow => this.usersService);

            Succession(this.Input, this.Output);
            Assignment(this.Input, this.UsersService);
        }

        private ControlOutput OnEnter(Flow flow)
        {

            return this.Output;
        }
    }
}
