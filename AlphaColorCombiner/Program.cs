using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace AlphaColorCombiner {
    class Program {
        static void Main(string[] args) {

            Bitmap bmpAlpha = null;
            Bitmap bmpColor = null;

            Console.WriteLine("Specify the path of the alpha image");
            try {
                bmpAlpha = new Bitmap(Console.ReadLine());
            }
            catch (FileNotFoundException e) {
                Console.WriteLine("Invalid image path, please restart the program");
            }

            Console.WriteLine("Specify the path of the color image");
            try {
                bmpColor = new Bitmap(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine("Invalid image path, please restart the program");
            }

            Bitmap newBmp = new Bitmap(bmpAlpha.Width, bmpAlpha.Height);

            try {
                for (int x = 0; x < bmpAlpha.Width; x++) {
                    for (int y = 0; y < bmpAlpha.Height; y++) {
                        Color alphaColor = bmpAlpha.GetPixel(x, y);
                        Color colorColor = bmpColor.GetPixel(x, y);
                        Color newColor = Color.FromArgb(alphaColor.A, colorColor.R, colorColor.G, colorColor.B);
                        newBmp.SetPixel(x, y, newColor);
                    }
                }
            }
            catch (ArgumentOutOfRangeException e) {
                Console.WriteLine("Images must be same dimensions");
            }

            Console.WriteLine("Please enter a name for the new image");

            try {
                newBmp.Save(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine("There was a problem saving your image");
            }

        }
    }
}
