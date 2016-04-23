using System;
using System.Collections.Generic;

namespace easyGALib.Helpers
{
    internal static class ExtensionMethods
    {
        public static void Shuffle<T>(this IList<T> list, Random rdm)
        {
            int length = list.Count;
            while (length > 1)
            {
                length--;
                int k = rdm.Next(length + 1);
                T value = list[length];
                list[k] = list[length];
                list[length] = value;
            }
        }
    }
}
