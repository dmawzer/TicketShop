using Infragistics.Windows.DockManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop.Client.Wpf
{
    public class ModuleListManager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<ContentPane> ContentPaneAdded;
        private static ModuleListManager instance;
        private static object lockObject = new object();
        
        public static ModuleListManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        instance = new ModuleListManager();
                    }
                }
                return instance;
            }
        }

        public void ContentPaneAdd(ContentPane contentPane)
        {
            if (ContentPaneAdded == null)
            {
                return;
            }
            ContentPaneAdded(this, contentPane);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
            {
                return;
            }

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
