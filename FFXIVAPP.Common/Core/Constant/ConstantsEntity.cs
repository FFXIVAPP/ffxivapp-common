﻿// FFXIVAPP.Common
// ConstantsEntity.cs
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

using System.Collections.Generic;
using System.Globalization;
using FFXIVAPP.Common.Core.Constant.Interfaces;

namespace FFXIVAPP.Common.Core.Constant
{
    public class ConstantsEntity : IConstantsEntity
    {
        public string Theme { get; set; }
        public string UIScale { get; set; }
        public Dictionary<string, string> AutoTranslate { get; set; }
        public Dictionary<string, string> ChatCodes { get; set; }
        public Dictionary<string, ActionInfo> Actions { get; set; }
        public string ChatCodesXml { get; set; }
        public Dictionary<string, string[]> Colors { get; set; }
        public CultureInfo CultureInfo { get; set; }
        public string CharacterName { get; set; }
        public string ServerName { get; set; }
        public string GameLanguage { get; set; }
        public bool EnableHelpLabels { get; set; }
        public bool EnableNLog { get; set; }
        public bool EnableNetworkReading { get; set; }
    }
}
