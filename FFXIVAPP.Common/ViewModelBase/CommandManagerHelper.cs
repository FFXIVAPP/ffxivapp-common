// FFXIVAPP.Common
// CommandManagerHelper.cs
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
using System.Linq;
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
    public static class CommandManagerHelper
    {
        /// <summary>
        /// </summary>
        /// <param name="handlers"> </param>
        internal static void CallWeakReferenceHandlers(List<WeakReference> handlers)
        {
            if (handlers == null)
            {
                return;
            }
            var callees = new EventHandler[handlers.Count];
            var count = 0;
            for (var i = handlers.Count - 1; i >= 0; i--)
            {
                var reference = handlers[i];
                var handler = reference.Target as EventHandler;
                if (handler == null)
                {
                    handlers.RemoveAt(i);
                }
                else
                {
                    callees[count] = handler;
                    count++;
                }
            }
            for (var i = 0; i < count; i++)
            {
                var handler = callees[i];
                handler(null, EventArgs.Empty);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="handlers"> </param>
        internal static void AddHandlersToRequerySuggested(IEnumerable<WeakReference> handlers)
        {
            if (handlers == null)
            {
                return;
            }
            foreach (var handler in handlers.Select(handlerRef => handlerRef.Target)
                                            .OfType<EventHandler>())
            {
                CommandManager.RequerySuggested += handler;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="handlers"> </param>
        internal static void RemoveHandlersFromRequerySuggested(IEnumerable<WeakReference> handlers)
        {
            if (handlers == null)
            {
                return;
            }
            foreach (var handler in handlers.Select(handlerRef => handlerRef.Target)
                                            .OfType<EventHandler>())
            {
                CommandManager.RequerySuggested -= handler;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="handlers"> </param>
        /// <param name="handler"> </param>
        internal static void AddWeakReferenceHandler(ref List<WeakReference> handlers, EventHandler handler)
        {
            AddWeakReferenceHandler(ref handlers, handler, -1);
        }

        /// <summary>
        /// </summary>
        /// <param name="handlers"> </param>
        /// <param name="handler"> </param>
        /// <param name="defaultListSize"> </param>
        internal static void AddWeakReferenceHandler(ref List<WeakReference> handlers, EventHandler handler, int defaultListSize)
        {
            if (handlers == null)
            {
                handlers = (defaultListSize > 0 ? new List<WeakReference>(defaultListSize) : new List<WeakReference>());
            }

            handlers.Add(new WeakReference(handler));
        }

        /// <summary>
        /// </summary>
        /// <param name="handlers"> </param>
        /// <param name="handler"> </param>
        internal static void RemoveWeakReferenceHandler(List<WeakReference> handlers, EventHandler handler)
        {
            if (handlers == null)
            {
                return;
            }
            for (var i = handlers.Count - 1; i >= 0; i--)
            {
                var reference = handlers[i];
                var existingHandler = reference.Target as EventHandler;
                if ((existingHandler == null) || (existingHandler == handler))
                {
                    handlers.RemoveAt(i);
                }
            }
        }
    }
}
