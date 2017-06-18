// FFXIVAPP.Common ~ Logging.cs
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
using FFXIVAPP.Common.Models;
using NLog;

namespace FFXIVAPP.Common.Utilities
{
    public static class Logging
    {
        public static void Log(Logger logger, string message = "", Exception exception = null)
        {
            Log(logger, new LogItem(message, exception));
        }

        /// <summary>
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="logItem"></param>
        public static void Log(Logger logger, LogItem logItem)
        {
            if (!Constants.EnableNLog)
            {
                return;
            }
            switch (String.IsNullOrWhiteSpace(logItem.Message))
            {
                case true:
                    if (logItem.Exception == null)
                    {
                        return;
                    }
                    logger.LogException(logItem.LogLevel, logItem.Exception.Message, logItem.Exception);
                    break;
                case false:
                    if (logItem.Exception == null)
                    {
                        logger.Log(logItem.LogLevel, logItem.Message);
                    }
                    else
                    {
                        logger.LogException(logItem.LogLevel, logItem.Message, logItem.Exception);
                    }
                    break;
            }
        }
    }
}
