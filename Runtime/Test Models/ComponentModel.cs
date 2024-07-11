using UnityEngine;

namespace MartonioJunior.Test
{
    public abstract partial class ComponentModel<T> where T: MonoBehaviour
    {
        // MARK: Abstract
        public abstract void ConfigureValues();
    }

    #region Model Implementation
    public partial class ComponentModel<T>: Model<T>
    {
        public override void CreateTestContext()
        {
            modelReference = Mock.GameObject($"{typeof(T)}").AddComponent<T>();
            ConfigureValues();
        }

        public override void DestroyTestContext()
        {
            modelReference = null;
        }
    }
    #endregion
}