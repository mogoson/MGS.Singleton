/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoSingleton.cs
 *  Description  :  Define mono singleton.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/11/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Singleton
{
    /// <summary>
    /// Provide a auto create, lazy and thread safety single instance of the specified component T;
    /// Specified component T should with the sealed access modifier to ensure singleton.
    /// Do not add the component T to any gameobject by yourself.
    /// Require the first access is from the main thread.
    /// </summary>
    /// <typeparam name="T">Specified type.</typeparam>
    [DisallowMultipleComponent]
    public abstract class MonoSingleton<T> : MonoBehaviour where T : Component
    {
        /// <summary>
        /// Single instance of the specified component T (Lazy and thread safety).
        /// Require the first access is from the main thread.
        /// </summary>
        public static T Instance { get { return Agent.Instance; } }

        /// <summary>
        /// Agent provide the single instance.
        /// </summary>
        private class Agent
        {
            /// <summary>
            /// Single instance of the specified type T (Thread safety).
            /// Require the first access is from the main thread.
            /// </summary>
            internal static T Instance { get; }

            /// <summary>
            /// Explicit static constructor to create single instance of the specified type T (Thread safety).
            /// </summary>
            static Agent()
            {
                Instance = new GameObject(nameof(T)).AddComponent<T>();
                DontDestroyOnLoad(Instance);
            }
        }
    }
}