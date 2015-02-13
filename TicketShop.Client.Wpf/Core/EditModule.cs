using Infragistics.Windows.DockManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicketShop.Client.Wpf.Core
{
    public class EditModule : ModuleBase
    {
        #region Methods
        protected override ContentPane GetContentPane(string header)
        {
            return CreateContentPane(header);
        }

        protected virtual ContentPane CreateContentPane(string header)
        {
            return new ContentPane();
        }

        protected override object RedrawContent(object content)
        {
            XamDockManager dockManager = new XamDockManager();
            dockManager.Content = content;
            DockPanel.SetDock(dockManager, Dock.Bottom);
            DockPanel.Children.Add(dockManager);
            return DockPanel;
        }
        #endregion
    }
}
