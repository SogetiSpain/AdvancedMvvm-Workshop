// ----------------------------------------------------------------------------
// <copyright file="IMainWindowViewModel.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.TradingManagement.ViewModels
{
    using System.Windows.Input;

    /// <summary>
    /// Defines the contract for the viewmodel of the main window.
    /// </summary>
    public interface IMainWindowViewModel
    {
        /// <summary>
        /// Gets the current view.
        /// </summary>
        /// <value>
        /// The current view.
        /// </value>
        object CurrentView { get; }

        /// <summary>
        /// Gets the navigate to command.
        /// </summary>
        /// <value>
        /// The navigate to command.
        /// </value>
        ICommand NavigateToCommand { get; }
    }
}