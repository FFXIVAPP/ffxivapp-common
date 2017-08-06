// FFXIVAPP.Common ~ FlowDocHelper.cs
// 
// Copyright © 2007 - 2017 Ryan Wilson - All Rights Reserved
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
            Func<bool> append = delegate
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
            append.BeginInvoke(delegate { }, append);
        }
    }
}
