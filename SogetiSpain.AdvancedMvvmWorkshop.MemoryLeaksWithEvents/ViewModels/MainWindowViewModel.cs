// ----------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.AdvancedMvvmWorkshop.MemoryLeaksWithEvents.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Threading;
    using Prism.Commands;
    using Prism.Events;
    using Prism.Mvvm;
    using SogetiSpain.AdvancedMvvmWorkshop.MemoryLeaksWithEvents.Models;

    /// <summary>
    /// Represents the viewmodel of the Main Window.
    /// </summary>
    public sealed class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// Defines the items per block.
        /// </summary>
        private const int ItemsPerBlock = 10000;

        /// <summary>
        /// Defines the create items of type 'A' command.
        /// </summary>
        private readonly ICommand _createItemsACommand;

        /// <summary>
        /// Defines the create items of type 'B' command.
        /// </summary>
        private readonly ICommand _createItemsBCommand;

        /// <summary>
        /// Defines the create publishers command.
        /// </summary>
        private readonly ICommand _createPublishersCommand;

        /// <summary>
        /// Defines the create subscribers command.
        /// </summary>
        private readonly ICommand _createSubscribersCommand;

        /// <summary>
        /// Defines the event aggregator.
        /// </summary>
        private readonly IEventAggregator _eventAggregator;

        /// <summary>
        /// Defines the recycle command.
        /// </summary>
        private readonly ICommand _recycleCommand;

        /// <summary>
        /// Defines the timer.
        /// </summary>
        private readonly DispatcherTimer _timer;

        /// <summary>
        /// Defines the total created items of type 'A'.
        /// </summary>
        private int _totalCreatedItemsA;

        /// <summary>
        /// Defines the total created items of type 'B'.
        /// </summary>
        private int _totalCreatedItemsB;

        /// <summary>
        /// Defines the total created publishers.
        /// </summary>
        private int _totalCreatedPublishers;

        /// <summary>
        /// Defines the total created subscribers.
        /// </summary>
        private int _totalCreatedSubscribers;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel" /> class.
        /// </summary>
        public MainWindowViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                return;
            }

            _createItemsACommand = new DelegateCommand(async () => await CreateItemsAAsync().ConfigureAwait(false));
            _createItemsBCommand = new DelegateCommand(async () => await CreateItemsBAsync().ConfigureAwait(false));
            _createPublishersCommand = new DelegateCommand(async () => await CreatePublishersAsync().ConfigureAwait(false));
            _createSubscribersCommand = new DelegateCommand(async () => await CreateSubscribersAsync().ConfigureAwait(false));

            _eventAggregator = new EventAggregator();

            _recycleCommand = new DelegateCommand(async () => await RecycleAsync().ConfigureAwait(false));

            _timer = new DispatcherTimer(DispatcherPriority.Send)
            {
                Interval = new TimeSpan(0, 0, 1),
            };

            _timer.Tick += async (sender, e) => await RefreshDataAsync().ConfigureAwait(false);
            _timer.Start();
        }

        /// <summary>
        /// Gets the create items of type 'A' command.
        /// </summary>
        /// <value>
        /// The create items of type 'A' command.
        /// </value>
        public ICommand CreateItemsACommand => _createItemsACommand;

        /// <summary>
        /// Gets the create items of type 'B' command.
        /// </summary>
        /// <value>
        /// The create items of type 'B' command.
        /// </value>
        public ICommand CreateItemsBCommand => _createItemsBCommand;

        /// <summary>
        /// Gets the create publishers command.
        /// </summary>
        /// <value>
        /// The create publishers command.
        /// </value>
        public ICommand CreatePublishersCommand => _createPublishersCommand;

        /// <summary>
        /// Gets the create subscribers command.
        /// </summary>
        /// <value>
        /// The create subscribers command.
        /// </value>
        public ICommand CreateSubscribersCommand => _createSubscribersCommand;

        /// <summary>
        /// Gets the recycle command.
        /// </summary>
        /// <value>
        /// The recycle command.
        /// </value>
        public ICommand RecycleCommand => _recycleCommand;

        /// <summary>
        /// Gets the total created items of type 'A'.
        /// </summary>
        /// <value>
        /// The total created items of type 'A'.
        /// </value>
        public int TotalCreatedItemsA
        {
            get => _totalCreatedItemsA;
            private set => SetProperty(ref _totalCreatedItemsA, value);
        }

        /// <summary>
        /// Gets the total created items of type 'B'.
        /// </summary>
        /// <value>
        /// The total created items of type 'B'.
        /// </value>
        public int TotalCreatedItemsB
        {
            get => _totalCreatedItemsB;
            private set => SetProperty(ref _totalCreatedItemsB, value);
        }

        /// <summary>
        /// Gets the total created publishers.
        /// </summary>
        /// <value>
        /// The total created publishers.
        /// </value>
        public int TotalCreatedPublishers
        {
            get => _totalCreatedPublishers;
            private set => SetProperty(ref _totalCreatedPublishers, value);
        }

        /// <summary>
        /// Gets the total created subscribers.
        /// </summary>
        /// <value>
        /// The total created subscribers.
        /// </value>
        public int TotalCreatedSubscribers
        {
            get => _totalCreatedSubscribers;
            private set => SetProperty(ref _totalCreatedSubscribers, value);
        }

        /// <summary>
        /// Gets the total still alive items of type 'A'.
        /// </summary>
        /// <value>
        /// The total still alive items of type 'A'.
        /// </value>
        public int TotalStillAliveItemsA => DummyItemA.Count;

        /// <summary>
        /// Gets the total still alive items of type 'B'.
        /// </summary>
        /// <value>
        /// The total still alive items of type 'B'.
        /// </value>
        public int TotalStillAliveItemsB => DummyItemB.Count;

        /// <summary>
        /// Gets the total still alive publishers.
        /// </summary>
        /// <value>
        /// The total still alive publishers.
        /// </value>
        public int TotalStillAlivePublishers => DummyPublisher.Count;

        /// <summary>
        /// Gets the total still alive subscribers.
        /// </summary>
        /// <value>
        /// The total still alive subscribers.
        /// </value>
        public int TotalStillAliveSubscribers => DummySubscriber.Count;

        /// <summary>
        /// Creates the items of type 'A'.
        /// </summary>
        /// <returns>
        /// A task.
        /// </returns>
        private async Task CreateItemsAAsync()
        {
            int count = 0;

            await Task.Run(() =>
            {
                for (; count < ItemsPerBlock; count++)
                {
                    var dummyItemA = new DummyItemA();
                    dummyItemA.OnFakeSomething += OnDummyItemFakeSomething;
                }
            })
            .ConfigureAwait(false);

            await Application.Current.Dispatcher.InvokeAsync(
                () => TotalCreatedItemsA += count,
                DispatcherPriority.Send);
        }

        /// <summary>
        /// Creates the items of type 'B'.
        /// </summary>
        /// <returns>
        /// A task.
        /// </returns>
        private async Task CreateItemsBAsync()
        {
            int count = 0;

            await Task.Run(() =>
            {
                for (; count < ItemsPerBlock; count++)
                {
                    var dummyItemB = new DummyItemB(this);
                }
            })
            .ConfigureAwait(false);

            await Application.Current.Dispatcher.InvokeAsync(
                () => TotalCreatedItemsB += count,
                DispatcherPriority.Send);
        }

        /// <summary>
        /// Creates the publishers.
        /// </summary>
        /// <returns>
        /// A task.
        /// </returns>
        private async Task CreatePublishersAsync()
        {
            int count = 0;

            await Task.Run(() =>
            {
                for (; count < ItemsPerBlock; count++)
                {
                    var dummyPublisher = new DummyPublisher(_eventAggregator);
                    dummyPublisher.SendHelloWorldMessage();
                }
            })
            .ConfigureAwait(false);

            await Application.Current.Dispatcher.InvokeAsync(
                () => TotalCreatedPublishers += count,
                DispatcherPriority.Send);
        }

        /// <summary>
        /// Creates the subscribers.
        /// </summary>
        /// <returns>
        /// A task.
        /// </returns>
        private async Task CreateSubscribersAsync()
        {
            int count = 0;

            await Task.Run(() =>
            {
                for (; count < ItemsPerBlock; count++)
                {
                    var dummySubscriber = new DummySubscriber(_eventAggregator);
                }
            })
            .ConfigureAwait(false);

            await Application.Current.Dispatcher.InvokeAsync(
                () => TotalCreatedSubscribers += count,
                DispatcherPriority.Send);
        }

        /// <summary>
        /// Called when fake something happens within a dummy item.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnDummyItemFakeSomething(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Recycles (Garbage Collector).
        /// </summary>
        /// <returns>
        /// A tasks.
        /// </returns>
        private async Task RecycleAsync()
        {
            await Task.Run(() => GC.Collect()).ConfigureAwait(false);
        }

        /// <summary>
        /// Refreshes the data.
        /// </summary>
        /// <returns>
        /// A task.
        /// </returns>
        private async Task RefreshDataAsync()
        {
            await Application.Current.Dispatcher.InvokeAsync(
                () => RaisePropertyChanged(string.Empty),
                DispatcherPriority.Send);
        }
    }
}