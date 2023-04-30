using System.Collections.Generic;
using UnityEngine;

namespace Threehaha
{
    /// <summary>
    /// Returns an inactive array element. If there are no inactive items, then creates and returns a new one
    /// </summary>
    /// <typeparam name="T">Object</typeparam>
    public class Pool<T> where T : MonoBehaviour
    {
        private readonly Queue<T> _items = new();
        private readonly T _item;
        
        /// <summary>
        /// The item that the pool will work with
        /// </summary>
        public Pool(T item)
        {
            _item = item;
        }
        
        /// <summary>
        /// Return item from pool
        /// </summary>
        public T Get()
        {
            var newItem = FindItem();
            return newItem;
        }

        /// <summary>
        /// Returns an inactive item. If there is no such, then creates and returns a new one
        /// </summary>
        private T FindItem()
        {
            //if pool is empty
            if (PoolIsClear())
                return CreateNewItem();

            List<T> items = new List<T>(_items);
            var item = items.Find(x => x.gameObject.activeInHierarchy == false);
            
            //if there are no inactive items
            if (item == null)
                return CreateNewItem();
            
            item.gameObject.SetActive(true);
            //found item
            return item;
        }

        private bool PoolIsClear()
        {
            return _items.Count == 0;
        }

        //Create new item
        private T CreateNewItem()
        {
            var newItem = Object.Instantiate(_item);
            _items.Enqueue(newItem);
            return _items.Peek();
        }
    }
}