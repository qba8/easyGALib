using System;
using System.Collections.Generic;

namespace easyGALib.Helpers
{
    internal static class ExtensionMethods
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int length = list.Count;
            while (length > 1)
            {
                length--;
                int k = rng.Next(length + 1);
                T value = list[length];
                list[k] = list[length];
                list[length] = value;
            }
        }
    }
}
