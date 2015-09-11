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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Venus.WF.WorkFlowDesigner.Controls
{
    /// <summary>
    /// ToolBarButtonControl.xaml 的交互逻辑
    /// </summary>
    public partial class ToolBarButtonControl : UserControl
    {
        public ToolBarButtonControl()
        {
            InitializeComponent();
        }

        public Brush FillColor
        {
            get { return this.RecObject.Fill; }
            set { this.RecObject.Fill = value; }
        }

        public string Text
        {
            get { return this.TextObject.Text; }
            set { this.TextObject.Text = value;}
        }

        public Brush TextColor
        {
            get { return this.TextObject.Foreground; }
            set { this.TextObject.Foreground = value; }
        }
    }
}
