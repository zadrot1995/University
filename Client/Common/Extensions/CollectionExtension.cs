using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Flagman.Common.Extensions
{
    public static class CollectionExtension
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any(o => o != null);
        }

        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> enumerable)
        {
            if (enumerable.IsNullOrEmpty())
                return;
            foreach (var item in enumerable)
            {
                collection.Add(item);
            }
        }

        public static void Remove<T>(this ObservableCollection<T> collection, Func<T, bool> predicate)
        {
            var collectionForRemove = collection.Where(predicate).ToList();
            for (int i = 0; i < collectionForRemove.Count; i++)
            {
                collection.Remove(collectionForRemove[i]);
            }
        }

        public static void InsertBetween(this ObservableCollection<int> collection, int value)
        {
            if (collection == null)
                return;
            if (collection.Count == 0)
                collection.Add(value);
            else
            {
                int index = collection.IndexOf(value);
                if (index == -1)
                {
                    try
                    {
                        var item = collection.First(i => i > value);
                        index = collection.IndexOf(item);
                        collection.Insert(index, value);

                    }
                    catch
                    {
                        collection.Add(value);
                    }
                }
            }
        }

        public static bool TryAdd<K, V>(this IDictionary<K, V> dict, K key, V value)
        {
            if (dict.ContainsKey(key))
                return false;
            dict.Add(key, value);
            return true;
        }

        public static void AddOrUpdate<K, V>(this IDictionary<K, V> dict, K key, V value)
        {
            if (dict.ContainsKey(key))
                dict[key] = value;
            else
                dict.Add(key, value);
        }
    }
}
