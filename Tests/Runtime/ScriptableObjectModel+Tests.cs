using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using MartonioJunior.Test;

namespace Tests.MartonioJunior.Test
{
    // MARK: Mock Classes
    public class MockScriptableObject: ScriptableObject {}
    
    public class ScriptableObjectModel_Tests: ScriptableObjectModel<MockScriptableObject>
    {
        // MARK: Variables
        bool activatedValue;
        
        // MARK: Model Implementation
        public override void ConfigureValues()
        {
            activatedValue = true;
        }

        public override void DestroyTestContext()
        {
            activatedValue = false;
        }
        
        // MARK: Method Tests
        [Test]
        public void ConfigureValues_DefinesValuesForScriptableObject()
        {
            Assert.True(activatedValue);
        }
        
    }
}