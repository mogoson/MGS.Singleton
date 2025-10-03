/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CoroutineAgent.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/03/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections;
using UnityEngine;

namespace MGS.Singleton
{
    /// <summary>
    /// Agent of coroutine.
    /// Do not add this component to any gameobject by yourself.
    /// Require the first access is from the main thread.
    /// </summary>
    public sealed class CoroutineAgent : MonoSingleton<CoroutineAgent>
    {
        /// <summary>
        /// Start coroutine to invoke the specified action repeatedly each frame.
        /// </summary>
        /// <param name="tick">The action to invoke.</param>
        /// <returns>The coroutine object.</returns>
        public Coroutine StartTickCoroutine(Action tick)
        {
            IEnumerator Routine()
            {
                while (true)
                {
                    tick?.Invoke();
                    yield return null;
                }
            }
            return StartCoroutine(Routine());
        }

        /// <summary>
        /// Start coroutine to invoke the specified action repeatedly each frame with a specified time interval.
        /// </summary>
        /// <param name="seconds">The time interval between invocations.</param>
        /// <param name="tick">The action to invoke.</param>
        /// <param name="arrive">The action to invoke when the timer arrives.</param>
        /// <returns>The coroutine object.</returns>
        public Coroutine StartTimerCoroutine(float seconds, Action<float> tick, Action arrive)
        {
            IEnumerator Routine()
            {
                var timer = 0f;
                while (timer < seconds)
                {
                    timer += Time.deltaTime;
                    tick?.Invoke(timer);
                    yield return null;
                }
                arrive?.Invoke();
            }
            return StartCoroutine(Routine());
        }

        /// <summary>
        /// Start coroutine to invoke the specified action when the specified condition is true.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="action">The action to invoke.</param>
        /// <returns>The coroutine object.</returns>
        public Coroutine StartWaitCoroutine(Func<bool> condition, Action action)
        {
            IEnumerator Routine()
            {
                while (!condition.Invoke())
                {
                    yield return null;
                }
                action?.Invoke();
            }
            return StartCoroutine(Routine());
        }

        /// <summary>
        /// Start coroutine to invoke the specified action repeatedly each frame until the specified condition is false.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="action">The action to invoke.</param>
        /// <returns>The coroutine object.</returns>
        public Coroutine StartUntilCoroutine(Func<bool> condition, Action action)
        {
            IEnumerator Routine()
            {
                while (condition.Invoke())
                {
                    action?.Invoke();
                    yield return null;
                }
            }
            return StartCoroutine(Routine());
        }

        /// <summary>
        /// Start coroutine to invoke the specified action after a specified delay seconds.
        /// </summary>
        /// <param name="seconds">The delay in seconds.</param>
        /// <param name="action">The action to invoke.</param>
        /// <returns>The coroutine object.</returns>
        public Coroutine StartDelayCoroutine(float seconds, Action action)
        {
            IEnumerator Routine()
            {
                yield return new WaitForSeconds(seconds);
                action?.Invoke();
            }
            return StartCoroutine(Routine());
        }
    }
}