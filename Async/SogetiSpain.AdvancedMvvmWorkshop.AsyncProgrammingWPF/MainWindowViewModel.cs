// ----------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.AdvancedMvvmWorkshop.AsyncProgrammingWPF
{
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Mvvm;

    /// <summary>
    /// Represents the view model of the main window.
    /// </summary>
    public sealed class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// Defines the resulted text.
        /// </summary>
        private string _resultedText;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel" /> class.
        /// </summary>
        public MainWindowViewModel()
        {
            ExecuteLongTaskCommand = new DelegateCommand(async () => await ExecuteLongTaskAsync());
        }

        /// <summary>
        /// Gets the execute long task command.
        /// </summary>
        /// <value>
        /// The execute long task command.
        /// </value>
        public ICommand ExecuteLongTaskCommand { get; }

        /// <summary>
        /// Gets the resulted text.
        /// </summary>
        /// <value>
        /// The resulted text.
        /// </value>
        public string ResultedText
        {
            get
            {
                return _resultedText;
            }

            private set
            {
                SetProperty(ref _resultedText, value);
            }
        }

        /// <summary>
        /// Executes the long task asynchronous.
        /// </summary>
        /// <returns>
        /// The resulted task.
        /// </returns>
        private async Task ExecuteLongTaskAsync()
        {
            ResultedText = string.Empty;

            await Task.Delay(10000).ConfigureAwait(true);

            ResultedText = "The long task was executed successfully!";
            MessageBox.Show(ResultedText);
        }
    }
}