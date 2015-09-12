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

namespace Venus.WF.WorkFlowDesigner
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window,IMain
    {
        public MainWindow()
        {
            InitializeComponent();
            this.GoFullScreen();
            InitEvent();
        }
        public Panel RootPanel
        {
            get;
        }

        public UserControl CurrentMoveControl
        { get; set; }
        private void InitEvent()
        {
            this.KeyDown += delegate(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.F)
                {
                    this.GoFullScreen();
                }
                else if (e.Key == Key.E)
                {
                    this.ExitFullScreen();
                }
                else if (e.Key == Key.Escape)
                {
                    this.Close();
                }
            };



            this.RootGrid.MouseMove += (s, e) =>
            {

            };
            
        }
    }
}
