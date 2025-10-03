/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MainThreadAgent.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/03/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;

namespace MGS.Singleton
{
    /// <summary>
    /// Agent of main thread to invoke action.
    /// Do not add this component to any gameobject by yourself.
    /// Require the first access is from the main thread.
    /// </summary>
    public sealed class MainThreadAgent : MonoSingleton<MainThreadAgent>
    {
        private readonly Queue<Action> actions = new();
        private readonly object sync = new();

        private void Update()
        {
            if (actions.Count == 0)
            {
                return;
            }

            lock (sync)
            {
                while (actions.Count > 0)
                {
                    actions.Dequeue().Invoke();
                }
            }
        }

        /// <summary>
        /// Enqueue action and it will be invoke by main thread.
        /// </summary>
        /// <param name="action"></param>
        public void Enqueue(Action action)
        {
            lock (sync)
            {
                actions.Enqueue(action);
            }
        }
    }
}