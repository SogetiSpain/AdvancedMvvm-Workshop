// ----------------------------------------------------------------------------
// <copyright file="Program.cs" company="SOGETI Spain">
//     Copyright © 2017 SOGETI Spain. All rights reserved.
//     Powered by Óscar Fernández González a.k.a. Osc@rNET.
// </copyright>
// ----------------------------------------------------------------------------
namespace SogetiSpain.AdvancedMvvmWorkShop.AsyncProgrammingConsole
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the main program.
    /// </summary>
    public sealed class Program
    {
        /// <summary>
        /// Defines the synchronize object.
        /// </summary>
        private static object syncObject = new object();

        /// <summary>
        /// Represents the main method.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            WriteLine("Starting console app...", ConsoleColor.White);

            var grayTask = CreateColorDelayTaskAsync(4000, ConsoleColor.Gray);
            var cyanTask = CreateColorDelayTaskAsync(7500, ConsoleColor.Cyan);
            var redTask = CreateColorDelayTaskAsync(2500, ConsoleColor.Red);
            var yellowTask = CreateColorDelayTaskAsync(10000, ConsoleColor.Yellow);
            var greenTask = CreateColorDelayTaskAsync(5000, ConsoleColor.Green);

            Task.WaitAll(new[] { cyanTask, grayTask, greenTask, redTask, yellowTask });

            WriteLine("End of console app (Press INTRO for exit)", ConsoleColor.White);
            Console.ReadLine();
        }

        /// <summary>
        /// Creates a color delay task asynchronous.
        /// </summary>
        /// <param name="millisecondsDelay">The milliseconds delay.</param>
        /// <param name="foregroundColor">Color of the foreground.</param>
        /// <returns>
        /// The resulted task.
        /// </returns>
        private static async Task CreateColorDelayTaskAsync(int millisecondsDelay, ConsoleColor foregroundColor)
        {
            var taskName = Enum.GetName(typeof(ConsoleColor), foregroundColor).ToUpperInvariant();
            WriteLine($"\tStarting {taskName} task (delay: {millisecondsDelay:#,##0} ms)...", foregroundColor);

            await Task.Delay(millisecondsDelay);

            WriteLine($"\tEnd of {taskName} task", foregroundColor);
        }

        /// <summary>
        /// Writes to console a given line.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="foregroundColor">Color of the foreground.</param>
        private static void WriteLine(string text, ConsoleColor foregroundColor)
        {
            lock (syncObject)
            {
                Console.ForegroundColor = foregroundColor;
                Console.Write(text);
                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }
}