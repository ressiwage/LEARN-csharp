using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Linq;
using foresite;

namespace foresite
{
    class Node<K, V>
    {
        public K key;
        public V value;
        public Node(K key, V value)
        {
            this.key = key;
            this.value = value;
        }
    }
    public class KeyValueCollection<K, V> : IEnumerable where K: struct, IComparable where V: struct, IComparable
    {
        private Node<K, V>[] nodes = new Node<K, V>[2];
        private int _len = 2;
        public int nullcount = 2;

        private int ind(K key)
        {
            for (int i = 0; i < _len; i++)
            {
                if (this.nodes[i] != default && this.nodes[i].key.Equals(key))
                {
                    return i;
                }
            }
            return -1;
        }
        private int ind(V value)
        {
            for(int i = 0; i<_len; i++)
            {
                if (this.nodes[i]!=default && this.nodes[i].value.Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }

        private int indDef()
        {
            for (int i = 0; i < _len; i++)
            {
                if (this.nodes[i]==default)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Add(K key, V value)
        {
            int index = ind(key);
            if (index < 0)
            {
                if (this.nullcount == 0) { this.scale(); }
                
                int ind = indDef();
                this.nodes[ind] = new Node<K, V>(key, value);
                this.nullcount--;
                return true;

            }
            else
            {
                nodes[index].value = value;
                return false;
            }
        }

        private void scale()
        {
            this.nullcount += this._len * 2 - this._len;
            this._len *= 2;
            Array.Resize(ref this.nodes, this._len);
            
        }

        public V? Remove(K key) 
        {
            int index = ind(key);
            if (index < 0)
            {
                return null;
            }
            V returned = (V)this.nodes[index].value;
            this.nodes[index] = default;
            this.nullcount++;
            while (this.nullcount >= this._len/2)
            {
                Node<K, V>[] newNodes = new Node<K, V>[this._len/2];
                int i = 0;
                foreach (Node<K, V> node in this.nodes)
                {
                    if (node != default)
                    {
                        newNodes[i++] = node;
                    }
                }
                this.nodes = newNodes;
                this._len /= 2;
                this.nullcount -= this._len;
            }
        
            return returned;
            
        }

        public void Clear()
        {
            this.nodes = new Node<K, V>[2];
            this._len = 2;
            this.nullcount = 2;
    }

        public K GetKeyByValue(V value)
        {
            int index = ind(value);
            return (K)this.nodes[index].key;
        }

        public V GetValueByKey(K key)
        {
            int index = ind(key);
            return (V)this.nodes[index].value;
        }

        public bool ContainsKey(K key)
        {
            return ind(key)!=-1;
        }

        public bool ContainsValue(V value)
        {
            return ind(value)!=-1;
        }

        public int Count()
        {
            return this._len - this.nullcount;
        }

        public V[] GetAllValues()
        {
            V[] arr = new V[this._len - nullcount];
            int i = 0;
            foreach( Node<K,V> n in this.nodes)
            {
                if (n != default)
                {
                    arr[i] = n.value;
                    i++;
                }
            }
            return arr;
        }

        public K[] GetAllKeys()
        {
            K[] arr = new K[this._len - nullcount];
            int i = 0;
            foreach (Node<K, V> n in this.nodes)
            {
                if (n != default)
                {
                    arr[i] = n.key;
                    i++;
                }
            }
            return arr;
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
            return this.nodes.GetEnumerator();
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
                if (this.nodes[i] != default && !this.nodes[i].key.Equals( default))
                {
                    Console.WriteLine($"    {this.nodes[i].key}:{this.nodes[i].value}");
                }
            }
            Console.WriteLine("}");
        }
    }
}