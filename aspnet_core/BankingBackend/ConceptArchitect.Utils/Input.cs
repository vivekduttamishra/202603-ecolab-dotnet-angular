using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Utils
{
    public class Input
    {

        public static string GetString(string prompt, string defaultValue = "")
        {
            Console.Write(prompt);
            var result = Console.ReadLine();
            if(result==null || result=="")
                return defaultValue;
            else
                return result;
        }

        public static T Get<T>(string prompt, T defaultValue=default(T))
        {
            try
            {
                var result = GetString(prompt);
                return (T)Convert.ChangeType(result, typeof(T));
            }
            catch
            {
                return defaultValue;
            }
        }



    }
}
