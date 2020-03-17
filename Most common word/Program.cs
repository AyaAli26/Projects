using System;
using System.Collections.Generic;

namespace Most_common_word
{
    class Program
    {
        static void Main(string[] args)
        {
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            //string paragraph="a, a, a, a, b,b,b,c, c";
            string[] banned = { "hit" };
            //string[] banned={"a"};
            String output = MostCommonWord(paragraph, banned);
            Console.WriteLine(output);
            Console.ReadLine();
        }

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            string MostCommonWord = "";
            char[] delimiterChars = new char[] { ',', '.', '!', '?',';','\'',' '};
            string[] words = paragraph.ToLower().Split(delimiterChars);
            var dict = new Dictionary<String, int>();
            int maxnumber = 0;
            foreach (var ele in words)
            {
                bool found = false;
                if (ele.Equals(""))
                    continue;

                for (int i = 0; i < delimiterChars.Length; i++)
                {
                    if (ele.Contains(delimiterChars[i]))
                    {

                        ele.Replace(delimiterChars[i],'\0');
                    }
                }
                foreach (var ban in banned)
                {
                    if (ele.Equals(ban))
                    {
                        found = true;
                    }
                }
                if (!found)
                {
                    if (dict.ContainsKey(ele))
                    {
                        dict[ele]++;

                    }
                    else
                        dict[ele] = 1;
                }
                    
            }
            foreach (var index in dict)
            {
                if(index.Value>maxnumber)
                {
                    maxnumber = index.Value;
                    MostCommonWord = index.Key;
                }
            }
           
            return MostCommonWord;
        }
    }
}
