using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Linq;


namespace foresite
{

    public class KeyValueCollection<K, V> : IEnumerable where K: struct, IComparable where V: struct, IComparable
    {
        private K?[] keys = new K?[2];
        private V?[] values = new V?[2];
        private int _len = 2;

        public bool Add(K key, V value)
        {
            int index = Array.IndexOf(this.keys, key);
            if (index < 0)
            {
                if (this.keys.Count(v => v == null) == 0) { this.scale(); }
                
                int ind = Array.IndexOf(this.keys, default);
                this.keys[ind] = key;
                this.values[ind] = value;
                return true;

            }
            else
            {
                values[index] = value;
                return false;
            }
        }

        private void scale()
        {
            this._len *= 2;
            Array.Resize(ref this.keys, this._len);
            Array.Resize(ref this.values, this._len);
        }

        public V? Remove(K key) 
        {
            int index = Array.IndexOf(this.keys, key);
            if (index < 0)
            {
                return null;
            }
            V returned = (V)this.values[index];
            this.keys[index] = default;
            this.values[index] = default;
            return returned;
            
        }

        public void Clear()
        {
            this.keys = new K?[2];
            this.values = new V?[2];
        }

        public K GetKeyByValue(V value)
        {
            int index = Array.IndexOf(this.values, value);
            return (K)this.keys[index];
        }

        public V GetValueByKey(K key)
        {
            int index = Array.IndexOf(this.keys, key);
            return (V)this.values[index];
        }

        public bool ContainsKey(K key)
        {
            return this.keys.Count<K?>(k => k==null) > 0;
        }

        public bool ContainsValue(V value)
        {
            return this.values.Count<V?>(v => v != null && v.Equals(value)) > 0;
        }

        public int Count()
        {
            return this.keys.Count(k => k!=null);
        }

        public V?[] GetAllValues()
        {
            return this.values.Where(v => v != null).ToArray<V?>();
        }

        public K?[] GetAllKeys()
        {
            return this.keys.Where(k => k!= null).ToArray<K?>();
        }

        public V this[K index]
        {
            get
            {
                // get the item for that index.
                return GetValueByKey(index);
            }
            set
            {
                // set the item for this index. value will be of type Thing.
                this.Add(index, value);
            }
        }

        // Реализация интерфейса IEnumerable
        public IEnumerator GetEnumerator()
        {
            return keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Уникальная функция для коллекции
        public void PrintAllKeyValuePairs()
        {
            Console.WriteLine("dict {");
            for (int i=0; i<this._len; i++)
            {
                if (this.keys[i] != null)
                {
                    Console.WriteLine($"    {this.keys[i]}:{this.values[i]}");
                }
            }
            Console.WriteLine("}");
        }
    }
}