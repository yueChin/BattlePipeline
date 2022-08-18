using System;
using System.Text;

namespace Kits.DevlpKit.Helpers.StringHelpers
{
    /// <summary>
    /// 字符相关的实用函数。
    /// </summary>
    public static class StrFormatHelper
    {
        private const int c_StringBuilderCapacity = 1024;

        [ThreadStatic] 
        private static StringBuilder s_CachedStringBuilder = null;

        /// <summary>
        /// 获取格式化字符串。
        /// </summary>
        /// <param name="format">字符串格式。</param>
        /// <param name="arg0">字符串参数 0。</param>
        /// <returns>格式化后的字符串。</returns>
        public static string Format(string format, object arg0)
        {
            if (format == null)
            {
                //throw new GameFrameworkException("Format is invalid.");
                return null;
            }

            CheckCachedStringBuilder();
            s_CachedStringBuilder.Length = 0;
            s_CachedStringBuilder.AppendFormat(format, arg0);
            return s_CachedStringBuilder.ToString();
        }

        /// <summary>
        /// 获取格式化字符串。
        /// </summary>
        /// <param name="format">字符串格式。</param>
        /// <param name="arg0">字符串参数 0。</param>
        /// <param name="arg1">字符串参数 1。</param>
        /// <returns>格式化后的字符串。</returns>
        public static string Format(string format, object arg0, object arg1)
        {
            if (format == null)
            {
                //throw new GameFrameworkException("Format is invalid.");
                return null;
            }

            CheckCachedStringBuilder();
            s_CachedStringBuilder.Length = 0;
            s_CachedStringBuilder.AppendFormat(format, arg0, arg1);
            return s_CachedStringBuilder.ToString();
        }

        /// <summary>
        /// 获取格式化字符串。
        /// </summary>
        /// <param name="format">字符串格式。</param>
        /// <param name="arg0">字符串参数 0。</param>
        /// <param name="arg1">字符串参数 1。</param>
        /// <param name="arg2">字符串参数 2。</param>
        /// <returns>格式化后的字符串。</returns>
        public static string Format(string format, object arg0, object arg1, object arg2)
        {
            if (format == null)
            {
                //throw new GameFrameworkException("Format is invalid.");
                return null;
            }

            CheckCachedStringBuilder();
            s_CachedStringBuilder.Length = 0;
            s_CachedStringBuilder.AppendFormat(format, arg0, arg1, arg2);
            return s_CachedStringBuilder.ToString();
        }

        /// <summary>
        /// 获取格式化字符串。
        /// </summary>
        /// <param name="format">字符串格式。</param>
        /// <param name="args">字符串参数。</param>
        /// <returns>格式化后的字符串。</returns>
        public static string Format(string format, params object[] args)
        {
            if (format == null)
            {
                //throw new GameFrameworkException("Format is invalid.");
                return null;
            }

            if (args == null)
            {
                //throw new GameFrameworkException("Args is invalid.");
                return null;
            }

            CheckCachedStringBuilder();
            s_CachedStringBuilder.Length = 0;
            s_CachedStringBuilder.AppendFormat(format, args);
            return s_CachedStringBuilder.ToString();
        }

        private static void CheckCachedStringBuilder()
        {
            if (s_CachedStringBuilder != null)
                return;
            s_CachedStringBuilder = new StringBuilder(c_StringBuilderCapacity);
        }
    }
}