using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using MartonioJunior.Test;

namespace Tests.MartonioJunior.Test
{
    public class Model_Tests: Model
    {
        #region Variables
        bool triggeredContext;
        bool triggeredDestroy;
        #endregion
        #region Model Implementation
        public override void CreateTestContext()
        {
            triggeredContext = true;
            triggeredDestroy = false;
        }

        public override void DestroyTestContext()
        {
            triggeredContext = false;
            triggeredDestroy = true;
        }
        #endregion
        #region Method Tests
        [Test]
        public void Setup_CreatesTestContext()
        {
            Assert.True(triggeredContext);
            Assert.False(triggeredDestroy);
        }

        [Test]
        public void TearDown_DestroysTestContext()
        {
            TearDown();

            Assert.False(triggeredContext);
            Assert.True(triggeredDestroy);
        }
        #endregion
    }

    public class Generic_Model_Tests: Model<int>
    {
        #region Model Implementation
        public override void CreateTestContext() {}
        public override void DestroyTestContext() {}
        #endregion
        #region Method Tests
        [Test]
        public void ModelReference_IsVariableUsedForModel()
        {
            Assert.AreEqual(default(int), modelReference);
            Assert.IsInstanceOf<int>(modelReference);
        }
        #endregion
    }
}