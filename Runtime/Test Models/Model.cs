using System;
using NSubstitute;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace MartonioJunior.Test
{
    public abstract class Model
    {
        #region Abstract
        public abstract void CreateTestContext();
        public abstract void DestroyTestContext();
        #endregion
        #region Methods
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
        #endregion
    }

    public abstract class Model<T>: Model
    {
        #region Variables
        protected T modelReference;
        #endregion
    }
}