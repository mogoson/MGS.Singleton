/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SingletonTests.cs
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
    public class SingletonTests
    {
        sealed class TestSingleton : Singleton<TestSingleton>
        {
            private TestSingleton()
            {
                Debug.Log("Run Constructor.");
            }
        }

        //class TestSingletonEx : TestSingleton { } //Compile error.

        [Test]
        public void SingleInstanceTest()
        {
            TestSingleton instance;

            //instance = new TestSingleton();   //Compile error.
            //instance = new TestSingletonEx();   //Compile error.

            instance = TestSingleton.Instance;
            Assert.NotNull(instance);
            Debug.Log($"Instance is {instance}");
        }
    }
}