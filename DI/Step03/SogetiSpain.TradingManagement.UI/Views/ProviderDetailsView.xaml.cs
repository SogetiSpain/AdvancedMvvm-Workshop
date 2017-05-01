// ----------------------------------------------------------------------------
// <copyright file="ProviderDetailsView.xaml.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.TradingManagement.Views
{
    using System.Windows.Controls;
    using SogetiSpain.TradingManagement.ViewModels;

    /// <summary>
    /// Interaction logic for ProviderDetailsView.xaml.
    /// </summary>
    public partial class ProviderDetailsView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderDetailsView"/> class.
        /// </summary>
        public ProviderDetailsView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderDetailsView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public ProviderDetailsView(IProductDetailsViewModel viewModel)
            : this()
        {
            DataContext = viewModel;
        }
    }
}