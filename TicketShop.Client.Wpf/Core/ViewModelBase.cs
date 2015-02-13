using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicketShop.Client.Wpf.Core
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
            {
                return;
            }

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Properties
        #region ToolBarButtonList
        private IList<Button> toolBarButtonList;
        public IList<Button> ToolBarButtonList
        {
            get { return toolBarButtonList; }
            set
            {
                toolBarButtonList = value;
                OnPropertyChanged("ToolBarButtonList");
            }
        }
        #endregion
        #endregion

        #region Ctor
        public ViewModelBase()
        {
            ToolBarButtonList = new List<Button>();
            BuildToolbarButtons();
        }
        #endregion

        #region Methods
        protected abstract void BuildToolbarButtons();
        public abstract void ShowWindow();
        public abstract void ShowWindow(string title);
        #endregion
    }
}
