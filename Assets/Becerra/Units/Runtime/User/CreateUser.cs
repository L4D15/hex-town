using Becerra.User;
using Becerra.User.Services;
using Unity.VisualScripting;

namespace Becerra.Units.User
{
    [UnitCategory("User")]
    public class CreateUser : InjectableUnit
    {
        [DoNotSerialize, PortLabelHidden]
        public ControlInput Input;

        [DoNotSerialize, PortLabelHidden]
        public ControlOutput Output;

        [DoNotSerialize]
        public ValueInput UsersService;

        [DoNotSerialize]
        public ValueInput UserID;
        
        [DoNotSerialize]
        public ValueOutput User;

        private IUser createdUser;

        protected override void Definition()
        {
            this.Input = ControlInput(nameof(this.Input), OnEnter);
            this.Output = ControlOutput(nameof(this.Output));

            this.UsersService = ValueInput<IUsersService>(nameof(this.UsersService));
            this.UserID = ValueInput<string>(nameof(this.UserID));
            this.User = ValueOutput<IUser>(nameof(this.User), flow => this.createdUser);

            Succession(this.Input, this.Output);
            Requirement(this.UsersService, this.Input);
            Requirement(this.UserID, this.Input);
            Assignment(this.Input, this.User);
        }

        private ControlOutput OnEnter(Flow flow)
        {
            var userService = flow.GetValue<IUsersService>(this.UsersService);
            var userID = flow.GetValue<string>(this.UserID);

            this.createdUser = userService.CreateUser(userID);

            return this.Output;
        }
    }
}
