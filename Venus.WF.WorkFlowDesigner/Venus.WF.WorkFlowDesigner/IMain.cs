using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Venus.WF.WorkFlowDesigner
{
    public interface IMain
    {
        Panel RootPanel { get; }
        UserControl CuurentMoveControl { get; }
    }
}
