using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Utility
{
    public static class StringHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Pre">GY</param>
        /// <param name="Code">A001/001</param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string Generator(this string Pre, string Code)
        {
            //第1个字符
            char firstChar = Code[0];

            //如果第1位是字母 A001
            if (char.IsLetter(firstChar))
            {
                int MaxNum = Convert.ToInt32(Code.TrimStart(firstChar));

                //判断字母是否增位
                //999  3
                if ((MaxNum + 1).ToString().Length > Code.Length - 1)
                {
                    return $"{Pre}{(char)((byte)firstChar + 1)}{"1".PadLeft(Code.Length - 1, '0')}";
                }
                else
                {
                    return $"{Pre}{firstChar}{(MaxNum + 1).ToString().PadLeft(Code.Length - 1, '0')}";
                }
            }
            else
            {
                return $"{Pre}{(Convert.ToInt32(Code) + 1).ToString().PadLeft(Code.Length, '0')}";
            }
        }
    }
}
