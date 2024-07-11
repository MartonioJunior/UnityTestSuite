using System;
using Unity.PerformanceTesting;
using Unity.PerformanceTesting.Measurements;

namespace MartonioJunior.Test
{
    public static partial class Suite
    {
        // MARK: Methods
        public static void Sample(Action action)
        {
            using (Measure.Scope()) {
                action();
            }
        }

        public static void Sample(string name, Action action, SampleUnit unit = SampleUnit.Millisecond)
        {
            var sampleGroup = new SampleGroup(name, unit);
            using (Measure.Scope(sampleGroup)) {
                action();
            }
        }

        public static void Sample(string name, double value) => Measure.Custom(name, value);
        public static FramesMeasurement SampleFPS() => Measure.Frames();
        public static MethodMeasurement SampleMethod(Action action) => Measure.Method(action);

    }
}