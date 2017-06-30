// ----------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.AdvancedMvvmWorkshop.AsyncProgrammingWPF
{
    using System;
    using System.Threading.Tasks;
    using System.Windows;

    /// <summary>
    /// Represents the interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }

        /// <summary>
        /// Called when the button click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void OnButtonClick(object sender, RoutedEventArgs e)
        {
            ResultedTextBlock.Text = string.Empty;

            await Task.Delay(10000).ConfigureAwait(false);

            Dispatcher.Invoke(new Action(() =>
            {
                ResultedTextBlock.Text = "The long task was executed successfully!";
                MessageBox.Show(ResultedTextBlock.Text);
            }));
        }
    }
}