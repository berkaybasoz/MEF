using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Composition;

namespace MEF02
{
    public interface IMenuPlugin
    {
        void ChangeControl(Control control);
    }
}
