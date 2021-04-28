// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CognitiveTranslateProvider.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   CognitiveTranslateProvider.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Translation {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Text;

    using FFXIVAPP.Common.Models;
    using FFXIVAPP.Common.Utilities;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using NLog;

    public class CognitiveTranslateProvider : ITranslationProvider {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static string _baseUrl = "https://api.cognitive.microsofttranslator.com/translate?api-version=3.0&from={0}&to={1}";

        private static HttpClient _httpClient = new HttpClient();

        private string _region;

        private string _serviceKey;

        public CognitiveTranslateProvider(string serviceKey, string region) {
            this._serviceKey = serviceKey;
            this._region = region;
        }

        public TranslationResult TranslateText(string textToTranslate, string fromLanguage, string toLanguage, bool JPOnly) {
            Logging.Log(Logger, "Calling Cognitive");

            var result = new TranslationResult {
                Original = textToTranslate,
            };

            try {
                var url = string.Format(
                    _baseUrl, JPOnly
                                  ? fromLanguage
                                  : this.DetectLanguage(textToTranslate), toLanguage);

                Object[] body = {
                    new {
                        Text = textToTranslate,
                    },
                };
                var requestBody = JsonConvert.SerializeObject(body);

                using var request = new HttpRequestMessage {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new StringContent(requestBody, Encoding.UTF8, "application/json"),
                };
                request.Headers.Add("Ocp-Apim-Subscription-Key", this._serviceKey);
                request.Headers.Add("Ocp-Apim-Subscription-Region", this._region);
                request.Headers.Add("X-ClientTraceId", Guid.NewGuid().ToString());

                var response = _httpClient.SendAsync(request).GetAwaiter().GetResult();
                var responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                var translateResult = JsonConvert.DeserializeObject<List<Dictionary<string, List<Dictionary<string, string>>>>>(responseBody);
                var translation = translateResult[0]["translations"][0]["text"];

                // Update the translation field
                result.Translated = translation;
            }
            catch (Exception ex) {
                Logging.Log(Logger, new LogItem(ex, true));
            }

            return result;
        }

        private string DetectLanguage(string text) {
            var url = "https://api.cognitive.microsofttranslator.com/detect?api-version=3.0";

            // Create request to Detect languages with Translator Text
            var detectLanguageWebRequest = (HttpWebRequest) WebRequest.Create(url);
            detectLanguageWebRequest.Headers.Add("Ocp-Apim-Subscription-Key", this._serviceKey);
            detectLanguageWebRequest.Headers.Add("Ocp-Apim-Subscription-Region", this._region);
            detectLanguageWebRequest.ContentType = "application/json; charset=utf-8";
            detectLanguageWebRequest.Method = "POST";

            // Send request
            var body = "[{ \"Text\": " + JsonConvert.SerializeObject(text) + " }]";
            byte[] data = Encoding.UTF8.GetBytes(body);

            detectLanguageWebRequest.ContentLength = data.Length;

            using (Stream requestStream = detectLanguageWebRequest.GetRequestStream()) {
                requestStream.Write(data, 0, data.Length);
            }

            HttpWebResponse response = (HttpWebResponse) detectLanguageWebRequest.GetResponse();

            // Read and parse JSON response
            Stream responseStream = response.GetResponseStream();
            if (responseStream != null) {
                var json = new StreamReader(responseStream, Encoding.GetEncoding("utf-8")).ReadToEnd();
                var items = JArray.Parse(json);

                // Fish out the detected language code
                dynamic language = items?[0];
                if (language?["score"] > (decimal) 0.5) {
                    return language?["language"];
                }
            }

            return "en";
        }
    }
}