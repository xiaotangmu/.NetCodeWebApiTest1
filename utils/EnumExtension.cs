using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApi1.utils
{
    /// <summary>
    /// 枚举扩展类
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 获取枚举的描述，需要DescriptionAttribute属性
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum e)
        {
            //获取枚举的Type类型对象
            var type = e.GetType();
            //获取枚举的所有字段
            var fields = type.GetFields();

            //遍历所有枚举的所有字段
            foreach (var field in fields)
            {
                if (field.Name != e.ToString())
                {
                    continue;
                }
                //第二个参数true表示查找EnumDisplayNameAttribute的继承链

                if (field.IsDefined(typeof(DescriptionAttribute), true))
                {
                    var attr = field.GetCustomAttribute(typeof(DescriptionAttribute), false) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }

            //如果没有找到自定义属性，直接返回属性项的名称
            return e.ToString();
        }

    }
}
