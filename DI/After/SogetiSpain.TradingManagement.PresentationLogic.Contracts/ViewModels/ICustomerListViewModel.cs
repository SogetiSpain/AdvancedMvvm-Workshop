// ----------------------------------------------------------------------------
// <copyright file="ICustomerListViewModel.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.TradingManagement.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;
    using SogetiSpain.TradingManagement.Models;

    /// <summary>
    /// Defines the contract for the viewmodel of the customer list view.
    /// </summary>
    public interface ICustomerListViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the customer collection.
        /// </summary>
        /// <value>
        /// The customer collection.
        /// </value>
        ObservableCollection<CustomerDto> CustomerCollection { get; set; }

        /// <summary>
        /// Gets the load customers command.
        /// </summary>
        /// <value>
        /// The load customers command.
        /// </value>
        ICommand LoadCustomersCommand { get; }
    }
}