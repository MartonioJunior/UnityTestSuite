using System.Collections;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace MartonioJunior.Test
{
    // Reference: https://gist.github.com/adammyhre/20d3c47f83032c6ca938b92edc175a35
    public partial class LoadSceneAttribute
    {
        // MARK: Variables
        readonly string scene;

        // MARK: Initializers
        public LoadSceneAttribute(string scene) => this.scene = scene;
    }

    #region NUnitAttribute Implementation
    public partial class LoadSceneAttribute: NUnitAttribute {}
    #endregion

    #region IOuterUnityTestAction Implementation
    public partial class LoadSceneAttribute: IOuterUnityTestAction
    {
        public IEnumerator BeforeTest(ITest test)
        {
            Debug.Assert(scene.EndsWith(".unity"), "Scene must end with .unity");
            yield return EditorSceneManager.LoadSceneInPlayMode(scene, new LoadSceneParameters(LoadSceneMode.Single));
        }

        public IEnumerator AfterTest(ITest test)
        {
            yield return null;
        }
    }
    #endregion
}