using System;
using System.Collections.Generic;
using Ploeh.AutoFixture.Kernel;

public class SingleElementSequenceBuilder<T> : ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (IsRequestForSequence(request))
        {
            return SequenceWithExactlyOneElement(context);
        }

        return new NoSpecimen(request);
    }

    static bool IsRequestForSequence(object request)
    {
        var requestedType = request as Type;
        return IsEnumerableOf(requestedType) || IsArrayOf(requestedType);
    }

    static bool IsEnumerableOf(Type type)
    {
        return type == typeof(IEnumerable<T>);
    }

    static bool IsArrayOf(Type type)
    {
        return type == typeof(T[]);
    }

    static IEnumerable<T> SequenceWithExactlyOneElement(ISpecimenContext context)
    {
        return new[] { (T)context.Resolve(typeof(T)) };
    }
}
