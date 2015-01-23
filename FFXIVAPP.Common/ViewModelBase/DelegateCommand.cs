// FFXIVAPP.Common
// DelegateCommand.cs
// 
// Copyright © 2007 - 2015 Ryan Wilson - All Rights Reserved
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions are met: 
// 
//  * Redistributions of source code must retain the above copyright notice, 
//    this list of conditions and the following disclaimer. 
//  * Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution. 
//  * Neither the name of SyndicatedLife nor the names of its contributors may 
//    be used to endorse or promote products derived from this software 
//    without specific prior written permission. 
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
// POSSIBILITY OF SUCH DAMAGE. 

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
