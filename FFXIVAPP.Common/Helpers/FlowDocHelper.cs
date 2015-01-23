// FFXIVAPP.Common
// FlowDocHelper.cs
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using FFXIVAPP.Common.Converters;

namespace FFXIVAPP.Common.Helpers
{
    public class FlowDocHelper
    {
        private readonly StringToBrushConverter _stb = new StringToBrushConverter();

        /// <summary>
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        private static void BlockLoaded(object sender, RoutedEventArgs e)
        {
            var block = (Block) sender;
            block.BringIntoView();
            block.Loaded -= BlockLoaded;
        }

        /// <summary>
        /// </summary>
        /// <param name="time"> </param>
        /// <param name="playerName"></param>
        /// <param name="line"> </param>
        /// <param name="colors"> </param>
        /// <param name="flow"> </param>
        public void AppendFlow(string time, string playerName, string line, string[] colors, FlowDocumentReader flow)
        {
            Func<bool> funcAppend = delegate
            {
                DispatcherHelper.Invoke(delegate
                {
                    var timeStampColor = _stb.Convert(String.IsNullOrWhiteSpace(colors[0]) ? "#FFFFFFFF" : colors[0]);
                    var lineColor = _stb.Convert(String.IsNullOrWhiteSpace(colors[1]) ? "#FFFFFFFF" : colors[1]);
                    var paraGraph = new Paragraph();
                    var timeStamp = new Span(new Run(time))
                    {
                        Foreground = (Brush) timeStampColor,
                        FontWeight = FontWeights.Bold
                    };
                    var coloredLine = new Span(new Run(line))
                    {
                        Foreground = (Brush) lineColor
                    };
                    paraGraph.Inlines.Add(timeStamp);
                    if (!String.IsNullOrWhiteSpace(playerName))
                    {
                        var playerColor = _stb.Convert("#FFFF00FF");
                        var playerLine = new Span(new Run("[" + playerName + "] "))
                        {
                            Foreground = (Brush) playerColor
                        };
                        paraGraph.Inlines.Add(playerLine);
                    }
                    paraGraph.Inlines.Add(coloredLine);
                    flow.Document.Blocks.Add(paraGraph);
                    flow.Document.Blocks.LastBlock.Loaded += BlockLoaded;
                    if (flow.Document.Blocks.Count <= 500)
                    {
                        return;
                    }
                    flow.Document.Blocks.Clear();
                });
                return true;
            };
            funcAppend.BeginInvoke(null, null);
        }
    }
}
