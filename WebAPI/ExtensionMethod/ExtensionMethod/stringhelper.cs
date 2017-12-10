using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    public static class  stringhelper
    {
        public static string ChangeStringCase(this string inputString)
        {
            if(inputString.Length>0)
            {
                char[] array = inputString.ToCharArray();
                array[0] = char.IsUpper(array[0]) ? char.ToLower(array[0]) : char.ToUpper(array[0]);
                return new string(array);
            }
            return inputString;
        }
    }
}
