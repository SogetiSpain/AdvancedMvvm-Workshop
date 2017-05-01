// ----------------------------------------------------------------------------
// <copyright file="ProductListView.xaml.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.TradingManagement.Views
{
    using System.Windows.Controls;
    using SogetiSpain.TradingManagement.ViewModels;

    /// <summary>
    /// Interaction logic for ProductListView.xaml.
    /// </summary>
    internal partial class ProductListView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductListView"/> class.
        /// </summary>
        public ProductListView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductListView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public ProductListView(IProductListViewModel viewModel)
            : this()
        {
            DataContext = viewModel;
        }
    }
}