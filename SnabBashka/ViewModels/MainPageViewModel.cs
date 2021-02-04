using DevExpress.Mvvm;
using SnabBashka.Commands;
using SnabBashka.Pages;
using SnabBashka.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static SnabBashka.Models.SupplyDpt;

namespace SnabBashka.ViewModels
{
    public class MainPageViewModel : BindableBase, INotifyPropertyChanged
    {
        private readonly PageService _navigation;
        private readonly Repository _repository;
        private ObservableCollection<Invoice> _Invoices { get; set; }

        public ObservableCollection<Invoice> Invoices
        {
            get { return _Invoices; }
            set 
            {
                _Invoices = value;
                CanSaveAllCommandExecuted(true);
            }
        }

        public MainPageViewModel(Repository repository, PageService navigation)
        {
            Invoices = new ObservableCollection<Invoice>();
            _navigation = navigation;
            _repository = repository;            

            List<Invoice> invoices = Invoices.ToList();            
            
            foreach (var i in _repository.GetCollection<Invoice>().FindAll())
                invoices.Add(i);          
            
            invoices.Sort(new OrderComparer());
            foreach (var i in invoices)
                Invoices.Add(i);

            CanSaveAllCommandExecuted(false);
            CloseAppCommand = new RelayCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
            SaveAllCommand = new RelayCommand(OnSaveAllCommandExecuted, CanSaveAllCommandExecuted);
        }


        public ICommand AddInvoice => new DelegateCommand(() =>
        {
            _navigation.Navigate(new CreateInvoicePage());
        });

        //public ICommand SaveAll => new DelegateCommand(() =>
        //{
        //    _repository.GetCollection<Invoice>().Upsert(Invoices);
        //});
        public ICommand SaveAllCommand { get; }
        private bool CanSaveAllCommandExecuted(object p)
        {
            if (p != null)
                return true;
            return false;
        }
        private void OnSaveAllCommandExecuted(object p) => _repository.GetCollection<Invoice>().Upsert(Invoices);


        public DelegateCommand<Invoice> RemoveCommand { get; private set; }
        void RemoveCommandExecute(ObservableCollection<Invoice> invoices) 
        {
            foreach (var i in invoices)
                _repository.GetCollection<Invoice>().Delete(i.Id);
        }
        public ICommand CloseAppCommand { get; }
        private void OnCloseAppCommandExecuted(object p)
        {

        }
        private bool CanCloseAppCommandExecute(object p) => true;

    }
}
