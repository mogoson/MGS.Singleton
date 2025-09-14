/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Singleton.cs
 *  Description  :  Define singleton.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/13/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.Singleton
{
    /// <summary>
    /// Provide a lazy and thread safety single instance of the specified type T;
    /// Specified type T should with the sealed access modifier
    /// and a private parameterless constructor to ensure singleton.
    /// </summary>
    /// <typeparam name="T">Specified type.</typeparam>
    public abstract class Singleton<T> where T : class
    {
        /// <summary>
        /// Single instance of the specified type T (Lazy and thread safety).
        /// </summary>
        public static T Instance { get { return Agent.Instance; } }

        /// <summary>
        /// Agent provide the single instance.
        /// </summary>
        private class Agent
        {
            /// <summary>
            /// Single instance of the specified type T (Thread safety).
            /// </summary>
            internal static T Instance { get; }

            /// <summary>
            /// Explicit static constructor to create single instance of the specified type T (Thread safety).
            /// </summary>
            static Agent() { Instance = Activator.CreateInstance(typeof(T), true) as T; }
        }
    }
}