using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QMS.Domain.Extensions
{
    public static class TimeStampExtension
    {
        public static string AppendTimeStamp(this string fileName)
        {
            return string.Concat(
                Path.GetFileNameWithoutExtension(fileName),
                "_",
                DateTime.Now.ToString("yyyyMMddHHmmss"),
                Path.GetExtension(fileName)
                );
        }
    }
}
