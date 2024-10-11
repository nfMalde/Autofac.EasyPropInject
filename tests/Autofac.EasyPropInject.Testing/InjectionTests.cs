using Autofac.EasyPropInject.Testing.mocks;
using NUnit.Framework;
using Autofac.EasyPropInject;
namespace Autofac.EasyPropInject.Testing
{
    /// <summary>
    /// Test for easy Property Injections
    /// </summary>
    public class InjectionTests
    {
        /// <summary>
        /// The container
        /// </summary>
        private IContainer container;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            ContainerBuilder builder = new ContainerBuilder().AddEasyPropInject();
            builder.Register<Mock1>(x => new Mock1()).As<IMock1>();
            builder.Register<Mock2>(x => new Mock2()).As<IMock2>();
            builder.Register<Mock3>(x => new Mock3()).As<IMock3>();
            builder.Register<Mock4>(x => new Mock4()).As<IMock4>();
            builder.RegisterType<MockPrivate>().As<IMockPrivate>();
            builder.RegisterType<MockProtected>().As<IMockProtected>();

            this.container = builder.Build();
        }

        /// <summary>
        /// Tests if all instances are resolved correctly
        /// </summary>
        [Test]
        public void ItShouldInjectPropertiesOfInstanceAndChildInstances()
        {
            var m1 = this.container.Resolve<IMock1>();

            Assert.That(m1.Mock2Property != null);
            Assert.That(m1.Mock2Property.Mock3Property != null);
            Assert.That(m1.Mock2Property.Mock3Property.Mock4ResolvedAsMainType != null);
        }

        [Test]
        public void ItShouldResolvePrivateProperties()
        {
            var mPrivate = this.container.Resolve<IMockPrivate>();

            Assert.That(mPrivate.Mock1Test() != null);
        }

        [Test]
        public void ItShouldResolveProtectedProperties()
        {
            var mPrivate = this.container.Resolve<IMockProtected>();

            Assert.That(mPrivate.GetMockPrivate() != null);
            Assert.That(mPrivate.GetMockPrivate().Mock1Test() != null);
        }
    }
}