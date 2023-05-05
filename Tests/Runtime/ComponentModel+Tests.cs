using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using MartonioJunior.Test;

namespace Tests.MartonioJunior.Test
{
    #region Mock Classes
    public class MockBehaviour: MonoBehaviour {}
    #endregion
    public class ComponentModel_Tests: ComponentModel<MockBehaviour>
    {
        #region Variables
        bool activatedValue;
        #endregion
        #region Model Implementation
        public override void ConfigureValues()
        {
            activatedValue = true;
        }

        public override void DestroyTestContext()
        {
            activatedValue = false;
        }
        #endregion
        #region Method Tests
        [Test]
        public void ConfigureValues_DefinesValuesForComponent()
        {
            Assert.True(activatedValue);
        }
        #endregion
    }
}