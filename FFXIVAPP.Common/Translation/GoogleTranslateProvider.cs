// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoogleTranslateProvider.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   GoogleTranslateProvider.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Translation {
    using System;
    using System.Net.Http;

    using FFXIVAPP.Common.Models;
    using FFXIVAPP.Common.Utilities;

    using Newtonsoft.Json.Linq;

    using NLog;

    public class GoogleTranslateProvider : ITranslationProvider {
        private readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private string _baseUrl = "https://translation.googleapis.com/language/translate/v2?key={0}&source={1}&target={2}&q={3}&format=text";

        private HttpClient _httpClient = new HttpClient();

        private string _serviceKey;

        public GoogleTranslateProvider(string serviceKey) {
            this._serviceKey = serviceKey;
        }

        public TranslationResult TranslateText(string textToTranslate, string fromLanguage, string toLanguage, bool JPOnly) {
            Logging.Log(this.Logger, "Calling Google");

            var result = new TranslationResult {
                Original = textToTranslate,
            };

            try {
                var url = string.Format(
                    this._baseUrl, this._serviceKey, JPOnly
                                                         ? fromLanguage
                                                         : "", toLanguage, textToTranslate);

                Logging.Log(this.Logger, $"Resolved URL: {url}");

                using var request = new HttpRequestMessage {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                };

                var response = this._httpClient.SendAsync(request).GetAwaiter().GetResult();
                var responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                var translateResult = JObject.Parse(responseBody);
                var translation = translateResult["data"]["translations"][0]["translatedText"];

                result.Translated = translation.ToString();
            }
            catch (Exception ex) {
                Logging.Log(this.Logger, new LogItem(ex, true));
            }

            return result;
        }
    }
}