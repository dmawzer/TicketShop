using Infragistics.Windows.DockManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TicketShop.Client.Service.Core;
using TicketShop.Client.Wpf.Core;
using TicketShop.Core.Domain.Logical;
using TicketShop.Core.Domain.Model;
using Countryy = TicketShop.Core.Domain.Model.Country;

namespace TicketShop.Client.Wpf.Module.Country
{
    public class CountryListViewModel : ViewModelBase
    {
        #region Fields
        private readonly IGenericDataService<Countryy> countryService;
        private readonly IModule countryListModule;
        private Countryy selectedDataGridItem;
        private IList<Countryy> model;
        #endregion

        #region Properties
        public Countryy SelectedDataGridItem
        {
            get { return selectedDataGridItem; }
            set
            {
                selectedDataGridItem = value;
                OnPropertyChanged("SelectedDataGridItem");
            }
        }

        public IList<Countryy> Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged("Model");
            }
        }
        #endregion

        #region Ctor
        public CountryListViewModel(IGenericDataService<Countryy> countryService, IModule countryListModule)
        {
            this.Model = new List<Countryy>();
            this.countryService = countryService;
            this.countryListModule = countryListModule;
        }
        #endregion

        #region Commands
        #region GetInfo Command
        private ICommand getInfoCommand;
        public ICommand GetInfoCommand
        {
            get
            {
                if (getInfoCommand == null)
                {
                    getInfoCommand = new DelegateCommand(CanGetInfoExecute, GetInfoExecute);
                }
                return getInfoCommand;
            }
        }

        private bool CanGetInfoExecute()
        {
            return true;
        }

        private void GetInfoExecute()
        {
            Model = countryService.GetAll();
        }
        #endregion

        #region View Command
        private ICommand viewCommand;
        public ICommand ViewCommand
        {
            get
            {
                if (viewCommand == null)
                {
                    viewCommand = new DelegateCommand(CanViewExecute, ViewExecute);
                }
                return viewCommand;
            }
        }

        private bool CanViewExecute()
        {
            return SelectedDataGridItem != null;
        }

        private void ViewExecute()
        {
            if (SelectedDataGridItem == null)
            {
                return;
            }

            ViewModelBase viewModel = IoCContainerManager.Instance.WindsorContainer.Resolve<ViewModelBase>("CountryEditViewModel", new { country = SelectedDataGridItem, editMode = EditMode.View });
            string title = string.Format("Country - {0}-{1}", SelectedDataGridItem.Id, SelectedDataGridItem.Name);
            viewModel.ShowWindow(title);
        }
        #endregion
        #endregion

        #region Methods
        protected override void BuildToolbarButtons()
        {
            ToolBarButtonList.Add(new Button { Content = "Get Info", Command = GetInfoCommand, BorderThickness = new System.Windows.Thickness(2) });
            ToolBarButtonList.Add(new Button { Content = "View", Command = ViewCommand, BorderThickness = new System.Windows.Thickness(2) });
        }

        public override void ShowWindow()
        {
            countryListModule.Show(this);
        }

        public override void ShowWindow(string title)
        {
            countryListModule.Show(title, this);
        }
        #endregion
    }
}
