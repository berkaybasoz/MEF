using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Drawing;

namespace MEF02.MorePlugins
{

    [Export("Color", typeof(IMenuPlugin))]
    [MenuPluginMetadata("Green")]
    class GreenPlugin : IMenuPlugin
    { 
        public void ChangeControl(System.Windows.Forms.Control control)
        {
            control.ForeColor = Color.Green;
        }
    }

}
