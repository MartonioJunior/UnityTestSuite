using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace MartonioJunior.Test
{
    public static partial class Mock
    {
        // MARK: Variables
        private static readonly List<Object> objectList = new();
        public static int Count => objectList.Count;
        
        // MARK: Static Methods
        public static void Clear()
        {
            objectList.ForEach(Object.DestroyImmediate);
            objectList.Clear();
        }

        public static void Register(Object obj)
        {
            if (obj is null) return;

            objectList.Add(obj);
        }
        
    }
}