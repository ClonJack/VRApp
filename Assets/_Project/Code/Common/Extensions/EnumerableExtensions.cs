using System;
using System.Collections.Generic;

namespace UnrealTeam.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach(T item in enumeration) 
                action(item);
        }
    }
}