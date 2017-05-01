// ----------------------------------------------------------------------------
// <copyright file="ProviderListView.xaml.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.TradingManagement.Views
{
    using System.Windows.Controls;
    using SogetiSpain.TradingManagement.ViewModels;

    /// <summary>
    /// Interaction logic for ProviderListView.xaml.
    /// </summary>
    public partial class ProviderListView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderListView"/> class.
        /// </summary>
        public ProviderListView()
        {
            InitializeComponent();
            DataContext = new ProviderListViewModel();
        }
    }
}