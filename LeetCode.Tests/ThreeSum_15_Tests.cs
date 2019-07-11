﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Xunit;
using static LeetCode.Solutions.ThreeSum_15;

namespace LeetCode.Tests
{
    public class ThreeSum_15_Tests
    {
        [Theory]
        [InlineData("-1,0,1,2,-1,-4", "-1,0,1;-1,-1,2")]
        [InlineData("3,0,-2,-1,1,2", "3,-2,-1;0,-2,2;0,-1,1")]
        public void ThreeSum_Tests(string nums, string expected)
        {
            var n = nums.Split(",").Select(int.Parse).ToArray();
            var exp = expected.Split(";")
                    .Select(s => s.Split(",")
                    .Select(int.Parse)
                    .ToList())
                .ToList();

            var actual = ThreeSum(n);

            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
            Assert.Equal(exp.Count, actual.Count);

            var actualOrdered = actual.Select(t => t.OrderBy(li => li).ToList()).OrderBy(l => l[0]).ToList();
            var expOrdered = exp.Select(t => t.OrderBy(li => li).ToList()).OrderBy(l => l[0]).ToList();

            for (var i = 0; i < exp.Count; ++i)
            {
                Assert.True(expOrdered[i].SequenceEqual(actualOrdered[i]));
            }
        }
        [Theory]
        [InlineData("-1,0,1,2,-1,-4", 50)]
        [InlineData("13,5,-4,-9,1,-3,10,-7,7,3,1,-13,-11,7,-10,12,-15,13,5,-8,-11," +
                    "-12,-15,-13,-3,-13,5,-4,6,1,-10,4,13,-7,3,-9,-3,-2,-1,12,9,-15," +
                    "14,5,0,-10,-5,-8,-12,-15,-1,-8,11,-9,-14,-7,-6,7,-4,-15,-15,-7," +
                    "-4,14,1,6,12,14,12,-11,11,-2,11,2,-12,-4,7,-2,-5,10,-9,10,9,-13," +
                    "-14,11,-13,-13,3,-1,9,3,7,-9,-6,-14,4,-8,7,1,-12,-5,14,14,12,10," +
                    "-12,-3,-7,-2,-8,-9,-7,9,-7,-13,5,-12,-11,-7,2,14,3,-14", 100)]
        public async Task ThreeSum_Perf_Tests(string nums, int maxMilliseconds)
        {
            var n = nums.Split(",").Select(int.Parse).ToArray();

            IList<IList<int>> actual = null;
            var sw = new Stopwatch();
            var actualTask = Task.Run(() =>
            {
                sw.Start();
                actual = ThreeSum(n);
                sw.Stop();
            });
            var delayTask = Task.Delay(maxMilliseconds, new CancellationToken());
            var completedTask = await Task.WhenAny(actualTask, delayTask);

            Assert.True(completedTask.Id== actualTask.Id,
                        $"Elapsed time (ms): '{sw.ElapsedMilliseconds}'");
            Assert.NotNull(actual);
        }
    }
}
