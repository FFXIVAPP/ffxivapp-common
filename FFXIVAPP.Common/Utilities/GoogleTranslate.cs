// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoogleTranslate.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   GoogleTranslate.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Windows.Documents;
using Newtonsoft.Json;

namespace FFXIVAPP.Common.Utilities {
    using System;
    using System.Collections;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;

    using FFXIVAPP.Common.Models;

    using HtmlAgilityPack;

    using NLog;

    public static class GoogleTranslate {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static string _baseUrl = "https://translate.googleapis.com/translate_a/single?client=gtx&sl={1}&tl={2}&dt=t&q={0}";

        private static Hashtable _offsets;

        private static HttpClient HTTPClient = new HttpClient();

        public static Hashtable Offsets {
            get {
                return _offsets ?? (_offsets = GetLanguage());
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="textToTranslate"> </param>
        /// <param name="inLang"> </param>
        /// <param name="outLang"> </param>
        /// <param name="jpOnly"> </param>
        /// <returns> </returns>
        public static GoogleTranslateResult Translate(string textToTranslate, string inLang, string outLang, bool jpOnly) {
            Logging.Log(Logger, "Calling Google");

            var result = new GoogleTranslateResult {
                Original = textToTranslate
            };
            try {
                var url = string.Format(
                    _baseUrl,
                    textToTranslate,
                    jpOnly
                        ? inLang
                        : "auto",
                    outLang);

                Logging.Log(Logger, $"Resolved URL: {url}");

                HTTPClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_6_3; en-US) AppleWebKit/533.4 (KHTML, like Gecko) Chrome/5.0.375.70 Safari/533.4");

                using (Task<string> response = HTTPClient.GetStringAsync(new Uri(url))) {
                    string translateResult = response.Result;

                    var json = JsonConvert.DeserializeObject<List<dynamic>>(translateResult);
                    var items = json?[0];

                    result.Translated = items?[0]?[0];
                    result.Romanization = items?[0]?[0];
                }
            }
            catch (Exception ex) {
                Logging.Log(Logger, new LogItem(ex, true));
            }

            return result;
        }

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        private static Hashtable GetLanguage() {
            return new Hashtable {
                {
                    "Albanian", "sq"
                }, {
                    "Arabic", "ar"
                }, {
                    "Bulgarian", "bg"
                }, {
                    "Catalan", "ca"
                }, {
                    "Chinese (Simplified)", "zh-CN"
                }, {
                    "Chinese (Traditional)", "zh-TW"
                }, {
                    "Croatian", "hr"
                }, {
                    "Czech", "cs"
                }, {
                    "Danish", "da"
                }, {
                    "Dutch", "nl"
                }, {
                    "English", "en"
                }, {
                    "Estonian", "et"
                }, {
                    "Filipino", "tl"
                }, {
                    "Finnish", "fi"
                }, {
                    "French", "fr"
                }, {
                    "Galician", "gl"
                }, {
                    "German", "de"
                }, {
                    "Greek", "el"
                }, {
                    "Hebrew", "iw"
                }, {
                    "Hindi", "hi"
                }, {
                    "Hungarian", "hu"
                }, {
                    "Indonesian", "id"
                }, {
                    "Italian", "it"
                }, {
                    "Japanese", "ja"
                }, {
                    "Korean", "ko"
                }, {
                    "Latvian", "lv"
                }, {
                    "Lithuanian", "lt"
                }, {
                    "Maltese", "mt"
                }, {
                    "Norwegian", "no"
                }, {
                    "Polish", "pl"
                }, {
                    "Portuguese", "pt"
                }, {
                    "Romanian", "ro"
                }, {
                    "Russian", "ru"
                }, {
                    "Serbian", "sr"
                }, {
                    "Slovak", "sk"
                }, {
                    "Slovenian", "sl"
                }, {
                    "Spanish", "es"
                }, {
                    "Swedish", "sv"
                }, {
                    "Thai", "th"
                }, {
                    "Turkish", "tr"
                }, {
                    "Ukrainian", "uk"
                }, {
                    "Vietnamese", "vi"
                }
            };
        }
    }
}