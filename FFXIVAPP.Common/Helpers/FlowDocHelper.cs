// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FlowDocHelper.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   FlowDocHelper.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Helpers {
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Media;

    using FFXIVAPP.Common.Converters;

    public class FlowDocHelper {
        private readonly StringToBrushConverter _stb = new StringToBrushConverter();

        /// <summary>
        /// </summary>
        /// <param name="time"> </param>
        /// <param name="playerName"></param>
        /// <param name="line"> </param>
        /// <param name="colors"> </param>
        /// <param name="flow"> </param>
        public void AppendFlow(string time, string playerName, string line, string[] colors, FlowDocumentReader flow) {
            Func<bool> append = delegate {
                DispatcherHelper.Invoke(
                    delegate {
                        object timeStampColor = this._stb.Convert(
                            string.IsNullOrWhiteSpace(colors[0])
                                ? "#FFFFFFFF"
                                : colors[0]);
                        object lineColor = this._stb.Convert(
                            string.IsNullOrWhiteSpace(colors[1])
                                ? "#FFFFFFFF"
                                : colors[1]);
                        var paraGraph = new Paragraph();
                        var timeStamp = new Span(new Run(time)) {
                            Foreground = (Brush) timeStampColor,
                            FontWeight = FontWeights.Bold,
                        };
                        var coloredLine = new Span(new Run(line)) {
                            Foreground = (Brush) lineColor,
                        };
                        paraGraph.Inlines.Add(timeStamp);
                        if (!string.IsNullOrWhiteSpace(playerName)) {
                            object playerColor = this._stb.Convert("#FFFF00FF");
                            var playerLine = new Span(new Run("[" + playerName + "] ")) {
                                Foreground = (Brush) playerColor,
                            };
                            paraGraph.Inlines.Add(playerLine);
                        }

                        paraGraph.Inlines.Add(coloredLine);
                        flow.Document.Blocks.Add(paraGraph);
                        flow.Document.Blocks.LastBlock.Loaded += BlockLoaded;
                        if (flow.Document.Blocks.Count <= 500) {
                            return;
                        }

                        flow.Document.Blocks.Clear();
                    });
                return true;
            };
            append.BeginInvoke(delegate { }, append);
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"> </param>
        private static void BlockLoaded(object sender, RoutedEventArgs e) {
            var block = (Block) sender;
            block.BringIntoView();
            block.Loaded -= BlockLoaded;
        }
    }
}