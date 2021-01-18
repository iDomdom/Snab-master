using SnabBashka.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnabBashka
{
    class ViewModelLocator
    {
        public MainViewModel MainViewModel => DependencyInjection.Resolve<MainViewModel>();
        public MainPageViewModel MainPageViewModel => DependencyInjection.Resolve<MainPageViewModel>();
    }
}
