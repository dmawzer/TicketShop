using Infragistics.Windows.DockManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TicketShop.Client.Wpf.Core;

namespace TicketShop.Client.Wpf.Startup
{
    public class MainContainerViewModel : ViewModelBase
    {
        #region Properties
        private readonly IContainer container;
        #endregion

        #region Constructor
        public MainContainerViewModel(IContainer container)
        {
            this.container = container;
        }
        #endregion

        #region Commands
        #region CountryList Command
        private ICommand countryListCommand;
        public ICommand CountryListCommand
        {
            get
            {
                if (countryListCommand == null)
                {
                    countryListCommand = new DelegateCommand(CanCountryListExecute, CountryListExecute);
                }
                return countryListCommand;
            }
        }

        private void CountryListExecute()
        {
            ViewModelBase viewModel = IoCContainerManager.Instance.WindsorContainer.Resolve<ViewModelBase>("CountryListViewModel");
            viewModel.ShowWindow();
        }

        private bool CanCountryListExecute()
        {
            return true;
        }
        #endregion

        #region CountryEdit Command
        private ICommand countryEditCommand;
        public ICommand CountryEditCommand
        {
            get
            {
                if (countryEditCommand == null)
                {
                    countryEditCommand = new DelegateCommand(CanCountryEditExecute, CountryEditExecute);
                }
                return countryEditCommand;
            }
        }

        private void CountryEditExecute()
        {
            ViewModelBase viewModel = IoCContainerManager.Instance.WindsorContainer.Resolve<ViewModelBase>("CountryEditViewModel");
            viewModel.ShowWindow();
        }

        private bool CanCountryEditExecute()
        {
            return true;
        }
        #endregion
        #endregion

        #region Methods
        protected override void BuildToolbarButtons()
        {
            ToolBarButtonList.Add(new Button { Content = "Country List", Command = CountryListCommand });
            ToolBarButtonList.Add(new Button { Content = "Country Edit", Command = CountryEditCommand });
        }
        #endregion

        public override void ShowWindow()
        {
            container.Show(this);
        }

        public override void ShowWindow(string title)
        {
            container.Show(this);
        }
    }
}
