using Becerra.Events.Factories;
using Becerra.Events.Tests.Events;
using Becerra.Factories;
using NUnit.Framework;
using Zenject;

namespace Becerra.Events.Tests
{
    public class EventsTests
    {
        [TestFixture]
        public class Creation : ZenjectUnitTestFixture
        {
            [Test]
            public void _1_Creation()
            {
                var onHealthLost = new EventService<HealthLostEvent>();

                Assert.NotNull(onHealthLost);

                var onHealthRestored = new EventService<HealthRestoredEvent>();

                Assert.NotNull(onHealthRestored);
            }
        }

        [TestFixture]
        public class Trigger : ZenjectUnitTestFixture
        {
            private class EventsReceiver : IEventListener<HealthLostEvent>, IEventListener<HealthRestoredEvent>
            {
                public int amount;

                public void HandleEvent(HealthRestoredEvent gameEvent)
                {
                    this.amount += gameEvent.Amount;
                }

                public void HandleEvent(HealthLostEvent gameEvent)
                {
                    this.amount -= gameEvent.Amount;
                }
            }

            [SetUp]
            public void SetUp()
            {
                FactoriesInstaller.Install(Container);
            }

            [TearDown]
            public void TearDown()
            {
            }

            [Test]
            public void _1_TriggerOnce()
            {
                var eventsFactory = Container.Resolve<IEventServiceFactory>();
                var health = new HealthService(eventsFactory);
                var receiver = new EventsReceiver();

                health.OnHealthLost.AddListener(receiver);
                health.OnHealthRestored.AddListener(receiver);

                health.AddHealth(10);

                Assert.AreEqual(10, receiver.amount);

                health.RemoveHealth(5);

                Assert.AreEqual(5, receiver.amount);
            }

            [Test]
            public void _2_TriggerMultipleTimes()
            {
                var eventsFactory = Container.Resolve<IEventServiceFactory>();
                var health = new HealthService(eventsFactory);
                var receiver = new EventsReceiver();

                health.OnHealthRestored.AddListener(receiver);

                health.AddHealth(10);

                Assert.AreEqual(10, receiver.amount);

                health.AddHealth(5);

                Assert.AreEqual(15, receiver.amount);

                health.AddHealth(2);

                Assert.AreEqual(17, receiver.amount);
            }

            [Test]
            public void _3_TriggerAfterRemoval()
            {
                var eventsFactory = Container.Resolve<IEventServiceFactory>();
                var health = new HealthService(eventsFactory);
                var receiver = new EventsReceiver();

                health.OnHealthRestored.AddListener(receiver);

                health.AddHealth(10);

                Assert.AreEqual(10, receiver.amount);

                health.OnHealthRestored.RemoveListener(receiver);

                health.AddHealth(5);

                Assert.AreEqual(10, receiver.amount);
            }
        }
    }
}