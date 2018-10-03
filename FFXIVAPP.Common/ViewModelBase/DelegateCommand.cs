// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DelegateCommand.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   DelegateCommand.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.ViewModelBase {
    using System;
    using System.Windows.Input;

    // ===================================================================================
    // Microsoft Developer & Platform Evangelism
    // =================================================================================== 
    // THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
    // EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
    // OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
    // ===================================================================================
    // Copyright (c) Microsoft Corporation.  All Rights Reserved.
    // This code is released under the terms of the MS-LPL license, 
    // http://microsoftnlayerapp.codeplex.com/license
    // ===================================================================================
    // Modification done to remove CommandManager dependency (and probably make the code worse...)
    public class DelegateCommand : ICommand {
        private readonly Func<bool> _canExecuteMethod;

        private readonly Action _executeMethod;

        /// <summary>
        /// </summary>
        /// <param name="executeMethod"> </param>
        public DelegateCommand(Action executeMethod)
            : this(executeMethod, null, false) { }

        /// <summary>
        /// </summary>
        /// <param name="executeMethod"> </param>
        /// <param name="canExecuteMethod"> </param>
        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
            : this(executeMethod, canExecuteMethod, false) { }

        /// <summary>
        /// </summary>
        /// <param name="executeMethod"> </param>
        /// <param name="canExecuteMethod"> </param>
        /// <param name="isAutomaticRequeryDisabled"> </param>
        private DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod, bool isAutomaticRequeryDisabled) {
            if (executeMethod == null) {
                throw new ArgumentNullException("executeMethod");
            }

            this._executeMethod = executeMethod;
            this._canExecuteMethod = canExecuteMethod;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this._canExecuteMethod == null || this._canExecuteMethod();
        }

        public void Execute(object parameter) {
            if (this._executeMethod != null) {
                this._executeMethod();
            }
        }
    }

    public sealed class DelegateCommand<T> : ICommand {
        private readonly Func<T, bool> _canExecuteMethod;

        private readonly Action<T> _executeMethod;

        /// <summary>
        /// </summary>
        /// <param name="executeMethod"> </param>
        /// <param name="canExecuteMethod"> </param>
        public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
            : this(executeMethod, canExecuteMethod, false) { }

        /// <summary>
        /// </summary>
        /// <param name="executeMethod"> </param>
        /// <param name="canExecuteMethod"> </param>
        /// <param name="isAutomaticRequeryDisabled"> </param>
        public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod = null, bool isAutomaticRequeryDisabled = false) {
            if (executeMethod == null) {
                throw new ArgumentNullException(nameof(executeMethod));
            }

            this._executeMethod = executeMethod;
            this._canExecuteMethod = canExecuteMethod;
        }

        /// <summary>
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// </summary>
        /// <param name="parameter"> </param>
        /// <returns> </returns>
        bool ICommand.CanExecute(object parameter) {
            if (parameter == null && typeof(T).IsValueType) {
                return this._canExecuteMethod == null;
            }

            return this.CanExecute((T) parameter);
        }

        /// <summary>
        /// </summary>
        /// <param name="parameter"> </param>
        void ICommand.Execute(object parameter) {
            this.Execute((T) parameter);
        }

        /// <summary>
        /// </summary>
        /// <param name="parameter"> </param>
        /// <returns> </returns>
        private bool CanExecute(T parameter) {
            return this._canExecuteMethod == null || this._canExecuteMethod(parameter);
        }

        /// <summary>
        /// </summary>
        /// <param name="parameter"> </param>
        private void Execute(T parameter) {
            if (this._executeMethod != null) {
                this._executeMethod(parameter);
            }
        }
    }
}
