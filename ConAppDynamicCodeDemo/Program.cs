using System;
using System.Reflection;
using static System.Console;

namespace ConAppDynamicCodeDemo
{
    class Program
    {
        /// <summary>
        /// BCIT COMP3618 Week 8 Lab 4
        /// Krzysztof Szczurowski
        /// Repo: https://github.com/kriss3/BCIT_COMP3618_Week8_Lab4.git
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string path = @"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\System.Web.dll";
            
            // Get the Assembly from the file
            Assembly webAssembly = Assembly.LoadFile(path);
           
            // Get the type to the HttpUtility class
            Type utilType = webAssembly.GetType("System.Web.HttpUtility");
            
            // Get the static HtmlEncode and HtmlDecode methods
            MethodInfo encode = utilType.GetMethod("HtmlEncode", new Type[] { typeof(string) });
            MethodInfo decode = utilType.GetMethod("HtmlDecode", new Type[] { typeof(string) });
            
            // Create a string to be encoded
            string originalString = "This is Sally & Jack's Anniversary <sic>";
            WriteLine(originalString);
            // encode it and show the encoded value
            string encoded = (string)encode.Invoke(null, new object[] { originalString });
            WriteLine(encoded);
            
            // decode it to make sure it comes back right
            string decoded = (string)decode.Invoke(null, new object[] { encoded });
            WriteLine(decoded);
        }
    }
}
