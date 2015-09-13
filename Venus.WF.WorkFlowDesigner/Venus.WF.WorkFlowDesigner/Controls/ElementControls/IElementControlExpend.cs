using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Venus.WF.WorkFlowDesigner.Controls.ElementControls
{
    public static class IElementControlExpend
    {
        public static void InitEvent(this IElementControl elementControl)
        {
            var userControl = elementControl as UserControl;
            userControl.MouseEnter += (s,e)=>
            {
                Panel p = userControl.Content as Panel;
                var storyboard = App.Current.Resources["ST_IElementControl_MouseEnter"] as Storyboard;
                storyboard.Begin(p);
            };
            userControl.MouseLeave += (s, e) =>
            {
                Panel p = userControl.Content as Panel;
                var storyboard = App.Current.Resources["ST_IElementControl_MouseLeave"] as Storyboard;
                storyboard.Begin(p);
            };

            userControl.MouseLeftButtonDown += (s, e) =>
            {
                var mainWindow = App.Current.MainWindow as IMain;
                Point p = e.GetPosition(mainWindow.RootPanel);
                
                var newuserControl = userControl.GetType().Assembly.CreateInstance(userControl.GetType().FullName) as UserControl;
                var newElementControl = newuserControl as IElementControl;

                newuserControl.Width = 100;
                newuserControl.Height = 100;
                Canvas.SetTop(newuserControl, p.Y);
                Canvas.SetLeft(newuserControl, p.X);
                Canvas.SetZIndex(newuserControl, 100);

                newElementControl.InitCanvasEvent();

                mainWindow.CanvasPanel.Children.Add(newuserControl);
                mainWindow.CurrentMoveControl = newuserControl;

                e.Handled = true;
            };
        }

        public static void InitCanvasEvent(this IElementControl elementControl)
        {
            var main = App.Current.MainWindow as IMain;
            UserControl userControl = elementControl as UserControl;
            userControl.MouseLeftButtonDown += (s, e) =>
                {
                    main.CurrentMoveControl = null;
                    Canvas.SetZIndex(userControl, 0);

                    Storyboard storyboard = App.Current.Resources["ST_ElementControl_MouseEnter"] as Storyboard;
                    storyboard.Begin(userControl.Content as Panel);

                    e.Handled = true;
                };
            userControl.MouseLeftButtonUp += (s, e) =>
                {
                    foreach (var eControl in main.CurrentSelectionControlList)
                    {

                    }
                };
        }
    }
}
