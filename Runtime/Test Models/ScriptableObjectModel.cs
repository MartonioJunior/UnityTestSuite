using UnityEngine;

namespace MartonioJunior.Test
{
    public abstract class ScriptableObjectModel<T>: Model<T> where T: ScriptableObject
    {
        #region Abstract Implementation
        public abstract void ConfigureValues();
        #endregion
        #region Model Implementation
        public override void CreateTestContext()
        {
            modelReference = Mock.ScriptableObject<T>();
            ConfigureValues();
        }

        public override void DestroyTestContext()
        {
            modelReference = null;
        }
        #endregion
    }
}