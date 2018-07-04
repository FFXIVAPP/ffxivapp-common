// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandManagerHelper.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   CommandManagerHelper.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.ViewModelBase {
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
    public static class CommandManagerHelper {
        /// <summary>
        /// </summary>
        /// <param name="handlers"> </param>
        internal static void AddHandlersToRequerySuggested(IEnumerable<WeakReference> handlers) {
            if (handlers == null) {
                return;
            }

            foreach (EventHandler handler in handlers.Select(handlerRef => handlerRef.Target).OfType<EventHandler>()) {
                CommandManager.RequerySuggested += handler;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="handlers"> </param>
        /// <param name="handler"> </param>
        internal static void AddWeakReferenceHandler(ref List<WeakReference> handlers, EventHandler handler) {
            AddWeakReferenceHandler(ref handlers, handler, -1);
        }

        /// <summary>
        /// </summary>
        /// <param name="handlers"> </param>
        /// <param name="handler"> </param>
        /// <param name="defaultListSize"> </param>
        internal static void AddWeakReferenceHandler(ref List<WeakReference> handlers, EventHandler handler, int defaultListSize) {
            if (handlers == null) {
                handlers = defaultListSize > 0
                               ? new List<WeakReference>(defaultListSize)
                               : new List<WeakReference>();
            }

            handlers.Add(new WeakReference(handler));
        }

        /// <summary>
        /// </summary>
        /// <param name="handlers"> </param>
        internal static void CallWeakReferenceHandlers(List<WeakReference> handlers) {
            if (handlers == null) {
                return;
            }

            EventHandler[] callees = new EventHandler[handlers.Count];
            var count = 0;
            for (var i = handlers.Count - 1; i >= 0; i--) {
                WeakReference reference = handlers[i];
                var handler = reference.Target as EventHandler;
                if (handler == null) {
                    handlers.RemoveAt(i);
                }
                else {
                    callees[count] = handler;
                    count++;
                }
            }

            for (var i = 0; i < count; i++) {
                EventHandler handler = callees[i];
                handler(null, EventArgs.Empty);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="handlers"> </param>
        internal static void RemoveHandlersFromRequerySuggested(IEnumerable<WeakReference> handlers) {
            if (handlers == null) {
                return;
            }

            foreach (EventHandler handler in handlers.Select(handlerRef => handlerRef.Target).OfType<EventHandler>()) {
                CommandManager.RequerySuggested -= handler;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="handlers"> </param>
        /// <param name="handler"> </param>
        internal static void RemoveWeakReferenceHandler(List<WeakReference> handlers, EventHandler handler) {
            if (handlers == null) {
                return;
            }

            for (var i = handlers.Count - 1; i >= 0; i--) {
                WeakReference reference = handlers[i];
                var existingHandler = reference.Target as EventHandler;
                if (existingHandler == null || existingHandler == handler) {
                    handlers.RemoveAt(i);
                }
            }
        }
    }
}