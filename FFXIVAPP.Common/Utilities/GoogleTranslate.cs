// FFXIVAPP.Common ~ GoogleTranslate.cs
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
using System.Collections;
using System.Net.Http;
using System.Text;
using System.Web;
using FFXIVAPP.Common.Models;
using HtmlAgilityPack;
using NLog;

namespace FFXIVAPP.Common.Utilities
{
    public static class GoogleTranslate
    {
        #region Logger

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        private static string _baseUrl = "http://translate.google.com/translate_t?hl=&ie=UTF-8&text={0}&sl={1}&tl={2}";

        private static HttpClient HTTPClient = new HttpClient();

        #region Property Backings

        private static Hashtable _offsets;

        public static Hashtable Offsets
        {
            get { return _offsets ?? (_offsets = GetLanguage()); }
        }

        #endregion

        #region Translation

        /// <summary>
        /// </summary>
        /// <param name="textToTranslate"> </param>
        /// <param name="inLang"> </param>
        /// <param name="outLang"> </param>
        /// <param name="jpOnly"> </param>
        /// <returns> </returns>
        public static GoogleTranslateResult Translate(string textToTranslate, string inLang, string outLang, bool jpOnly)
        {
            Logging.Log(Logger, "Calling Google");

            var result = new GoogleTranslateResult
            {
                Original = textToTranslate
            };
            try
            {
                var url = string.Format(_baseUrl, textToTranslate, jpOnly ? inLang : "auto", outLang);

                Logging.Log(Logger, $"Resolved URL: {url}");

                HTTPClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_6_3; en-US) AppleWebKit/533.4 (KHTML, like Gecko) Chrome/5.0.375.70 Safari/533.4");

                using (var response = HTTPClient.GetStreamAsync(new Uri(url)))
                {
                    var stream = response.Result;

                    var doc = new HtmlDocument();
                    doc.Load(stream, Encoding.UTF8);

                    var translated = doc.DocumentNode.SelectSingleNode("//span[@id='result_box']");
                    if (translated != null)
                    {
                        Logging.Log(Logger, $"Translated: {translated.InnerText}");
                        result.Translated = HttpUtility.HtmlDecode(translated.InnerText);
                    }
                    var romanization = doc.DocumentNode.SelectSingleNode("//div[@id='res-translit']");
                    if (romanization != null)
                    {
                        Logging.Log(Logger, $"Romanized: {romanization.InnerText}");
                        result.Romanization = HttpUtility.HtmlDecode(romanization.InnerText);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.Log(Logger, ex.Message, ex);
            }
            return result;
        }

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        private static Hashtable GetLanguage()
        {
            return new Hashtable
            {
                {
                    "Albanian", "sq"
                },
                {
                    "Arabic", "ar"
                },
                {
                    "Bulgarian", "bg"
                },
                {
                    "Catalan", "ca"
                },
                {
                    "Chinese (Simplified)", "zh-CN"
                },
                {
                    "Chinese (Traditional)", "zh-TW"
                },
                {
                    "Croatian", "hr"
                },
                {
                    "Czech", "cs"
                },
                {
                    "Danish", "da"
                },
                {
                    "Dutch", "nl"
                },
                {
                    "English", "en"
                },
                {
                    "Estonian", "et"
                },
                {
                    "Filipino", "tl"
                },
                {
                    "Finnish", "fi"
                },
                {
                    "French", "fr"
                },
                {
                    "Galician", "gl"
                },
                {
                    "German", "de"
                },
                {
                    "Greek", "el"
                },
                {
                    "Hebrew", "iw"
                },
                {
                    "Hindi", "hi"
                },
                {
                    "Hungarian", "hu"
                },
                {
                    "Indonesian", "id"
                },
                {
                    "Italian", "it"
                },
                {
                    "Japanese", "ja"
                },
                {
                    "Korean", "ko"
                },
                {
                    "Latvian", "lv"
                },
                {
                    "Lithuanian", "lt"
                },
                {
                    "Maltese", "mt"
                },
                {
                    "Norwegian", "no"
                },
                {
                    "Polish", "pl"
                },
                {
                    "Portuguese", "pt"
                },
                {
                    "Romanian", "ro"
                },
                {
                    "Russian", "ru"
                },
                {
                    "Serbian", "sr"
                },
                {
                    "Slovak", "sk"
                },
                {
                    "Slovenian", "sl"
                },
                {
                    "Spanish", "es"
                },
                {
                    "Swedish", "sv"
                },
                {
                    "Thai", "th"
                },
                {
                    "Turkish", "tr"
                },
                {
                    "Ukrainian", "uk"
                },
                {
                    "Vietnamese", "vi"
                }
            };
        }

        #endregion
    }
}
