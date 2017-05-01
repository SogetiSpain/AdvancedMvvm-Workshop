// ----------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.TradingManagement.ViewModels
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Input;
    using Prism.Commands;
    using Prism.Mvvm;

    /// <summary>
    /// Represents the viewmodel of the main window.
    /// </summary>
    internal class MainWindowViewModel : BindableBase, IMainWindowViewModel
    {
        /// <summary>
        /// Defines the current view.
        /// </summary>
        private object _currentView;

        /// <summary>
        /// Defines the navigate to command.
        /// </summary>
        private ICommand _navigateToCommand;

        /// <summary>
        /// Gets the current view.
        /// </summary>
        /// <value>
        /// The current view.
        /// </value>
        public object CurrentView
        {
            get => _currentView;
            private set => SetProperty(ref _currentView, value);
        }

        /// <summary>
        /// Gets the navigate to command.
        /// </summary>
        /// <value>
        /// The navigate to command.
        /// </value>
        public ICommand NavigateToCommand
        {
            get => _navigateToCommand ?? (_navigateToCommand = new DelegateCommand<string>((viewName) => NavigateTo(viewName)));
        }

        /// <summary>
        /// Navigates to the given view.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        private void NavigateTo(string viewName)
        {
            var viewType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(type => string.Equals(type.Name, viewName));
            if (viewType != null)
            {
                CurrentView = Activator.CreateInstance(viewType);
            }
            else
            {
                MessageBox.Show("Cann't navigate to the '" + viewName + "' view!", "Oops ...", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}