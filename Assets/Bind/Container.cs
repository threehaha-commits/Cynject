using System.Collections.Generic;
using UnityEngine;

namespace Threehaha
{
    public static class Container
    {
        private static readonly List<MonoBehaviour> _list = new();

        /// <summary>
        /// Must be call in start game
        /// </summary>
        public static void Clear()
        {
            _list.Clear();
        }

        /// <summary>
        /// Added component to array list. It is need for keep components for future injecting
        /// </summary>
        /// <param name="mono">Keeping component</param>
        public static void Add(object mono)
        {
            if (NotContainsThe(mono as MonoBehaviour))
                _list.Add(mono as MonoBehaviour);
        }

        /// <summary>
        /// Return array list with keeping components 
        /// </summary>
        public static List<MonoBehaviour> Get()
        {
            return _list;
        }

        /// <summary>
        /// Check contains component in array list
        /// </summary>
        private static bool NotContainsThe(MonoBehaviour mono)
        {
            return !_list.Contains(mono);
        }
    }
}