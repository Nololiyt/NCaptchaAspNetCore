using System;
using System.IO;

namespace Base64ToFile
{
    internal class Program
    {
        private static void Main(string[] args)
        {
#warning Tip 5: A Tool Here.
            // This tool may help when debugging.
            try
            {
                for (; ; )
                {
                    Console.WriteLine("Input the base64 string here " +
                        "(or input any other things to exit):");

                    var r = Convert.FromBase64String(Console.ReadLine());
                    Console.WriteLine("Input the destination file name here:");
                    File.WriteAllBytes(Console.ReadLine(), r);
                    Console.WriteLine("Saved.");
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
