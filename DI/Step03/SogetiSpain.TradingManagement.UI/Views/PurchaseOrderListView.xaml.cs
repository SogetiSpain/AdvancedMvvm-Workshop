// ----------------------------------------------------------------------------
// <copyright file="PurchaseOrderListView.xaml.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.TradingManagement.Views
{
    using System.Windows.Controls;
    using SogetiSpain.TradingManagement.ViewModels;

    /// <summary>
    /// Interaction logic for PurchaseOrderListView.xaml.
    /// </summary>
    public partial class PurchaseOrderListView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseOrderListView"/> class.
        /// </summary>
        public PurchaseOrderListView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseOrderListView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public PurchaseOrderListView(IPurchaseOrderListViewModel viewModel)
            : this()
        {
            DataContext = viewModel;
        }
    }
}