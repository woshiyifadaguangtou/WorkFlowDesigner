using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Venus.WF.WorkFlowDesigner.Controls.ElementControls;

namespace Venus.WF.WorkFlowDesigner
{
    public interface IMain
    {
        Panel RootPanel { get; }
        Panel CanvasPanel { get; }
        UserControl CurrentMoveControl { get; set; }
        List<UserControl> CurrentSelectionControlList { get; set; }
        List<IElementControl> CurrentSelectionElementControlList { get; }
    }
}
