using System;
using System.Collections.Generic;

namespace FunWithCastles.Settings
{
    public interface ISettingConverter
    {
        object ConvertTo(Type dstType, object src);
    }

    public class DefaultSettingConverter : ISettingConverter
    {
        private static readonly Dictionary<Type, Func<string, object>> _fromString;

        static DefaultSettingConverter()
        {
            _fromString = new Dictionary<Type, Func<string, object>>
            {
                [typeof(short)] = s => Convert.ToInt16(s),
                [typeof(int)] = s => Convert.ToInt32(s),
                [typeof(long)] = s => Convert.ToInt64(s),

                [typeof(ushort)] = s => Convert.ToUInt16(s),
                [typeof(uint)] = s => Convert.ToUInt32(s),
                [typeof(ulong)] = s => Convert.ToUInt64(s),

                [typeof(DateTime)] = s => Convert.ToDateTime(s),
                [typeof(TimeSpan)] = s => TimeSpan.Parse(s),
            };
        }

        public object ConvertTo(Type dstType, object src)
        {
            var srcType = src.GetType();
            if (srcType == dstType)
            {
                return src;
            }
            else if (src is string)
            {
                return _fromString[dstType](src as string);
            }
            else
            {
                return null;
            }
        }
    }
}