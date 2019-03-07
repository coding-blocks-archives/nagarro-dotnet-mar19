using System;
using System.Collections.Generic;
using System.Text;

namespace nagarro_dotNet_mar19
{
    namespace datastructures
    {
        class HashTable
        {
            private List<LinkedList<KeyValuePair<string, string>>> table;
            private int nelements;
            private int capacity;

            public HashTable()
            {
                capacity = 1;
                nelements = 0;
                table = new List<LinkedList<KeyValuePair<string, string>>>(capacity);
                // TODO
                for (int i = 0; i < capacity; ++i)
                {
                    table.Add(new LinkedList<KeyValuePair<string, string>>());
                }
            }

            private int hashcode(string key)
            {
                const int MUL = 31;
                int pow = 1;
                int result = 0;
                for (int i = 0; i < key.Length; ++i)
                {
                    pow *= MUL;
                    pow %= capacity;
                    int ascii = key[i] % capacity;
                    int prod = (ascii * pow) % capacity;
                    result += prod;
                    result %= capacity;
                }
                return result;
            }

            public void add(string key, string value)
            {
                int idx = hashcode(key);
                var bucket = table[idx];
                var pairToInsert = new KeyValuePair<string, string>(key, value);
                bucket.AddFirst(pairToInsert);
                ++nelements;

                if (LoadFactor() > 0.7) rehash();
            }

            private double LoadFactor()
            {
                return (double)nelements / capacity;
            }

            private void rehash()
            {
                Console.WriteLine("Rehashing..");
                List<LinkedList<KeyValuePair<string, string>>> oldTable = table;
                int oldCapacity = capacity;
                capacity = 2 * oldCapacity;

                table = new List<LinkedList<KeyValuePair<string, string>>>(capacity);
                // TODO avoid copying;convert to func
                for (int i = 0; i < capacity; ++i)
                {
                    table.Add(new LinkedList<KeyValuePair<string, string>>());
                }

                foreach (var bucket in oldTable)
                {
                    foreach (var node in bucket)
                    {
                        // TODO try to do without copying
                        this.add(node.Key, node.Value);
                    }
                }
            }

            public void remove(string key)
            {
                int idx = hashcode(key);
                var bucket = table[idx];
                foreach (KeyValuePair<string, string> kvp in bucket)
                {
                    // TODO iterators
                    if (kvp.Key == key)
                    {
                        bucket.Remove(kvp);
                        --nelements;
                        return;
                    }
                }
            }

            public string Find(string key)
            {
                int idx = hashcode(key);
                var bucket = table[idx];
                foreach (KeyValuePair<string, string> kvp in bucket)
                {
                    // TODO iterators
                    if (kvp.Key == key)
                    {
                        return kvp.Value;
                    }
                }
                return null;
            }
        }

        public class Hashing
        {
            public static void main()
            {
                HashTable map = new HashTable();
                map.add("Shankey", "888");
                map.add("Sharnya", "999");
                map.add("Sharmaji", "777");
                Console.WriteLine(map.Find("Shankey"));
                map.remove("Shankey");
                Console.WriteLine(map.Find("Shankey"));
            }
        }
    }
}
