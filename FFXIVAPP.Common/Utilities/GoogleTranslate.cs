// FFXIVAPP.Common
// FFXIVAPP & Related Plugins/Modules
// Copyright © 2007 - 2015 Ryan Wilson - All Rights Reserved
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
using System.Net;
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

        private static string _baseUrl = "http://translate.google.ca/translate_t?hl=&ie=UTF-8&text=";
        private static HttpWebRequest _httpWReq;
        private static HttpWebResponse _httpWResp;

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
            var result = new GoogleTranslateResult
            {
                Original = textToTranslate
            };
            try
            {
                if (jpOnly)
                {
                    var url = String.Format("{0}{1}&sl={2}&tl={3}#", _baseUrl, textToTranslate, inLang, outLang);
                    _httpWReq = (HttpWebRequest) WebRequest.Create(url);
                }
                else
                {
                    var url = String.Format("{0}{1}&sl=auto&tl={2}#auto|{2}|{1}", _baseUrl, textToTranslate, outLang);
                    _httpWReq = (HttpWebRequest) WebRequest.Create(url);
                }
                _httpWReq.UserAgent = "Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_6_3; en-US) AppleWebKit/533.4 (KHTML, like Gecko) Chrome/5.0.375.70 Safari/533.4";
                _httpWResp = (HttpWebResponse) _httpWReq.GetResponse();
                var stream = _httpWResp.GetResponseStream();
                if (_httpWResp.StatusCode != HttpStatusCode.OK || stream == null)
                {
                }
                else
                {
                    var doc = new HtmlDocument();
                    doc.Load(stream, true);
                    var translated = doc.DocumentNode.SelectSingleNode("//span[@id='result_box']");
                    if (translated != null)
                    {
                        result.Translated = HttpUtility.HtmlDecode(translated.InnerText);
                    }
                    var romanization = doc.DocumentNode.SelectSingleNode("//div[@id='res-translit']");
                    if (romanization != null)
                    {
                        result.Romanization = HttpUtility.HtmlDecode(romanization.InnerText);
                    }
                }
            }
            catch (Exception ex)
            {
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
