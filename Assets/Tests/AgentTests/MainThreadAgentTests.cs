/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MainThreadAgentTests.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/03/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace MGS.Singleton.Tests
{
    public class MainThreadAgentTests
    {
        [Test]
        public void SingleInstanceTest()
        {
            var instance = MainThreadAgent.Instance;
            Assert.NotNull(instance);
            Debug.Log($"Instance is {instance}");
        }

        [UnityTest]
        public IEnumerator EnqueueActionTest()
        {
            //Require the first access is from the main thread.
            var instance = MainThreadAgent.Instance;
            void WorkOnMainThread()
            {
                Debug.Log("WorkOnMainThread");
            }
            void WorkOnBgThread()
            {
                MainThreadAgent.Instance.Enqueue(WorkOnMainThread);
            }
            new Thread(WorkOnBgThread) { IsBackground = true }.Start();
            yield return new WaitForEndOfFrame();
        }
    }
}