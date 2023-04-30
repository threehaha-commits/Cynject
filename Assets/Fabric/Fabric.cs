using System.Collections.Generic;
using UnityEngine;

namespace Threehaha
{
    /// <summary>
    /// Simple fabric
    /// </summary>
    public class Fabric<T> where T : MonoBehaviour
    {
        private Pool<T> _pool;

        public Fabric(T type)
        {
            _pool = new Pool<T>(type);
        }
        
        /// <summary>
        /// Create new object and inject him last components
        /// </summary>
        /// <param name="entity">What you want create</param>
        /// <returns>New object</returns>
        public Object Create(object entity)
        {
            var list = Container.Get();
            var newEntity = _pool.Get();
            AssignValuesToEntity(list, newEntity);
            return newEntity;
        }
        
        /// <summary>
        /// This find all field marked [Inject] and inject them last components
        /// </summary>
        /// <param name="list"></param>
        /// <param name="newEntity"></param>
        private void AssignValuesToEntity(List<MonoBehaviour> list, Object newEntity)
        {
            foreach (var component in list)
                Bind.SetValueTo(component, newEntity);
        }
    }
}