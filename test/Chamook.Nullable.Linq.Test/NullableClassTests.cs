using System;
using Xunit;
using Chamook.Nullable.Linq;

namespace Chamook.Nullable.Linq.Test
{
    public class NullableClassTests
    {
        [Fact]
        public void SelectSatisfiesIdentityLaw()
        {
            string? input = "hello";

            var afterIdentity = input.Select(x => x);

            Assert.Equal(input, afterIdentity);
        }

        [Fact]
        public void SelectSatisfiesCompositionLaw()
        {
            string? input = "hello";

            var first =
                input.Select(x => x.ToUpper().Replace('O', 'Ø'));
            var second =
                input.Select(x => x.ToUpper()).Select(x => x.Replace('O', 'Ø'));

            Assert.Equal(first, second);
        }

        [Fact]
        public void SelectManySatisfiesIdentityLaw()
        {
            string? input = "hello";

            var afterIdentity = input.SelectMany(x => x);

            Assert.Equal(input, afterIdentity);
        }

        [Fact]
        public void SelectManySatisfiesCompositionLaw()
        {
            string? input = "hello";

            var first =
                input.SelectMany(x => x.ToUpper().Replace('O', 'Ø'));
            var second =
                input
                    .SelectMany(x => x.ToUpper())
                    .SelectMany(x => x.Replace('O', 'Ø'));

            Assert.Equal(first, second);
        }

        [Fact]
        public void SelectWorksForFancySyntax()
        {
            string? GetString() => "hello";

            var result =
                from x in GetString()
                select x.ToUpper();

            Assert.Equal("HELLO", result);
        }

        [Fact]
        public void SelectManyWorksForFancySyntax()
        {
            string? GetHello() => "hello";
            string? GetWorld() => "world";

            var result =
                from x in GetHello()
                from y in GetWorld()
                select $"{x} {y}";

            Assert.Equal("hello world", result);
        }
    }
}
