using System;
using System.Collections.Generic;
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
            };
        }
    }
}
