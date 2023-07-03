using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace MartonioJunior.Test
{
    public static partial class Suite
    {
        #region Constants (Messages)
        public const string ComponentEmptyInitialization = "COMPONENT INITIALIZED WITHOUT PARAMETERS";
        public const string IncompleteImplementation = "INCOMPLETE TEST";
        public const string NotImplemented = "TEST NOT IMPLEMENTED";
        public const string CannotBeTested = "METHOD CANNOT BE COVERED BY UNIT TESTS";
        #endregion
        #region Static Methods
        public static T[] Array<T>(int size, Func<int, T> generator)
        {
            if (size <= 0 || generator is null) return new T[0];

            var result = new T[size];

            for (int i = 0; i < size; i++) {
                result[i] = generator.Invoke(i);
            }

            return result;
        }

        public static T[] Array<T>(int size, Func<T> generator)
        {
            if (generator is null) return new T[0];

            return Array(size, _ => generator());
        }

        public static T[,] Array2D<T>(int width, int height, Func<int, int, T> generator)
        {
            if (width <= 0 || height <= 0 || generator is null) return new T[0,0];

            var result = new T[width, height];

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    result[x,y] = generator.Invoke(x,y);
                }
            }

            return result;
        }

        public static T[,] Array2D<T>(int width, int height, Func<T> generator)
        {
            if (generator is null) return new T[0,0];

            return Array2D(width, height, (_, _) => generator());
        }

        public static void AssertAll<T>(IEnumerable<T> enumerable, Action<T> assertion)
        {
            foreach (var item in enumerable) {
                assertion(item);
            }
        }

        public static object[] Case(params object[] items)
        {
            return items;
        }

        public static IEnumerable<T> Case<T>(params object[] items)
        {
            return items.Select(x => (T)x);
        }

        public static Predicate<T> FixedPredicate<T>(bool result)
        {
            return _ => result;
        }

        public static int Range(int minInclusive, int maxInclusive, int defaultValue, bool fixedRandom = false)
        {
            if (fixedRandom) return defaultValue;
            else return Random.Range(minInclusive, maxInclusive);
        }

        public static T Substitute<T>() where T: class
        {
            return NSubstitute.Substitute.For<T>();
        }

        public static T Substitute<T>(out T output) where T: class
        {
            output = Substitute<T>();
            return output;
        }

        public static T Set<T>(this T value, out T output)
        {
            output = value;
            return value;
        }
        #endregion
    }
}