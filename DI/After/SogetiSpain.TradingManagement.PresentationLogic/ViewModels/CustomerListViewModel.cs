// ----------------------------------------------------------------------------
// <copyright file="CustomerListViewModel.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.TradingManagement.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Prism.Commands;
    using Prism.Mvvm;
    using SogetiSpain.TradingManagement.Models;
    using SogetiSpain.TradingManagement.Services;

    /// <summary>
    /// Represents the viewmodel of the customer list view.
    /// </summary>
    internal class CustomerListViewModel : BindableBase, ICustomerListViewModel
    {
        /// <summary>
        /// Defines the customer service.
        /// </summary>
        private readonly CustomerService _customerService;

        /// <summary>
        /// Defines the customer collection.
        /// </summary>
        private ObservableCollection<CustomerDto> _customerCollection;

        /// <summary>
        /// Defines the load customers command.
        /// </summary>
        private ICommand _loadCustomersCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerListViewModel"/> class.
        /// </summary>
        public CustomerListViewModel()
        {
            _customerService = new CustomerService();
        }

        /// <summary>
        /// Gets or sets the customer collection.
        /// </summary>
        /// <value>
        /// The customer collection.
        /// </value>
        public ObservableCollection<CustomerDto> CustomerCollection
        {
            get => _customerCollection;
            set => SetProperty(ref _customerCollection, value);
        }

        /// <summary>
        /// Gets the load customers command.
        /// </summary>
        /// <value>
        /// The load customers command.
        /// </value>
        public ICommand LoadCustomersCommand
        {
            get => _loadCustomersCommand ?? (_loadCustomersCommand = new DelegateCommand(() => LoadCustomers()));
        }

        /// <summary>
        /// Loads the customers.
        /// </summary>
        private void LoadCustomers()
        {
            var customersDtos = _customerService.GetList(0, 100);
            CustomerCollection = new ObservableCollection<CustomerDto>(customersDtos);
        }
    }
}