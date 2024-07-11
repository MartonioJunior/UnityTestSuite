using NUnit.Framework;

namespace MartonioJunior.Test
{
    public abstract class Model
    {
        // MARK: Abstract
        public abstract void CreateTestContext();
        public abstract void DestroyTestContext();
        
        // MARK: Methods
        [SetUp]
        public void Setup()
        {
            CreateTestContext();
        }

        [TearDown]
        public void TearDown()
        {
            DestroyTestContext();
            Mock.Clear();
        }
        
    }

    #region Model<T>
    public abstract class Model<T>: Model
    {
        // MARK: Variables
        protected T modelReference;
    }
    #endregion
}