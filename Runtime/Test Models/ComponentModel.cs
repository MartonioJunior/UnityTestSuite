using UnityEngine;

namespace MartonioJunior.Test
{
    public abstract class ComponentModel<T>: Model<T> where T: MonoBehaviour
    {
        #region Abstract
        public abstract void ConfigureValues();
        #endregion
        #region TestModel Implementation
        public override void CreateTestContext()
        {
            modelReference = Mock.GameObject($"{typeof(T)}").AddComponent<T>();
            ConfigureValues();
        }

        public override void DestroyTestContext()
        {
            modelReference = null;
        }
        #endregion
    }
}