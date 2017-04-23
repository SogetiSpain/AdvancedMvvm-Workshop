// ----------------------------------------------------------------------------
// <copyright file="DummyMessageEvent.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.AdvancedMvvmWorkshop.MemoryLeaksWithEvents.Events
{
    using Prism.Events;

    /// <summary>
    /// Represents a dummy message event.
    /// </summary>
    public sealed class DummyMessageEvent : PubSubEvent<string>
    {
    }
}