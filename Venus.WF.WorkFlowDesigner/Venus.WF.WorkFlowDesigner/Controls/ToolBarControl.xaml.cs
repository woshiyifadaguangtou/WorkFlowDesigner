using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Venus.WF.WorkFlowDesigner.Controls.ElementControls;

namespace Venus.WF.WorkFlowDesigner.Controls
{
    /// <summary>
    /// ToolBarControl.xaml 的交互逻辑
    /// </summary>
    public partial class ToolBarControl : UserControl
    {
        public ToolBarControl()
        {
            InitializeComponent();
            InitEvent();
        }

        private void InitEvent()
        {
            foreach (ToolBarButtonControl toolBarButton in SmallToolbarPanel.Children)
            {
                toolBarButton.MouseEnter +=  new MouseEventHandler( toolBarButton_MouseEnter); 
            }

            this.RootGrid.MouseLeave += delegate(object sender, MouseEventArgs e)
            {
                Storyboard storyboard = this.Resources["ST_MouseLeave"] as Storyboard;
                storyboard.Begin();

                foreach (ToolBarButtonControl toolbarButtonControl in this.SmallToolbarPanel.Children)
                {
                    toolbarButtonControl.TextColor = Brushes.Black;
                }
            };
        }

        void toolBarButton_MouseEnter(object sender, MouseEventArgs e)
        {
            foreach (ToolBarButtonControl t in this.SmallToolbarPanel.Children)
            {
                t.TextColor = Brushes.Black;
            }

            ToolBarButtonControl toolbarButtonControl = sender as ToolBarButtonControl;
            RecObject.Fill = toolbarButtonControl.FillColor;
            toolbarButtonControl.TextColor = Brushes.White;

            Storyboard storyboard = this.Resources["ST_MouseEnter"] as Storyboard;
            storyboard.Begin();

            this.ToolbarPanelGrid.Children.Clear();

            LoadToolbarPanelControl(toolbarButtonControl);
        }

        private void LoadToolbarPanelControl(ToolBarButtonControl toolbarButtonControl)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.VerticalAlignment = System.Windows.VerticalAlignment.Top;

            #region 动态获取所有的IElementControl

            var types =  this.GetType().Assembly.GetTypes();
            var query = from Type t in types
                        where t.GetInterface(typeof(IElementControl).FullName) != null
                        select t;
           
            foreach (var type in query)
            {
                IElementControl elementControl = this.GetType().Assembly.CreateInstance(type.FullName) as IElementControl;
                elementControl.InitEvent();
                if (toolbarButtonControl.Tag != null && toolbarButtonControl.Tag.ToString() == elementControl.OwnerName)
                {
                    UserControl userControl = elementControl as UserControl;
                    userControl.Height = 100;
                    userControl.Width = 100;
                    userControl.Margin = new Thickness(10, 10, 10, 10);
                    stackPanel.Children.Add(userControl);

                }
            }
            this.ToolbarPanelGrid.Children.Add(stackPanel);
            #endregion
        }
    }
}
