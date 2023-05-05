using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using MartonioJunior.Test;

namespace Tests.MartonioJunior.Test
{
    #region Mock Classes
    public class MockScriptableObject: ScriptableObject {}
    #endregion
    public class ScriptableObjectModel_Tests: ScriptableObjectModel<MockScriptableObject>
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
        public void ConfigureValues_DefinesValuesForScriptableObject()
        {
            Assert.True(activatedValue);
        }
        #endregion
    }
}