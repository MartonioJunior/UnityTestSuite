using UnityEngine;

namespace MartonioJunior.Test
{
    public abstract partial class ScriptableObjectModel<T> where T: ScriptableObject
    {
        // MARK: Abstract
        public abstract void ConfigureValues();
    }

    #region Model Implementation
    public partial class ScriptableObjectModel<T>: Model<T>
    {
        public override void CreateTestContext()
        {
            modelReference = Mock.ScriptableObject<T>();
            ConfigureValues();
        }

        public override void DestroyTestContext()
        {
            modelReference = null;
        }
    }
    #endregion
}