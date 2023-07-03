using UnityEngine;
using static MartonioJunior.Test.Suite;

namespace MartonioJunior.Test
{
    public partial class SubstituteModel<T> : Model<T> where T: class
    {
        #region Model Implementation
        public override void CreateTestContext()
        {
            modelReference = Substitute<T>();
        }

        public override void DestroyTestContext()
        {
            modelReference = null;
        }
        #endregion
    }
}