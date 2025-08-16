using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSSTCommon
{
    internal static class IS
    {
        internal static bool CheckFormat(byte[] data, string expected)
        {
            string s = "";
            foreach (byte b in data)
            {
                s += (char)b;
            }
            if(s == expected)
            {
                return true;
            } else
            {
                return false;
            }
        }

        internal static bool CheckFormat(uint data, uint expected)
        {
            if (data == expected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
