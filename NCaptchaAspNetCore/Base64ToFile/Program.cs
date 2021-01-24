using System;
using System.IO;

namespace Base64ToFile
{
#warning A tip here: This tools may help.
    class Program
    {
        static void Main(string[] args)
        {
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
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
