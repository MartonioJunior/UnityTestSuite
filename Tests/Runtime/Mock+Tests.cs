using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using MartonioJunior.Test;

namespace Tests.MartonioJunior.Test
{
    public class Mock_Tests: Model
    {
        #region Model Implementation
        public override void CreateTestContext() {}
        public override void DestroyTestContext() {}
        #endregion
        #region Method Tests
        [Test]
        public void Clear_RemovesAllRegisteredObjects()
        {
            Mock.Register(NSubstitute.Substitute.For<ScriptableObject>());

            Mock.Clear();

            Assert.Zero(Mock.Count);
        }

        [Test]
        public void Register_AddsItemsToObjectList()
        {
            Mock.Register(NSubstitute.Substitute.For<ScriptableObject>());

            Assert.AreEqual(1, Mock.Count);
        }

        public static IEnumerable GameObject_UseCases()
        {
            yield return new object[2]{"Item", "Item-Mock"};
            yield return new object[2]{string.Empty, "-Mock"};
            yield return new object[2]{null, "-Mock"};
        }
        [TestCaseSource(nameof(GameObject_UseCases))]
        public void GameObject_CreatesGameObjectForMocking(string input, string output)
        {
            var result = Mock.GameObject(input);

            Assert.IsInstanceOf<GameObject>(result);
            Assert.AreEqual(output, result.name);
            Assert.AreEqual(1, Mock.Count);
        }

        [Test]
        public void ScriptableObject_CreatesScriptableObjectForMocking()
        {
            var result = Mock.ScriptableObject<MockScriptableObject>();

            Assert.IsInstanceOf<MockScriptableObject>(result);
            Assert.AreEqual(1, Mock.Count);
        }

        [Test]
        public void ScriptableObject_out_CreatesScriptableObjectForMocking()
        {
            Mock.ScriptableObject(out MockScriptableObject variable);

            Assert.IsInstanceOf<MockScriptableObject>(variable);
            Assert.AreEqual(1, Mock.Count);
        }

        [Test]
        public void Sprite_CreatesSpriteForMocking()
        {
            var result = Mock.Sprite();

            Assert.IsInstanceOf<Sprite>(result);
            Assert.AreEqual(Texture2D.grayTexture, result.texture);
            Assert.AreEqual(new Rect(), result.rect);
            Assert.AreEqual(Vector2.zero, result.pivot);
            Assert.AreEqual(1, Mock.Count);
        }
        #endregion
    }
}