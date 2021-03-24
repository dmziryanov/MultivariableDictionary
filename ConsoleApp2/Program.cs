using Quartz;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    public class MultivariableDictionary<K, V> : IMultivariableDictionary<K, V>,  IEnumerable<V>
    {
        private Dictionary<K, HashSet<V>> storage = new Dictionary<K, HashSet<V>>();
        
        public void Add(K key, V value)
        {
            HashSet<V> values;
            if (storage.TryGetValue(key, out values))
            {
                values.Add(value);
            }
            else
            {
                var h = new HashSet<V>();
                h.Add(value);
                storage.Add(key, h);
            }
        }

        public IEnumerable<V> Get(K key)
        {
            if (storage.TryGetValue(key, out var values))
            {
                return values;
            }

            return null;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var el in storage)
                foreach (V v in el.Value)
                    yield return v;
        }

        IEnumerator<V> IEnumerable<V>.GetEnumerator()
        {
            foreach (var el in storage)
                foreach (V v in el.Value)
                    yield return v;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var mv = new MultivariableDictionary<string, string>();

            mv.Add("a", "b");
            mv.Add("a", "c");
            mv.Add("a", "c");

            foreach (var el in mv)
            {
                Console.WriteLine(el);
            }

            Console.WriteLine(mv.Count());
            Console.WriteLine(mv.Get("a"));
        }
    }

    public interface IMultivariableDictionary<K, V>
    {
        void Add(K key, V value);
        IEnumerable<V> Get(K key);
    }
}
