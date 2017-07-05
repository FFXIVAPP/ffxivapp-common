// FFXIVAPP.Common ~ LogItem.cs
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
using NLog;

namespace FFXIVAPP.Common.Models
{
    public class LogItem
    {
        public LogItem(string message)
        {
            Message = string.IsNullOrWhiteSpace(message) ? "LogItem: Called Without Message" : message;
        }

        public LogItem(Exception exception, bool levelIsError = false)
        {
            Message = exception?.Message ?? "LogItem: Called Without Exception";
            Exception = exception;
            if (levelIsError)
            {
                LogLevel = LogLevel.Error;
            }
        }

        public LogItem(string message, Exception exception, bool levelIsError = false)
        {
            Message = string.IsNullOrWhiteSpace(message) ? exception?.Message ?? "LogItem: Called Without Message" : message;
            Exception = exception;
            if (Exception != null && levelIsError)
            {
                LogLevel = LogLevel.Error;
            }
        }

        public LogLevel LogLevel { get; set; } = LogLevel.Trace;
        public Exception Exception { get; set; }
        public string Message { get; set; }
    }
}
