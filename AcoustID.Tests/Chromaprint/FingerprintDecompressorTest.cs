﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AcoustID.Chromaprint;
using AcoustID.Util;

namespace AcoustID.Tests.Chromaprint
{
    [TestClass]
    public class FingerprintDecompressorTest
    {
        [TestMethod]
        public void TestOneItemOneBit()
        {
            int[] expected = { 1 };
            byte[] data = { 0, 0, 0, 1, 1 };

            FingerprintDecompressor decompressor = new FingerprintDecompressor();

            int algorithm = -1;
            int[] actual = decompressor.Decompress(Base64.ByteEncoding.GetString(data), ref algorithm);
            Assert.AreEqual(0, algorithm);
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestOneItemThreeBits()
        {
            int[] expected = { 7 };
            byte[] data = { 0, 0, 0, 1, 73, 0 };

            FingerprintDecompressor decompressor = new FingerprintDecompressor();

            int algorithm = -1;
            int[] actual = decompressor.Decompress(Base64.ByteEncoding.GetString(data), ref algorithm);
            Assert.AreEqual(0, algorithm);
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestOneItemOneBitExcept()
        {
            int[] expected = { 1 << 6 };
            byte[] data = { 0, 0, 0, 1, 7, 0 };

            FingerprintDecompressor decompressor = new FingerprintDecompressor();

            int algorithm = -1;
            int[] actual = decompressor.Decompress(Base64.ByteEncoding.GetString(data), ref algorithm);
            Assert.AreEqual(0, algorithm);
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestOneItemOneBitExcept2()
        {
            int[] expected = { 1 << 8 };
            byte[] data = { 0, 0, 0, 1, 7, 2 };

            FingerprintDecompressor decompressor = new FingerprintDecompressor();

            int algorithm = -1;
            int[] actual = decompressor.Decompress(Base64.ByteEncoding.GetString(data), ref algorithm);
            Assert.AreEqual(0, algorithm);
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestTwoItems()
        {
            int[] expected = { 1, 0 };
            byte[] data = { 0, 0, 0, 2, 65, 0 };

            FingerprintDecompressor decompressor = new FingerprintDecompressor();

            int algorithm = -1;
            int[] actual = decompressor.Decompress(Base64.ByteEncoding.GetString(data), ref algorithm);
            Assert.AreEqual(0, algorithm);
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestTwoItemsNoChange()
        {
            int[] expected = { 1, 1 };
            byte[] data = { 0, 0, 0, 2, 1, 0 };

            FingerprintDecompressor decompressor = new FingerprintDecompressor();

            int algorithm = -1;
            int[] actual = decompressor.Decompress(Base64.ByteEncoding.GetString(data), ref algorithm);
            Assert.AreEqual(0, algorithm);
            CollectionAssert.AreEqual(actual, expected);
        }
    }
}
