using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace NQueens.Helpers
{
    [DebuggerStepThrough]
    public static class OptionHelpers
    {
        public static Option<T> Some<T>(T value) => new Option<T>(value);

        public static Option<IEnumerable<T>> Some<T>(IEnumerable<T> value) => new Option<IEnumerable<T>>(value);
    }

    public enum OptionStatus
    {
        NoneValue,
        HasValue,
        Error
    }

    [DebuggerStepThrough]
    public struct Option<T>
    {
        public bool HasValue { get; private set; }
        public bool HasError { get; private set; }
        public Exception Error { get; private set; }
        public T Value { get; private set; }
        public OptionStatus Status { get; private set; }

        public Option(T value)
        {
            if (value == null)
            {
                HasValue = false;
                HasError = false;
                Error = null;
                Value = default;
                Status = OptionStatus.NoneValue;
            }
            else
            {
                HasValue = true;
                HasError = false;
                Value = value;
                Error = null;
                Status = OptionStatus.HasValue;
            }
        }

        public Option(Exception ex)
        {
            HasValue = false;
            HasError = true;
            Error = ex;
            Value = default;
            Status = OptionStatus.Error;
        }

        public static implicit operator Option<T>(T value) => new Option<T>(value);
        public static implicit operator T(Option<T> value) => value.Value;
        public static implicit operator Option<T>(Exception ex) => new Option<T>(ex);

    }

    public static class Helpers
    {
        [DebuggerStepThrough]
        public static Option<R> Select<T, R>(this Option<T> source, Func<Option<T>, R> func) =>
              func(source);
        public static Option<RR> SelectMany<T, R, RR>(this Option<T> source, Func<T, Option<R>> bind, Func<T, R, RR> project) =>
            source.HasValue ? project(source, bind(source)) : default(RR);

        public static Option<T> Where<T>(this Option<T> value, Func<T, bool> func)
        {
            if (func(value))
                return value;
            return default;
        }

        public static Option<R> Map<T, R>(this Option<T> source, Func<T, R> map) =>
            (source.HasValue && !source.HasError) ? OptionHelpers.Some(map(source.Value)) : new Option<R>();

        public static Option<IEnumerable<R>> Map<T,R>(this Option<IEnumerable<T>> source,Func<IEnumerable<T>, IEnumerable<R>> map)=>
            (source.HasValue && !source.HasError) ? OptionHelpers.Some(map(source.Value)) : new Option<IEnumerable<R>>();

        public static void Do<T>(this Option<T> source, Action<T> func) =>
            func(source);
    }
}
