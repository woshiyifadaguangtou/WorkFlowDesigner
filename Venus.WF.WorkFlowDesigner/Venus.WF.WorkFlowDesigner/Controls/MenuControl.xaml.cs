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
using System.Windows.Threading;

namespace Venus.WF.WorkFlowDesigner.Controls
{
    /// <summary>
    /// MenuControl.xaml 的交互逻辑
    /// </summary>
    public partial class MenuControl : UserControl
    {
        public MenuControl()
        {
            InitializeComponent();
            InitTimer();
            InitEvent();
        }

        private void InitTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += delegate(object sender, EventArgs e)
            {
                this.CurrentDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            };
            timer.IsEnabled = true;
        }

        private void InitEvent()
        {
            this.MouseEnter += delegate(object sender, MouseEventArgs e)
            {
                this.MessagePanel.Visibility = System.Windows.Visibility.Hidden;
            };

            Storyboard storyboard = this.Resources["ST_MouseLeave"] as Storyboard;
            storyboard.Completed += delegate(object sender, EventArgs e)
            {
                this.MessagePanel.Visibility = System.Windows.Visibility.Visible;
            };
        }

        public void ShowMessage(string message)
        {
            this.MessageBlock.Text = message;
        }
    }
}
