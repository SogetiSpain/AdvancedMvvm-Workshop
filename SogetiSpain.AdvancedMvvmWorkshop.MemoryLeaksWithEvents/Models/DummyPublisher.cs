// ----------------------------------------------------------------------------
// <copyright file="DummyPublisher.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.AdvancedMvvmWorkshop.MemoryLeaksWithEvents.Models
{
    using System;
    using System.Threading;
    using Prism.Events;
    using SogetiSpain.AdvancedMvvmWorkshop.MemoryLeaksWithEvents.Events;

    /// <summary>
    /// Represents a dummy publisher.
    /// </summary>
    public sealed class DummyPublisher
    {
        /// <summary>
        /// Defines the count.
        /// </summary>
        private static volatile int s_count;

        /// <summary>
        /// Defines the event aggregator.
        /// </summary>
        private readonly IEventAggregator _eventAggregator;

        /// <summary>
        /// Initializes a new instance of the <see cref="DummyPublisher" /> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public DummyPublisher(IEventAggregator eventAggregator)
        {
            Interlocked.Increment(ref s_count);

            _eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="DummyPublisher"/> class.
        /// </summary>
        ~DummyPublisher()
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
        /// Sends the hello world message.
        /// </summary>
        public void SendHelloWorldMessage()
        {
            _eventAggregator.GetEvent<DummyMessageEvent>().Publish("Hello world!");
        }
    }
}