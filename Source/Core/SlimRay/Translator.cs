using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay
{
    /// <summary>
    /// Translate one type to another.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class Translator<T1, T2>
    {
        private Dictionary<T1, T2> _pairs12;
        private Dictionary<T2, T1> _pairs21;

        public Translator()
        {
            _pairs12 = new Dictionary<T1, T2>();
            _pairs21 = new Dictionary<T2, T1>();
        }

        public void Remove(T1 value)
        {
            if (!_pairs12.ContainsKey(value))
            {
                return;
            }

            T2 key2 = _pairs12[value];

            _pairs21.Remove(key2);
            _pairs12.Remove(value);
        }

        public void Clear()
        {
            _pairs12.Clear();
            _pairs21.Clear();
        }

        public void Pair(T1 v1, T2 v2)
        {
            _pairs12.Add(v1, v2);
            _pairs21.Add(v2, v1);
        }

        public T1 Translate(T2 v)
        {
            return _pairs21[v];
        }

        public T2 Translate(T1 v)
        {
            return _pairs12[v];
        }
    }
}
