using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStringBuilder
{
    public class MyStringBuilder
    {
        private char[] stringArray;

        public MyStringBuilder()
        {
            stringArray = new char[0];
        }

        public int Length => stringArray.Length;

        public void Append(string s)
        {
            char[] sArray = s.ToCharArray();
            int originalLength = stringArray.Length;
            Array.Resize(ref stringArray, originalLength + sArray.Length);
            Array.Copy(sArray, 0, stringArray, originalLength, sArray.Length);
        }

        public void InsertAt(int index, string s)
        {
            if (index < 0 || index > stringArray.Length)
            {
                throw new IndexOutOfRangeException("Invalid index.");
            }

            char[] sArray = s.ToCharArray();
            int originalLength = stringArray.Length;
            Array.Resize(ref stringArray, originalLength + sArray.Length);
            Array.Copy(stringArray, index, stringArray, index + sArray.Length, originalLength - index);
            Array.Copy(sArray, 0, stringArray, index, sArray.Length);
        }

        public void RemoveDuplicates()
        {
            int tail = 0;
            for (int i = 0; i < stringArray.Length; i++)
            {
                int j;
                for (j = 0; j < tail; j++)
                {
                    if (stringArray[i] == stringArray[j])
                        break;
                }
                if (j == tail)
                {
                    stringArray[tail] = stringArray[i];
                    tail++;
                }
            }
            Array.Resize(ref stringArray, tail);
        }

        public void RemoveWhitespaces()
        {
            string modifiedString = new string(stringArray);
            modifiedString = modifiedString.Replace(" ", string.Empty);
            modifiedString = modifiedString.Replace("\t", string.Empty);
            modifiedString = modifiedString.Replace("\n", string.Empty);
            modifiedString = modifiedString.Replace("\r", string.Empty);
            stringArray = modifiedString.ToCharArray();
        }

        public string GetString()
        {
            return new string(stringArray);
        }

        public bool IsBlank()
        {
            if (stringArray.Length == 0)
            {
                return true;
            }

            foreach (char c in stringArray)
            {
                if (!char.IsWhiteSpace(c))
                {
                    return false;
                }
            }
            return true;
        }

        public string OnBlank(string defaultString)
        {
            if (IsBlank())
            {
                return defaultString;
            }

            return GetString();
        }

    }
}
