using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Shell;

namespace ApiGenerator.ToolWindows
{
    [Guid(WindowGuidString)]
    public class ApiConfigToolWindow : ToolWindowPane
    {
        public const string WindowGuidString = "6c53bba0-3c1a-425d-9b7e-3e9176be3a67";
            //"e4e2ba26-a455-4c53-adb3-8225fb696f8b"; // Replace with new GUID in your own code
        public const string Title = "Api Generator for MySQL Migrations";

        // "state" parameter is the object returned from MyPackage.InitializeToolWindowAsync
        public ApiConfigToolWindow(ApiGeneratorState state) : base()
        {
            Caption = Title;
            BitmapImageMoniker = KnownMonikers.ImageIcon;

            Content = new ApiConfigToolWindowControl(state);
        }
    }
}