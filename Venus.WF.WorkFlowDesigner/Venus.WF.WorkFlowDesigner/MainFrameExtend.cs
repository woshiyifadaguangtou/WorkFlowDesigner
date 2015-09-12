using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;


namespace Venus.WF.WorkFlowDesigner
{
    public static class MainFrameExtend
    {
        private static Window fullWindow;
        private static WindowState windowState;
        private static WindowStyle windowStyle;
        private static Rect windowRect;
        private static bool windowTopMost;
        private static ResizeMode windowResizeMode;
        public static void GoFullScreen(this Window window)
        {
            if (window.IsFullScreen())
            {
                return;
            }
            windowState = window.WindowState;
            windowStyle = window.WindowStyle;
            windowRect.X = window.Left;
            windowRect.Y = window.Top;
            windowRect.Height = window.Height;
            windowRect.Width = window.Width;
            windowResizeMode = window.ResizeMode;
            windowTopMost = window.Topmost;

            window.WindowState = WindowState.Maximized;
            window.WindowStyle = WindowStyle.None;
            window.ResizeMode = ResizeMode.NoResize;

            var hander = new WindowInteropHelper(window).Handle;
            Screen screen = Screen.FromHandle(hander);
            window.MaxWidth = screen.Bounds.Width;
            window.MaxHeight = screen.Bounds.Height;

            fullWindow = window;
        }

        public static void ExitFullScreen(this Window window)
        {
            if (!window.IsFullScreen())
            { 
                return;
            }
            window.WindowState = windowState;
            window.WindowStyle = windowStyle;
            window.Topmost = windowTopMost;
            window.ResizeMode = windowResizeMode;
            window.Left = windowRect.X;
            window.Top = windowRect.Y;
            window.Height = windowRect.Height;
            window.Width = windowRect.Width;

            fullWindow = null;

        }
        public static bool IsFullScreen(this Window window)
        {
            if (window == null)
            {
                return false;
            }

            return window == fullWindow;
        }
    }
}
