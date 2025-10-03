/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoSingletonTests.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  08/31/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using NUnit.Framework;
using UnityEngine;

namespace MGS.Singleton.Tests
{
    public class MonoSingletonTests
    {
        sealed class TestMonoSingleton : MonoSingleton<TestMonoSingleton> { }

        [Test]
        public void SingleInstanceTest()
        {
            var instance = TestMonoSingleton.Instance;
            Assert.NotNull(instance);
            Debug.Log($"Instance is {instance}");
        }
    }
}