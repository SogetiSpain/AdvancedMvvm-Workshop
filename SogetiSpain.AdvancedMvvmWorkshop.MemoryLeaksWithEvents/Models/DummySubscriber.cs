// ----------------------------------------------------------------------------
// <copyright file="DummySubscriber.cs" company="SOGETI Spain">
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
    /// Represents a dummy subscriber.
    /// </summary>
    public sealed class DummySubscriber
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
        /// Initializes a new instance of the <see cref="DummySubscriber" /> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public DummySubscriber(IEventAggregator eventAggregator)
        {
            Interlocked.Increment(ref s_count);

            _eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
            _eventAggregator.GetEvent<DummyMessageEvent>().Subscribe(message => LastReceivedMessage = message);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="DummySubscriber"/> class.
        /// </summary>
        ~DummySubscriber()
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
        /// Gets the last received message.
        /// </summary>
        /// <value>
        /// The last received message.
        /// </value>
        public string LastReceivedMessage { get; private set; }
    }
}