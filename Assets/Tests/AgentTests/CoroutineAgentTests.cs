/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CoroutineAgentTests.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/03/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace MGS.Singleton.Tests
{
    public class CoroutineAgentTests
    {
        [Test]
        public void SingleInstanceTest()
        {
            var instance = CoroutineAgent.Instance;
            Assert.NotNull(instance);
            Debug.Log($"Instance is {instance}");
        }

        [UnityTest]
        public IEnumerator StartDelayCoroutineTest()
        {
            void DoSomething()
            {
                Debug.Log("DoSomething");
            }
            yield return CoroutineAgent.Instance.StartDelayCoroutine(3.0f, DoSomething);
        }
    }
}