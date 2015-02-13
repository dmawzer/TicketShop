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
using Countryy = TicketShop.Core.Domain.Model.Country;

namespace TicketShop.Client.Wpf.Module.Country
{
    public class CountryEditViewModel : ViewModelBase
    {
        #region Fields
        private readonly IGenericDataService<Countryy> countryService;
        private readonly IModule countryEditModule;
        private readonly EditMode editMode;
        private Countryy model;
        #endregion

        #region Properties
        public Countryy Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged("Model");
            }
        }

        public string Code
        {
            get { return Model.Code; }
            set
            {
                Model.Code = value;
                OnPropertyChanged("Code");
            }
        }

        public string Name
        {
            get { return Model.Name; }
            set
            {
                Model.Name = value;
                OnPropertyChanged("Name");
            }
        }
        #endregion

        #region Ctor
        public CountryEditViewModel(IGenericDataService<Countryy> countryService, IModule countryEditModule)
            : this(countryService, countryEditModule, new Countryy(), EditMode.New)
        {
        }

        public CountryEditViewModel(IGenericDataService<Countryy> countryService, IModule countryEditModule, Countryy country, EditMode editMode)
        {
            this.Model = country;
            this.countryService = countryService;
            this.countryEditModule = countryEditModule;
            this.editMode = editMode;
            PropertyChanged += CountryEditViewModel_PropertyChanged;
        }

        protected override void BuildToolbarButtons()
        {
            ToolBarButtonList.Add(new Button { Content = "Save", Command = SaveCommand, BorderThickness = new System.Windows.Thickness(2) });
        }
        #endregion

        #region Command
        #region Save Command
        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new DelegateCommand(CanSaveExecute, SaveExecute);
                }
                return saveCommand;
            }
        }

        private bool CanSaveExecute()
        {
            return Model != null
                && !string.IsNullOrEmpty(Model.Code)
                && !string.IsNullOrEmpty(Model.Name)
                && (editMode == EditMode.New
                    || editMode == EditMode.Edit);
        }

        private void SaveExecute()
        {
            countryService.SaveOrUpdate(Model);
        }

        private void CountryEditViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Model")
            {
                OnPropertyChanged("Code");
                OnPropertyChanged("Name");
            }
        }
        #endregion
        #endregion

        public override void ShowWindow()
        {
            countryEditModule.Show(this);
        }

        public override void ShowWindow(string title)
        {
            countryEditModule.Show(title, this);
        }
    }
}
