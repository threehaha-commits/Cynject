using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class Interface
    {
        [MenuItem("Cinject/Initialize")]
        public static void Initialize()
        {
            var init = Object.FindAnyObjectByType<CynjectInitialize>();
            if(init == null)
                CreateInitializer();
            else
                Debug.LogError("The Initializer has already been created. There cannot be more than one such object on the stage");
        }

        private static void CreateInitializer()
        {
            var initializer = Resources.Load("CynjectInitializer");
            var newInit = Object.Instantiate(initializer);
            newInit.name = initializer.name;
        }
    }
}