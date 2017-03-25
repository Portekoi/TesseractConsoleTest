using System;
using Tesseract;
using System.Drawing;

namespace TesseractConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {


            string appDirectory = Environment.CurrentDirectory;
            string path = appDirectory + @"\images\c.jpg";
            Bitmap image = new Bitmap(path);

            using (var engine = new TesseractEngine(@"./tessdata", "eng"))
            {
                engine.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNPQRSTUVWXYZ0123456789");

                using (var page = engine.Process(image, PageSegMode.SingleChar))
                {
                    Console.WriteLine(page.GetText());
                }
                              
            }

            Console.Read();
        }
    }
}
