using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using MartonioJunior.Test;
using Random = UnityEngine.Random;
using Unity.PerformanceTesting.Measurements;

namespace Tests.MartonioJunior.Test
{
    public class Suite_Tests: Model
    {
        // MARK: Model Implementation
        public override void CreateTestContext() {}
        public override void DestroyTestContext() {}
        
        // MARK: Method Tests
        public static IEnumerable Array_Index_UseCases()
        {
            var referenceValue = Random.Range(1,10);
            Func<int, int> validGenerator = i => i;
            var resultArray = new List<int>();

            yield return new object[3]{referenceValue, null, resultArray.ToArray()};
            yield return new object[3]{0, validGenerator, resultArray.ToArray()};
            yield return new object[3]{-referenceValue, validGenerator, resultArray.ToArray()};

            for(int i = 0; i < referenceValue; i++) resultArray.Add(i);
            yield return new object[3]{referenceValue, validGenerator, resultArray.ToArray()};
        }
        [TestCaseSource(nameof(Array_Index_UseCases))]
        public void Array_Index_UsesFunctionToGenerateArrayBasedOnIndex(int size, Func<int, int> generator, int[] output)
        {
            int[] result = Suite.Array(size, generator);

            CollectionAssert.AreEquivalent(output, result);
        }

        public static IEnumerable Array_NoIndex_UseCases()
        {
            var referenceValue = Random.Range(1,10);
            Func<int> validGenerator = () => referenceValue;
            var resultArray = new List<int>();

            yield return new object[3]{referenceValue, null, resultArray.ToArray()};
            yield return new object[3]{0, validGenerator, resultArray.ToArray()};
            yield return new object[3]{-referenceValue, validGenerator, resultArray.ToArray()};

            for(int i = 0; i < referenceValue; i++) resultArray.Add(referenceValue);
            yield return new object[3]{referenceValue, validGenerator, resultArray.ToArray()};
        }
        [TestCaseSource(nameof(Array_NoIndex_UseCases))]
        public void Array_NoIndex_Behaviour(int size, Func<int> generator, int[] output)
        {
            int[] result = Suite.Array(size, generator);

            CollectionAssert.AreEquivalent(output, result);
        }

        public static IEnumerable Array2D_Index_UseCases()
        {
            var referenceWidth = Random.Range(1,10);
            var referenceHeight = Random.Range(1,10);
            Func<int,int,int> validGenerator = (x, y) => x+y;
            var emptyArray = new int[0,0];

            yield return new object[4]{referenceWidth, referenceHeight, null, emptyArray};
            yield return new object[4]{0, referenceHeight, validGenerator, emptyArray};
            yield return new object[4]{referenceWidth, 0, validGenerator, emptyArray};
            yield return new object[4]{-referenceWidth, referenceHeight, null, emptyArray};
            yield return new object[4]{referenceWidth, -referenceHeight, null, emptyArray};
            yield return new object[4]{-referenceWidth, -referenceHeight, null, emptyArray};

            var baseArray = new int[referenceWidth,referenceHeight];
            for(int i = 0; i < referenceWidth; i++) {
                for(int j = 0; j < referenceHeight; j++) baseArray[i,j] = i+j;
            }
            yield return new object[4]{referenceWidth, referenceHeight, validGenerator, baseArray};
        }
        [TestCaseSource(nameof(Array2D_Index_UseCases))]
        public void Array2D_Index_Generates2DArrayBasedOnIndex(int width, int height, Func<int, int, int> generator, int[,] output)
        {
            int[,] result = Suite.Array2D(width, height, generator);

            CollectionAssert.AreEquivalent(output, result);
        }

        public static IEnumerable Array2D_NoIndex_UseCases()
        {
            var referenceWidth = Random.Range(1,10);
            var referenceHeight = Random.Range(1,10);
            Func<int> validGenerator = () => referenceWidth;
            var emptyArray = new int[0,0];

            yield return new object[4]{referenceWidth, referenceHeight, null, emptyArray};
            yield return new object[4]{0, referenceHeight, validGenerator, emptyArray};
            yield return new object[4]{referenceWidth, 0, validGenerator, emptyArray};
            yield return new object[4]{-referenceWidth, referenceHeight, null, emptyArray};
            yield return new object[4]{referenceWidth, -referenceHeight, null, emptyArray};
            yield return new object[4]{-referenceWidth, -referenceHeight, null, emptyArray};

            var baseArray = new int[referenceWidth,referenceHeight];
            for(int i = 0; i < referenceWidth; i++) {
                for(int j = 0; j < referenceHeight; j++) baseArray[i,j] = referenceWidth;
            }
            yield return new object[4]{referenceWidth, referenceHeight, validGenerator, baseArray};
        }
        [TestCaseSource(nameof(Array2D_NoIndex_UseCases))]
        public void Array2D_NoIndex_Generates2DArrayBasedOnIndex(int width, int height, Func<int> generator, int[,] output)
        {
            int[,] result = Suite.Array2D(width, height, generator);

            CollectionAssert.AreEquivalent(output, result);
        }

        public static IEnumerable FixedPredicate_UseCases()
        {
            yield return new object[2]{false, false};
            yield return new object[2]{true, true};
        }
        [TestCaseSource(nameof(FixedPredicate_UseCases))]
        public void FixedPredicate_CreatesPredicateWithFixedResult(bool input, bool output)
        {
            var predicate = Suite.FixedPredicate<int>(input);

            Assert.AreEqual(output, predicate(Random.Range(-10000,10000)));
        }

        public static IEnumerable Range_UseCases()
        {
            var min = Random.Range(0,10);
            var max = Random.Range(min, 15);
            var defaultValue = Random.Range(1,10);

            yield return new object[6]{min, max, defaultValue, false, min, max};
            yield return new object[6]{min, min, defaultValue, false, min, min};
            yield return new object[6]{max, min, defaultValue, false, min, max};
            yield return new object[6]{min, max, defaultValue, true, defaultValue, defaultValue};
        }
        [TestCaseSource(nameof(Range_UseCases))]
        public void Range_ControlsRandomizationWithNumbers(int min, int max, int defaultValue, bool fixedRandom, int minOutput, int maxOutput)
        {
            var result = Suite.Range(min, max, defaultValue, fixedRandom);

            Assert.GreaterOrEqual(result, minOutput);
            Assert.LessOrEqual(result, maxOutput);
        }

        public static IEnumerable Set_UseCases()
        {
            var value = Random.Range(-10000,10000);

            yield return new object[2]{value, value};
        }
        [TestCaseSource(nameof(Set_UseCases))]
        public void Set_DefinesVariableWithValue(int input, int output)
        {
            var result = input.Set(out int variable);

            Assert.AreEqual(result, output);
            Assert.AreEqual(variable, output);
        }
        
        // MARK: Suite+Benchmarks
        [Test]
        public void Sample_NoName_RunsActionInsideSampleScope()
        {
            Assert.Pass(Suite.CannotBeTested);
        }

        [Test]
        public void Sample_Name_RunsActionInsideSampleGroup()
        {
            Assert.Pass(Suite.CannotBeTested);
        }

        [Test]
        public void SampleFPS_CapturesFrameData()
        {
            var result = Suite.SampleFPS();

            Assert.IsInstanceOf<FramesMeasurement>(result);
        }

        [Test]
        public void SampleMethod_CapturesMethodData()
        {
            static void Nothing() {}
            var result = Suite.SampleMethod(Nothing);

            Assert.IsInstanceOf<MethodMeasurement>(result);
        }
        
    }
}