using DevExpress.Mvvm;
using SnabBashka.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SnabBashka.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly PageService _navigation;
        private readonly Repository _repository;

        public MainPageViewModel(Repository repository)
        {
            _repository = repository;
        }
        

        public ICommand AddInvoice => new DelegateCommand(() =>
        {

        });

        public ICommand RemoveInvoice => new DelegateCommand(() =>
        {

        });
        public MainPageViewModel(PageService navigation)
        {
            _navigation = navigation;
        }
    }
}
