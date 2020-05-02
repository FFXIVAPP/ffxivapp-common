// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlHelper.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2020 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   XmlHelper.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Helpers {
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;

    using FFXIVAPP.Common.Models;

    public static class XmlHelper {
        /// <summary>
        /// </summary>
        /// <param name="xDoc"> </param>
        /// <param name="xNode"> </param>
        public static void DeleteXmlNode(XDocument xDoc, string xNode) {
            IEnumerable<XElement> query = from node in xDoc.Descendants(xNode)
                                          select node;
            query.ToList().ForEach(node => node.Remove());
        }

        public static string GetValue(XDocument xDoc, string xElement, string xKey, string xValue) {
            IEnumerable<XElement> items = xDoc.Descendants().Elements(xElement).Where(element => (string) element.Attribute("Key") == xKey);
            return (string) items.First().Element(xValue);
        }

        /// <summary>
        /// </summary>
        /// <param name="xValue"> </param>
        /// <returns> </returns>
        public static string SanitizeXmlString(string xValue) {
            if (xValue == null) {
                return string.Empty;
            }

            var buffer = new StringBuilder(xValue.Length);
            foreach (var xChar in xValue.Where(xChar => IsLegalXmlChar(xChar))) {
                buffer.Append(xChar);
            }

            return buffer.ToString();
        }

        /// <summary>
        /// </summary>
        /// <param name="xDoc"> </param>
        /// <param name="xRoot"> </param>
        /// <param name="xNode"> </param>
        /// <param name="xKey"> </param>
        /// <param name="xValuePairs"> </param>
        public static void SaveXmlNode(XDocument xDoc, string xRoot, string xNode, string xKey, IEnumerable<XValuePair> xValuePairs) {
            XElement element = xDoc.Element(xRoot);
            if (element == null) {
                return;
            }

            var newElement = new XElement(xNode, new XAttribute("Key", xKey));
            foreach (XValuePair s in xValuePairs) {
                newElement.Add(new XElement(s.Key, SanitizeXmlString(s.Value)));
            }

            element.Add(newElement);
        }

        /// <summary>
        /// </summary>
        /// <param name="xChar"> </param>
        /// <returns> </returns>
        private static bool IsLegalXmlChar(int xChar) {
            return xChar == 0x9 || xChar == 0xA || xChar == 0xD || xChar >= 0x20 && xChar <= 0xD7FF || xChar >= 0xE000 && xChar <= 0xFFFD || xChar >= 0x10000 && xChar <= 0x10FFFF;
        }
    }
}