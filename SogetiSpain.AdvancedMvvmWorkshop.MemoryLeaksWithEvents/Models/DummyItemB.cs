// ----------------------------------------------------------------------------
// <copyright file="DummyItemB.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.AdvancedMvvmWorkshop.MemoryLeaksWithEvents.Models
{
    using System;
    using System.ComponentModel;
    using System.Threading;

    /// <summary>
    /// Represents a dummy item of type 'B'.
    /// </summary>
    public sealed class DummyItemB
    {
        /// <summary>
        /// Defines the count.
        /// </summary>
        private static volatile int s_count;

        /// <summary>
        /// Defines the bindable object.
        /// </summary>
        private readonly INotifyPropertyChanged _bindableObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="DummyItemB" /> class.
        /// </summary>
        /// <param name="bindableObject">The bindable object.</param>
        public DummyItemB(INotifyPropertyChanged bindableObject)
        {
            Interlocked.Increment(ref s_count);

            _bindableObject = bindableObject ?? throw new ArgumentNullException(nameof(bindableObject));
            _bindableObject.PropertyChanged += OnBindableObjectPropertyChanged;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="DummyItemB"/> class.
        /// </summary>
        ~DummyItemB()
        {
            Interlocked.Decrement(ref s_count);
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public static int Count => s_count;

        /// <summary>
        /// Called when a property changed within the bindable object.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void OnBindableObjectPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }
    }
}