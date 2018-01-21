using System;

namespace FunWithCastles.Settings
{
    public interface ISettingConverter
    {
        object ConvertTo(Type dstType, object src);
    }
    
    public class DefaultSettingConverter : ISettingConverter
    {
        public object ConvertTo(Type dstType, object src)
        {
            var srcType = src.GetType();
            if (srcType == dstType)
            {
                return src;
            }
            else
            {
                return null;
            }
        }
    }
}