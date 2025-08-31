/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SingleBehaviourTest.cs
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

public class SingleBehaviourTest
{
    sealed class TestSingleBehaviour : SingleBehaviour<TestSingleBehaviour> { }

    [Test]
    public void SingleInstanceTest()
    {
        var instance = TestSingleBehaviour.Instance;
        Assert.NotNull(instance);
        Debug.Log($"Instance is {instance}");
    }
}