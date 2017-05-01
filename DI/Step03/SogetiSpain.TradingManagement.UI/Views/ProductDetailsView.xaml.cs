// ----------------------------------------------------------------------------
// <copyright file="ProductDetailsView.xaml.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.TradingManagement.Views
{
    using System.Windows.Controls;
    using SogetiSpain.TradingManagement.ViewModels;

    /// <summary>
    /// Interaction logic for ProductDetailsView.xaml.
    /// </summary>
    public partial class ProductDetailsView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDetailsView"/> class.
        /// </summary>
        public ProductDetailsView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDetailsView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public ProductDetailsView(IProductDetailsViewModel viewModel)
            : this()
        {
            DataContext = viewModel;
        }
    }
}