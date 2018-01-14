using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ConnectFour.WpfClient
{
    public static class RaisePropertyChangedExtensions
    {
        public static void SetValueIfDifferent<T>(this IRaisePropertyChanged sourceObject,
                                                  T value,
                                                  ref T field,
                                                  [CallerMemberName] string propertyName = null)
        {
// ReSharper disable once ExplicitCallerInfoArgument
            SetValueIfDifferent(sourceObject, value, ref field, EqualityComparer<T>.Default, propertyName);
        }
        public static void SetValueIfDifferent<T>(this IRaisePropertyChanged sourceObject,
                                                  T value,
                                                  ref T field,
                                                  IEqualityComparer<T> equalityComparer,
                                                  [CallerMemberName] string propertyName = null)
        {
            if (equalityComparer.GetHashCode(value) == equalityComparer.GetHashCode(field) &&
                equalityComparer.Equals(value, field))
                return;

            field = value;
            sourceObject.RaisePropertyChanged(propertyName);
        }
    }
}