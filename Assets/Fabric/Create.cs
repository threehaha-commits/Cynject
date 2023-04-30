using System.Collections.Generic;
using UnityEngine;

namespace Threehaha
{
    /// <summary>
    /// This class is responsible for simple create objects and inject them last components
    /// </summary>
    public static class Create
    {
        /// <summary>
        /// Simple analog Instantiate method with 1 param
        /// </summary>
        /// <param name="entity">What you want create</param>
        /// <returns>New object</returns>
        public static Object New(object entity)
        {
            var list = Container.Get();
            var newEntity = Object.Instantiate(entity as Object);
            AssignValuesToEntity(list, newEntity);
            return newEntity;
        }

        /// <summary>
        /// Simple analog Instantiate method with 3 param
        /// </summary>
        /// <param name="entity">What you want create</param>
        /// <param name="position">Where object will be located</param>
        /// <param name="rotation">What angle will be rotate</param>
        /// <returns>New object</returns>
        public static Object New(object entity, Vector3 position, Quaternion rotation)
        {
            var list = Container.Get();
            var newEntity = Object.Instantiate(entity as Object, position, rotation);
            AssignValuesToEntity(list, newEntity);
            return newEntity;
        }
        
        /// <summary>
        /// This find all field marked [Inject] and inject them last components
        /// </summary>
        /// <param name="list"></param>
        /// <param name="newEntity"></param>
        private static void AssignValuesToEntity(List<MonoBehaviour> list, Object newEntity)
        {
            foreach (var component in list)
                Bind.SetValueTo(component, newEntity);
        }
    }
}