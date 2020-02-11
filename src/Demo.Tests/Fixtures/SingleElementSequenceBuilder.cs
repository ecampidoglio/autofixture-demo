using System;
using System.Collections.Generic;
using AutoFixture.Kernel;

namespace Demo.Tests.Fixtures
{
    public class SingleElementSequenceBuilder<T> : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (IsRequestForSequence(request))
            {
                return SequenceWithExactlyOneElement(context);
            }

            return new NoSpecimen();
        }

        private static bool IsRequestForSequence(object request)
        {
            var requestedType = request as Type;
            return IsEnumerableOf(requestedType) || IsArrayOf(requestedType);
        }

        private static bool IsEnumerableOf(Type type)
        {
            return type == typeof(IEnumerable<T>);
        }

        private static bool IsArrayOf(Type type)
        {
            return type == typeof(T[]);
        }

        private static IEnumerable<T> SequenceWithExactlyOneElement(ISpecimenContext context)
        {
            return new[] { (T)context.Resolve(typeof(T)) };
        }
    }
}
