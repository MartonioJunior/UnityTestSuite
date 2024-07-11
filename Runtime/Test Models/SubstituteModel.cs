using static MartonioJunior.Test.Suite;

namespace MartonioJunior.Test
{
    public partial class SubstituteModel<T> where T: class {}

    #region Model Implementation
    public partial class SubstituteModel<T>: Model<T>
    {
        public override void CreateTestContext()
        {
            modelReference = Substitute<T>();
        }

        public override void DestroyTestContext()
        {
            modelReference = null;
        }
    }
    #endregion
}