using NUnit.Framework;

namespace Cake.Dart.Tests
{
    public class ArgumentsBuilderExtensionTest
    {
        [TestFixture]
        public class FromObservatorySettings: ArgumentsBuilderExtensionTest
        {
            [Test]
            public void WhenPortAndBindingAddressAreNull_ReturnsNull()
            {
                var actual = ArgumentsBuilderExtension.FromObservatorySettings(new ObservatorySettings());

                Assert.That(actual, Is.Null);
            }
            [Test]
            public void WhenPortIsNullAndBindingAddressIsNotNull_ReturnsNull()
            {
                var actual = ArgumentsBuilderExtension.FromObservatorySettings(new ObservatorySettings { BindAddress = "10.0.0.0" });

                Assert.That(actual, Is.Null);
            }
            [Test]
            public void WhenPortIsNotNullAndBindingAddressIsNull_ReturnsOnlyPort()
            {
                var actual = ArgumentsBuilderExtension.FromObservatorySettings(new ObservatorySettings { Port = 99 });

                Assert.That(actual, Is.EqualTo("=99"));
            }
            [Test]
            public void WhenPortAndBindingAddressAreNotNull_ReturnsCorrectlyFormated()
            {
                var actual = ArgumentsBuilderExtension.FromObservatorySettings(
                    new ObservatorySettings { Port = 99, BindAddress = "10.0.0.0" });

                Assert.That(actual, Is.EqualTo("=99/10.0.0.0"));
            }
        }
    }
}
