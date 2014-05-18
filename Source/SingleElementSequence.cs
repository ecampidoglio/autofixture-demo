using System;
using System.Collections.Generic;
using Ploeh.AutoFixture;

public class SingleElementSequence<T> : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Customizations.Add(new SingleElementSequenceBuilder<T>());
    }
}
