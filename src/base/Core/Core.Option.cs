namespace Masha.Foundation
{
    using System;

    public static partial class Core
    {
        public static Option<T> Some<T>(T value) => new Option<T>(value);
        public static readonly NoneObject None = NoneObject._;

        public static R Match<T, R>(this Option<T> option,
            Func<T,R> Some, Func<R> None) =>
                option.HasSome ? Some(option.Value) : None();

        public static Option<R> Bind<T, R>(this Option<T> option,
            Func<T, R> f) =>
                option.Match((t) => Some(f(t)), () => None);

        public static Option<T> Bind<T>(this Option<T> result,
            Specification<T> spec)
        {
            if (result.HasSome)
            {
                var predicateCompiled = spec.predicate.Compile();
                return predicateCompiled.Invoke(result.Value) ? result : None;
            }
            return None;
        }

        public static Option<R> Map<T, R>(this Option<T> option,
            Func<T, Option<R>> f) =>
                option.Match(t => f(t), () => None);
    }
}
