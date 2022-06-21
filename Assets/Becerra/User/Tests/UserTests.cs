using Becerra.Factories;
using Becerra.User.Factories;
using NUnit.Framework;
using Zenject;

namespace Becerra.User.Tests
{
    public class UserTests
    {
        [TestFixture]
        public class Create : ZenjectUnitTestFixture
        {
            [SetUp]
            public void SetUp()
            {
                FactoriesInstaller.Install(Container);
            }

            [Test]
            public void _1_Empty()
            {
                var userFactory = Container.Resolve<IUserFactory>();
                var user = userFactory.CreateUser("WOLOLO");

                Assert.NotNull(user);
            }

            [Test]
            public void _2_Services()
            {
                var userFactory = Container.Resolve<IUserFactory>();
                var user = userFactory.CreateUser("WOLOLO");

                Assert.NotNull(user.Currencies);
            }
        }
    }
}