using Infragistics.Windows.DataPresenter;
using Infragistics.Windows.DockManager;
using System;
using System.Collections;
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
    public class BrowseModule : ModuleBase
    {
        #region Properties
        public XamDataGrid DataGrid { get; set; }

        #region Dependencies Properties
        #region DataGridFieldSettings
        public FieldSettings DataGridFieldSettings
        {
            get
            {
                return (FieldSettings)GetValue(DataGridFieldSettingsProperty);
            }
            set
            {
                SetValue(DataGridFieldSettingsProperty, value);
            }
        }
        public static readonly DependencyProperty DataGridFieldSettingsProperty = DependencyProperty.Register("DataGridFieldSettings", typeof(FieldSettings), typeof(BrowseModule));
        #endregion

        #region DataGridFieldLayout
        public FieldLayout DataGridFieldLayout
        {
            get
            {
                return (FieldLayout)GetValue(DataGridFieldLayoutProperty);
            }
            set
            {
                SetValue(DataGridFieldLayoutProperty, value);
            }
        }
        public static readonly DependencyProperty DataGridFieldLayoutProperty = DependencyProperty.Register("DataGridFieldLayout", typeof(FieldLayout), typeof(BrowseModule));
        #endregion

        #region DataGridDataSource
        public IEnumerable DataGridDataSource
        {
            get
            {
                return (IEnumerable)GetValue(DataGridDataSourceProperty);
            }
            set
            {
                SetValue(DataGridDataSourceProperty, value);
            }
        }

        public static readonly DependencyProperty DataGridDataSourceProperty = DependencyProperty.Register("DataGridDataSource", typeof(IEnumerable), typeof(BrowseModule), new PropertyMetadata(new PropertyChangedCallback(SetDataGridDataSource)));
        #endregion
        #endregion
        #endregion

        #region Ctor
        public BrowseModule()
        {
            DataGrid = new XamDataGrid { Name = "DataGrid" };
        }
        #endregion

        #region Methods
        private static void SetDataGridDataSource(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs arg)
        {
            BrowseModule browseModule = dependencyObject as BrowseModule;
            if (browseModule == null)
            {
                return;
            }
            browseModule.DataGrid.DataSource = arg.NewValue as IEnumerable;
        }

        protected override object RedrawContent(object content)
        {
            Binding binding = new Binding { Path=new PropertyPath("SelectedDataGridItem")};
            DataGrid.SetBinding(XamDataGrid.ActiveDataItemProperty, binding);
            
            if (DataGridFieldLayout != null)
            {
                DataGrid.FieldLayouts.Add(DataGridFieldLayout);
                DataGrid.DefaultFieldLayout = DataGridFieldLayout;
            }

            if (DataGridFieldSettings != null)
            {
                DataGrid.FieldLayoutSettings = new FieldLayoutSettings { AutoGenerateFields = false };
                DataGrid.FieldSettings = DataGridFieldSettings;
            }
            XamDockManager dockManager = new XamDockManager();
            dockManager.Content = DataGrid;
            DockPanel.SetDock(dockManager, Dock.Bottom);
            DockPanel.Children.Add(dockManager);
            return DockPanel;
        }

        protected override ContentPane GetContentPane(string header)
        {
            return CreateContentPane(header);
        }

        protected virtual ContentPane CreateContentPane(string header)
        {
            return new ContentPane();
        }
        #endregion
    }
}
