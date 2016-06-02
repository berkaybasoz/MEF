using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel.Composition;

namespace MEF02
{
    [Export("Size", typeof(IMenuPlugin))]
    [MenuPluginMetadata("Size +10")]
    class SizeUpPlugin : IMenuPlugin
    {
        
        public void ChangeControl(System.Windows.Forms.Control control)
        {
            control.Font = new System.Drawing.Font(control.Font.FontFamily, control.Font.Size + 10.0f);
        }
    }

    [Export("Size", typeof(IMenuPlugin))]
    [MenuPluginMetadata("Size -10")]
    class SizeDownPlugin : IMenuPlugin
    { 
        public void ChangeControl(System.Windows.Forms.Control control)
        {
            control.Font = new System.Drawing.Font(control.Font.FontFamily, control.Font.Size - 10.0f);
        }
    }

    [Export("Color", typeof(IMenuPlugin))]
    [MenuPluginMetadata("Red")]
    class ColorRedPlugin : IMenuPlugin
    { 
        public void ChangeControl(System.Windows.Forms.Control control)
        {
            control.ForeColor = Color.Red;
        }
    }

    [Export("Color", typeof(IMenuPlugin))]
    [MenuPluginMetadata("Blue")]
    class ColorBluePlugin : IMenuPlugin
    {
        public void ChangeControl(System.Windows.Forms.Control control)
        {
            control.ForeColor = Color.Blue;
        } 
    }
}
