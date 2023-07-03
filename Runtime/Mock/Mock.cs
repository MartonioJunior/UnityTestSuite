using UnityEngine;
using System.Collections.Generic;
using NSubstitute;
using System.Collections;
using System;
using Object = UnityEngine.Object;

namespace MartonioJunior.Test
{
    public static partial class Mock
    {
        #region Variables
        private static readonly List<Object> objectList = new();
        public static int Count => objectList.Count;
        #endregion
        #region Static Methods
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
        #endregion
    }
}