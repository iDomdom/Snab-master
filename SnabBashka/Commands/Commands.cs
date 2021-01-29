using DevExpress.Mvvm;
using SnabBashka.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SnabBashka.Commands
{
    public class Commands
    {
        private readonly Repository _repository;

        public Commands(Repository repository)
        {
            _repository = repository;
        }

        public ICommand SaveInvoice<T>(T item)
        {
            return new DelegateCommand(() =>
            {
                _repository.Save(item);
            });
        }
    }
}
