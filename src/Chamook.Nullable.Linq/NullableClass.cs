using System;

namespace Chamook.Nullable.Linq
{
    public static class NullableClass
    {
        public static U? Select<T, U>(this T? nullable, Func<T, U> selector)
            where T : class
            where U : class
        {
            if (nullable is null) return null;

            return selector(nullable);
        }

        public static U? SelectMany<T, U>(this T? nullable, Func<T, U?> selector)
            where T : class
            where U : class
        {
            if (nullable is null) return null;

            return selector(nullable);
        }

        public static V? Select<T, U, V>(
            this T? nullable,
            Func<T, U> func,
            Func<T, U, V> selector)
            where T: class
            where U: class
            where V: class
        {
            if (nullable is null) return null;

            var intermediate = func(nullable);

            return selector(nullable, intermediate);
        }

        public static V? SelectMany<T, U, V>(
            this T? nullable,
            Func<T, U?> func,
            Func<T, U, V> selector)
            where T: class
            where U: class
            where V: class
        {
            if (nullable is null) return null;

            var intermediate = func(nullable);

            if (intermediate is null) return null;

            return selector(nullable, intermediate);
        }
    }
}
