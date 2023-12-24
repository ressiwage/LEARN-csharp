using System;
using System.Collections;
using System.Collections.Generic;
namespace foresite
{

    public class KeyValueCollection<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private List<KeyValuePair<K, V>> items = new List<KeyValuePair<K, V>>();

        public bool Add(K key, V value)
        {
            int index = items.FindIndex(pair => EqualityComparer<K>.Default.Equals(pair.Key, key));
            if (index == -1)
            {
                items.Add(new KeyValuePair<K, V>(key, value));
                return true;
            }
            else
            {
                items[index] = new KeyValuePair<K, V>(key, value);
                return false;
            }
        }

        public V Remove(K key)
        {
            int index = items.FindIndex(pair => EqualityComparer<K>.Default.Equals(pair.Key, key));
            if (index != -1)
            {
                V value = items[index].Value;
                items.RemoveAt(index);
                return value;
            }
            throw new ArgumentException("The specified key does not exist in the collection");
        }

        public void Clear()
        {
            items.Clear();
        }

        public K GetKeyByValue(V value)
        {
            foreach (var pair in items)
            {
                if (EqualityComparer<V>.Default.Equals(pair.Value, value))
                {
                    return pair.Key;
                }
            }
            throw new ArgumentException("The specified value does not exist in the collection");
        }

        public V GetValueByKey(K key)
        {
            foreach (var pair in items)
            {
                if (EqualityComparer<K>.Default.Equals(pair.Key, key))
                {
                    return pair.Value;
                }
            }
            throw new ArgumentException("The specified key does not exist in the collection");
        }

        public bool ContainsKey(K key)
        {
            return items.Exists(pair => EqualityComparer<K>.Default.Equals(pair.Key, key));
        }

        public bool ContainsValue(V value)
        {
            return items.Exists(pair => EqualityComparer<V>.Default.Equals(pair.Value, value));
        }

        public int Count()
        {
            return items.Count;
        }

        public V[] GetAllValues()
        {
            V[] values = new V[items.Count];
            for (int i = 0; i < items.Count; i++)
            {
                values[i] = items[i].Value;
            }
            return values;
        }

        public K[] GetAllKeys()
        {
            K[] keys = new K[items.Count];
            for (int i = 0; i < items.Count; i++)
            {
                keys[i] = items[i].Key;
            }
            return keys;
        }

        // Реализация интерфейса IEnumerable
        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Уникальная функция для коллекции
        public void PrintAllKeyValuePairs()
        {
            Console.WriteLine("dict {");
            foreach (var pair in items)
            {
                Console.WriteLine($"    {pair.Key}:{pair.Value}");
            }
            Console.WriteLine("}");
        }
    }
}