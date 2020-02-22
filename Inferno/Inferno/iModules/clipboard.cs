namespace Inferno
{
    internal class clipboard
    {
        // Output
        private static dynamic output = new System.Dynamic.ExpandoObject();

        // Set text to clipboard
        public static void Set(string text)
        {
            System.Windows.Forms.Clipboard.SetText(text);
            core.Exit("Clipboard text set", output);
        }
        // Get text from clipboard
        public static void Get()
        {
            string content = System.Windows.Forms.Clipboard.GetText();
            output.clipboard = content;
            core.Exit("Clipboard content received", output);
        }

    }
}
