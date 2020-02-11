using AutoFixture;

namespace Demo.Tests.Fixtures
{
    public class SingleElementSequence<T> : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new SingleElementSequenceBuilder<T>());
        }
    }
}
