using Infragistics.Windows.DockManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace TicketShop.Client.Wpf.Core
{
    public abstract class ModuleBase : UserControl, IModule
    {
        #region Properties
        protected DockPanel DockPanel { get; set; }
        protected ToolBar ToolBar { get; set; }
        #endregion

        #region Ctor
        public ModuleBase()
        {
            Initialize();
        }
        #endregion

        #region Methods
        protected abstract ContentPane GetContentPane(string header);

        protected abstract object RedrawContent(object content);

        public void Show(string header, ViewModelBase viewModel)
        {
            ContentPane contentPane = GetContentPane(header);
            contentPane.CloseAction = PaneCloseAction.RemovePane;
            contentPane.DataContext = viewModel;
            ModuleListManager.Instance.ContentPaneAdd(contentPane);
            contentPane.Activate();
        }

        public void Show(ViewModelBase viewModel)
        {
            Show(string.Empty, viewModel);
        }

        private void Initialize()
        {
            ToolBar = new ToolBar() { Height = 50, VerticalAlignment = System.Windows.VerticalAlignment.Top };
            Binding binding = new Binding { Path = new PropertyPath("ToolBarButtonList") };
            ToolBar.SetBinding(ToolBar.ItemsSourceProperty, binding);

            DockPanel = new DockPanel();
            DockPanel.SetDock(ToolBar, Dock.Top);
            DockPanel.Children.Add(ToolBar);
            this.Content = DockPanel;
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            if (DesignerProperties.GetIsInDesignMode(this))
                return;
            if (newContent != null && DockPanel != newContent)
            {
                this.Content = RedrawContent(newContent);
                newContent = this.Content;
                base.OnContentChanged(oldContent, newContent);
            }
        }
        #endregion
    }
}
