using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using MartonioJunior.Test;

namespace Tests.MartonioJunior.Test
{
    public class SubstituteModel_Tests: SubstituteModel<ICollection>
    {
        #region Variables
        bool triggeredContext;
        bool triggeredDestroy;
        #endregion
        #region Test Model Implementation
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
}