// FFXIVAPP.Common ~ DelegateCommand.cs
// 
// Copyright © 2007 - 2016 Ryan Wilson - All Rights Reserved
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace FFXIVAPP.Common.ViewModelBase
{
    //===================================================================================
    // Microsoft Developer & Platform Evangelism
    //=================================================================================== 
    // THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
    // EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
    // OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
    //===================================================================================
    // Copyright (c) Microsoft Corporation.  All Rights Reserved.
    // This code is released under the terms of the MS-LPL license, 
    // http://microsoftnlayerapp.codeplex.com/license
    //===================================================================================
    public class DelegateCommand : ICommand
    {
        #region Constructors

        /// <summary>
        /// </summary>
        /// <param name="executeMethod"> </param>
        public DelegateCommand(Action executeMethod) : this(executeMethod, null, false)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="executeMethod"> </param>
        /// <param name="canExecuteMethod"> </param>
        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod) : this(executeMethod, canExecuteMethod, false)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="executeMethod"> </param>
        /// <param name="canExecuteMethod"> </param>
        /// <param name="isAutomaticRequeryDisabled"> </param>
        private DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod, bool isAutomaticRequeryDisabled)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException("executeMethod");
            }
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
            _isAutomaticRequeryDisabled = isAutomaticRequeryDisabled;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// </summary>
        public bool IsAutomaticRequeryDisabled
        {
            get { return _isAutomaticRequeryDisabled; }
            set
            {
                if (_isAutomaticRequeryDisabled == value)
                {
                    return;
                }
                if (value)
                {
                    CommandManagerHelper.RemoveHandlersFromRequerySuggested(_canExecuteChangedHandlers);
                }
                else
                {
                    CommandManagerHelper.AddHandlersToRequerySuggested(_canExecuteChangedHandlers);
                }
                _isAutomaticRequeryDisabled = value;
            }
        }

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        private bool CanExecute()
        {
            return _canExecuteMethod == null || _canExecuteMethod();
        }

        /// <summary>
        /// </summary>
        private void Execute()
        {
            if (_executeMethod != null)
            {
                _executeMethod();
            }
        }

        /// <summary>
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }

        /// <summary>
        /// </summary>
        private void OnCanExecuteChanged()
        {
            CommandManagerHelper.CallWeakReferenceHandlers(_canExecuteChangedHandlers);
        }

        #endregion

        #region ICommand Members

        /// <summary>
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested += value;
                }
                CommandManagerHelper.AddWeakReferenceHandler(ref _canExecuteChangedHandlers, value, 2);
            }
            remove
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested -= value;
                }
                CommandManagerHelper.RemoveWeakReferenceHandler(_canExecuteChangedHandlers, value);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="parameter"> </param>
        /// <returns> </returns>
        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        /// <summary>
        /// </summary>
        /// <param name="parameter"> </param>
        void ICommand.Execute(object parameter)
        {
            Execute();
        }

        #endregion

        #region Data

        private readonly Func<bool> _canExecuteMethod;
        private readonly Action _executeMethod;
        private List<WeakReference> _canExecuteChangedHandlers;
        private bool _isAutomaticRequeryDisabled;

        #endregion
    }

    public sealed class DelegateCommand<T> : ICommand
    {
        #region Constructors

        /// <summary>
        /// </summary>
        /// <param name="executeMethod"> </param>
        /// <param name="canExecuteMethod"> </param>
        public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod) : this(executeMethod, canExecuteMethod, false)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="executeMethod"> </param>
        /// <param name="canExecuteMethod"> </param>
        /// <param name="isAutomaticRequeryDisabled"> </param>
        public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod = null, bool isAutomaticRequeryDisabled = false)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException("executeMethod");
            }
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
            _isAutomaticRequeryDisabled = isAutomaticRequeryDisabled;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// </summary>
        public bool IsAutomaticRequeryDisabled
        {
            get { return _isAutomaticRequeryDisabled; }
            set
            {
                if (_isAutomaticRequeryDisabled != value)
                {
                    if (value)
                    {
                        CommandManagerHelper.RemoveHandlersFromRequerySuggested(_canExecuteChangedHandlers);
                    }
                    else
                    {
                        CommandManagerHelper.AddHandlersToRequerySuggested(_canExecuteChangedHandlers);
                    }
                    _isAutomaticRequeryDisabled = value;
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="parameter"> </param>
        /// <returns> </returns>
        private bool CanExecute(T parameter)
        {
            return _canExecuteMethod == null || _canExecuteMethod(parameter);
        }

        /// <summary>
        /// </summary>
        /// <param name="parameter"> </param>
        private void Execute(T parameter)
        {
            if (_executeMethod != null)
            {
                _executeMethod(parameter);
            }
        }

        /// <summary>
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }

        /// <summary>
        /// </summary>
        private void OnCanExecuteChanged()
        {
            CommandManagerHelper.CallWeakReferenceHandlers(_canExecuteChangedHandlers);
        }

        #endregion

        #region ICommand Members

        /// <summary>
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested += value;
                }
                CommandManagerHelper.AddWeakReferenceHandler(ref _canExecuteChangedHandlers, value, 2);
            }
            remove
            {
                if (!_isAutomaticRequeryDisabled)
                {
                    CommandManager.RequerySuggested -= value;
                }
                CommandManagerHelper.RemoveWeakReferenceHandler(_canExecuteChangedHandlers, value);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="parameter"> </param>
        /// <returns> </returns>
        bool ICommand.CanExecute(object parameter)
        {
            if (parameter == null && typeof (T).IsValueType)
            {
                return (_canExecuteMethod == null);
            }
            return CanExecute((T) parameter);
        }

        /// <summary>
        /// </summary>
        /// <param name="parameter"> </param>
        void ICommand.Execute(object parameter)
        {
            Execute((T) parameter);
        }

        #endregion

        #region Data

        private readonly Func<T, bool> _canExecuteMethod;
        private readonly Action<T> _executeMethod;
        private List<WeakReference> _canExecuteChangedHandlers;
        private bool _isAutomaticRequeryDisabled;

        #endregion
    }
}
