// ----------------------------------------------------------------------------
// <copyright file="CustomerListView.xaml.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.TradingManagement.Views
{
    using System.Windows.Controls;
    using SogetiSpain.TradingManagement.ViewModels;

    /// <summary>
    /// Interaction logic for CustomerListView.xaml.
    /// </summary>
    internal partial class CustomerListView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerListView"/> class.
        /// </summary>
        public CustomerListView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerListView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public CustomerListView(ICustomerListViewModel viewModel)
            : this()
        {
            DataContext = viewModel;
        }
    }
}