// ----------------------------------------------------------------------------
// <copyright file="SaleOrderListView.xaml.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.TradingManagement.Views
{
    using System.Windows.Controls;
    using SogetiSpain.TradingManagement.ViewModels;

    /// <summary>
    /// Interaction logic for SaleOrderListView.xaml.
    /// </summary>
    internal partial class SaleOrderListView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SaleOrderListView"/> class.
        /// </summary>
        public SaleOrderListView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaleOrderListView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public SaleOrderListView(ISaleOrderListViewModel viewModel)
            : this()
        {
            DataContext = viewModel;
        }
    }
}