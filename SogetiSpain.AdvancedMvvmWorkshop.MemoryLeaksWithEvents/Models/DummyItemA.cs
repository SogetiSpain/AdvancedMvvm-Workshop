// ----------------------------------------------------------------------------
// <copyright file="DummyItemA.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.AdvancedMvvmWorkshop.MemoryLeaksWithEvents.Models
{
    using System;
    using System.Threading;

    /// <summary>
    /// Represents a dummy item of type 'A'.
    /// </summary>
    public sealed class DummyItemA
    {
        /// <summary>
        /// Defines the count.
        /// </summary>
        private static volatile int s_count;

        /// <summary>
        /// Initializes a new instance of the <see cref="DummyItemA"/> class.
        /// </summary>
        public DummyItemA()
        {
            Interlocked.Increment(ref s_count);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="DummyItemA"/> class.
        /// </summary>
        ~DummyItemA()
        {
            Interlocked.Decrement(ref s_count);
        }

        /// <summary>
        /// Occurs when fake something happens.
        /// </summary>
        public event EventHandler OnFakeSomething;

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public static int Count => s_count;

        /// <summary>
        /// Raises fake something.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RaiseFakeSomething(EventArgs e)
        {
            OnFakeSomething?.Invoke(this, e);
        }
    }
}