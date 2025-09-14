/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoSingletonTest.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  08/31/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Singleton;
using NUnit.Framework;
using UnityEngine;

public class MonoSingletonTest
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