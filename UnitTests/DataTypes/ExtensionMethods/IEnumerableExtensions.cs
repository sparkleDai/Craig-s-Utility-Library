﻿/*
Copyright (c) 2011 <a href="http://www.gutgames.com">James Craig</a>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoonUnit;
using MoonUnit.Attributes;
using Utilities.DataTypes.ExtensionMethods;
using System.Data;

namespace UnitTests.DataTypes.ExtensionMethods
{
    public class IEnumerableExtensions
    {
        [Test]
        public void IsNullOrEmptyTest()
        {
            List<int> Temp = new List<int>();
            Assert.True(Temp.IsNullOrEmpty());
            Temp = null;
            Assert.True(Temp.IsNullOrEmpty());
            Temp = new int[] { 1, 2, 3 }.ToList();
            Assert.False(Temp.IsNullOrEmpty());
        }

        [Test]
        public void RemoveDefaultsTest()
        {
            List<int> Temp = new int[] { 0,0,1, 2, 3 }.ToList();
            foreach (int Value in Temp.RemoveDefaults())
                Assert.NotEqual(0, Value);
        }

        [Test]
        public void ForEachTest()
        {
            StringBuilder Builder=new StringBuilder();
            int[] Temp = new int[] { 0, 0, 1, 2, 3 };
            Temp.ForEach(x => Builder.Append(x));
            Assert.Equal("00123", Builder.ToString());
        }

        [Test]
        public void ToArray()
        {
            List<int> Temp = new int[] { 0, 0, 1, 2, 3 }.ToList();
            Assert.DoesNotThrow<Exception>(() => Temp.ToArray<int, double>(x => (double)x));
            double[] Temp2 = Temp.ToArray<int, double>(x => (double)x);
            Assert.Equal(0, Temp2[0]);
            Assert.Equal(0, Temp2[1]);
            Assert.Equal(1, Temp2[2]);
            Assert.Equal(2, Temp2[3]);
            Assert.Equal(3, Temp2[4]);
        }

        [Test]
        public void ToStringTest()
        {
            List<int> Temp = new int[] { 0, 0, 1, 2, 3 }.ToList();
            Assert.Equal("0,0,1,2,3", Temp.ToString(","));
            Assert.NotEqual("0,0,1,2,3", Temp.ToString());
        }

        [Test]
        public void TrueForEach()
        {
            IEnumerable<int> Temp = new int[] { 0, 0, 1, 2, 3 }.ToList();
            Assert.True(Temp.TrueForAll(x => x < 4));
        }
    }
}