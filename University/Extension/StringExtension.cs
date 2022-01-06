using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Extension
{
    public static class StringExtension
    {
        /// <summary>
        /// This String Extension makes the string first element Capital and the other elements in the lower case
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
       public static string Cap(this string word)
        {
            char one = char.ToUpper(word[0]);

            string two = word.Remove(0, 1);

            return one + two.ToLower();
        }

        /// <summary>
        /// HashingCode Method Will Hash the given string According to the ASCII table
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HashingCode(this string str)
        {
            byte[] asciiBytes = Encoding.ASCII.GetBytes(str);

            return string.Join("", asciiBytes);
        }
    }
}
